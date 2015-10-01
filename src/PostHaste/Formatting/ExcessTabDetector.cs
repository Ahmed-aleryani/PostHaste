namespace PostHaste.Formatting
{
    using System.Collections.Generic;
    using System.Linq;
    using Core;

    public class ExcessTabDetector
    {
        public static int DetectExcessTabDepth(IList<CodeLine> codeLines)
        {
            Guard.ArgumentNotNull(nameof(codeLines), codeLines);

            if (codeLines.Count == 0)
            {
                return 0;
            }

            return codeLines.Min(cl => cl.TabCount);
        }
    }
}
