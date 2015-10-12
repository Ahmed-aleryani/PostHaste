namespace PostHaste
{
    using System;
    using System.ComponentModel.Design;
    using Core;
    using Microsoft.VisualStudio.Shell;
    using EnvDTE;
    using Formatting;
    using Microsoft.VisualStudio.Shell.Interop;

    internal class PostHasteCommand
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("6692533c-adee-4b9e-8a51-150cf60030d0");
        
        private readonly Package package;
        private readonly TextSelector textSelector;
        private readonly string url;
        private readonly IVsStatusbar statusBar;
        
        private PostHasteCommand(Package package, TextSelector textSelector)
        {
            if (package == null) throw new ArgumentNullException(nameof(package));

            this.url = Properties.Settings.Default.HasteBinUrl;
            this.package = package;
            this.textSelector = textSelector;

            OleMenuCommandService commandService = ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (commandService != null)
            {
                var menuCommandId = new CommandID(CommandSet, CommandId);
                var menuItem = new MenuCommand(MenuItemCallback, menuCommandId);
                commandService.AddCommand(menuItem);
            }

            statusBar = ServiceProvider.GetService(typeof(SVsStatusbar)) as IVsStatusbar;
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static PostHasteCommand Instance
        {
            get;
            private set;
        }

        private IServiceProvider ServiceProvider => this.package;

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        public static void Initialize(Package package, TextSelector textSelector)
        {
            Instance = new PostHasteCommand(package, textSelector);
        }

        private async void MenuItemCallback(object sender, EventArgs e)
        {
            var currentOpenDocument = GetCurrentTextDocument();

            var textToUpload = textSelector.GetDocumentSelection(currentOpenDocument);

            var urlExtension = new LanguageUrlExtensionProvider(currentOpenDocument).Extension;

            using (var request = new HasteRequest(url))
            {
                var response = await request.PostAsync(textToUpload);

                var fullUrl = response.GetUrl(url, urlExtension);

                ClipboardCommunicator.AddToClipboard(fullUrl);

                SetStatusBarText($"Code URL copied to clipboard: {fullUrl}");
            }
        }

        protected virtual TextDocument GetCurrentTextDocument()
        {
            var developmentToolsEnvironment = Package.GetGlobalService(typeof(DTE)) as DTE;

            var activeDocument = developmentToolsEnvironment?.ActiveDocument;
            
            return activeDocument?.Object() as TextDocument;
        }

        private void SetStatusBarText(string text)
        {
            int frozen;
            if (statusBar != null && statusBar.IsFrozen(out frozen) == 0)
            {
                statusBar.SetText(text);
            }
        }
    }
}
