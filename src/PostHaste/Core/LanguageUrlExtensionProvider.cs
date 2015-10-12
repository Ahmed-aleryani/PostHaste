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
                { "csharp", "cs" },
                { "javascript", "js" },
                { "xml", "xml" },
                { "sql server tools", "sql" },
                { "typescript", "js" }
            }); 

        public LanguageUrlExtensionProvider(TextDocument document)
        {
            string extension;
            if (document.Language != null && Extensions.TryGetValue(document.Language.ToLowerInvariant(), out extension))
            {
                Extension = extension;
            }
        }
    }
}
