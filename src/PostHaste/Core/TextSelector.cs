namespace PostHaste.Core
{
    using EnvDTE;

    internal class TextSelector
    {
        public virtual string GetDocumentSelection(TextDocument document)
        {
            if (document == null)
            {
                return string.Empty;
            }

            if (document.Selection.IsEmpty || string.IsNullOrWhiteSpace(document.Selection.Text))
            {
                return document.StartPoint.CreateEditPoint().GetText(document.EndPoint);
            }

            return document.Selection.Text;
        }
    }
}
