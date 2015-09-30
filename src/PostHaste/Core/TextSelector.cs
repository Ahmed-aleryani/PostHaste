namespace PostHaste.Core
{
    using EnvDTE;

    internal class TextSelector
    {
        public virtual string GetDocumentSelection(TextDocument document)
        {
            if (document.Selection.IsEmpty || string.IsNullOrWhiteSpace(document.Selection.Text))
            {
                return string.Empty;
            }

            return document.Selection.Text;
        }
    }
}
