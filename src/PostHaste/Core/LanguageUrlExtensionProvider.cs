namespace PostHaste.Core
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using EnvDTE;

    internal class LanguageUrlExtensionProvider
    {
        public string Extension { get; }

        private static readonly ReadOnlyDictionary<string, string> Extensions 
            = new ReadOnlyDictionary<string, string>(
            new Dictionary<string, string>
            {
                { "csharp", "cs" }
            }); 

        public LanguageUrlExtensionProvider(TextDocument document)
        {
            if (document.Language != null && Extensions.ContainsKey(document.Language.ToLowerInvariant()))
            {
                Extension = Extensions[document.Language.ToLowerInvariant()];
            }
        }
    }
}
