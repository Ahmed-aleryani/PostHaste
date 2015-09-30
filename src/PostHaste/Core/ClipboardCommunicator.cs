namespace PostHaste.Core
{
    using System.Windows.Forms;

    internal class ClipboardCommunicator
    {
        public static void AddToClipboard(string content)
        {
            Clipboard.SetText(content, TextDataFormat.Text);
        }
    }
}
