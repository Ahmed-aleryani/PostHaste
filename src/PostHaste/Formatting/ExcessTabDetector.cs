namespace PostHaste.Formatting
{
    using System.Collections.Generic;
    using System.Linq;
    using Core;

    public class ExcessTabDetector
    {
        public static int DetectExcessTabDepth(IEnumerable<CodeLine> codeLines)
        {
            Guard.ArgumentNotNull(nameof(codeLines), codeLines);

            var enumerable = codeLines as CodeLine[] ?? codeLines.ToArray();

            if (enumerable.All(cl => cl.IsEmpty) || !enumerable.Any())
            {
                return 0;
            }

            return enumerable.Where(cl => !cl.IsEmpty).Min(cl => cl.TabCount);
        }
    }
}
