namespace PostHaste
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;
    using Core;
    using Microsoft.VisualStudio.Shell;

    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)] // Info on this package for Help/About
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly",
        Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    public sealed class PostHasteCommandPackage : Package
    {
        public const string PackageGuidString = "5b751189-4824-43b5-b1d1-3c1e8f661105";

        protected override void Initialize()
        {
            PostHasteCommand.Initialize(this, new TextSelector());
            base.Initialize();
        }
    }
}