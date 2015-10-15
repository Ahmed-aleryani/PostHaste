namespace PostHaste.Formatting
{
    using System;
    using System.Linq;
    using Core;

    public class CodeLine
    {
        public const string NewLine = "\r\n";
        private const char Space = ' ';

        private readonly int spacesPerTab;

        public CodeLine(string value, int spacesPerTab)
        {
            Guard.ArgumentNotNull(nameof(value), value);

            if (spacesPerTab == 0)
            {
                throw new ArgumentException("spaces per tab cannot be zero");
            }

            this.spacesPerTab = spacesPerTab;
            Line = value;

            SpaceCount = Line.TakeWhile(c => c == Space).Count();
        }

        public int SpaceCount { get; }

        public string Line { get; }

        public int TabCount => SpaceCount/spacesPerTab;

        public bool IsEmpty => string.IsNullOrEmpty(Line);
    }
}