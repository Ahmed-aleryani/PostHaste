namespace PostHaste.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Fixie;
    using Formatting;
    using PostHaste.Formatting;

    public class ParameterProvider : ParameterSource
    {
        private readonly static string AnyString = FormattingTestsBase.AnyString;
        private readonly static string TabString = FormattingTestsBase.TabString;
        private readonly static string Newline = CodeLine.NewLine;

        public IEnumerable<object[]> GetParameters(MethodInfo method)
        {
            if (method.Name.Equals("ParameterisedTabRemoverTest", StringComparison.OrdinalIgnoreCase))
            {
                return ParameterisedTabRemoverTestData;
            }

            return new[]
            {
                new object[0]
            };
        }

        private IEnumerable<object[]> ParameterisedTabRemoverTestData => new[]
        {
            new[] {$"{TabString}{AnyString}", $"{AnyString}"},
            new[] {$"{Newline}{TabString}{AnyString}", $"{AnyString}"},
            new[] {$"{Newline}{Newline}{TabString}{AnyString}", $"{Newline}{AnyString}"},
            new[] {$"{Newline}{Newline}", $"{Newline}{Newline}"},
            new[]
            {
                $"{TabString}{AnyString}{Newline}{TabString}{AnyString}{Newline}{Newline}{TabString}{TabString}{AnyString}",
                $"{AnyString}{Newline}{AnyString}{Newline}{Newline}{TabString}{AnyString}"
            },
            new[] {$"{Newline}{Newline}{Newline}", $"{Newline}{Newline}{Newline}"},
            new[]
            {
                $"{Newline}{TabString}{AnyString}{Newline}{Newline}{TabString}{AnyString}",
                $"{AnyString}{Newline}{Newline}{AnyString}"
            },
            new[]
            {
                $"{Newline}{TabString}{AnyString}{Newline}{Newline}{TabString}{AnyString}{Newline}",
                $"{AnyString}{Newline}{Newline}{AnyString}{Newline}"
            },
            new[]
            {
                $"{TabString}{AnyString}{Newline}{Newline}{TabString}{AnyString}{Newline}{Newline}{TabString}{AnyString}",
                $"{AnyString}{Newline}{Newline}{AnyString}{Newline}{Newline}{AnyString}"
            },
            new[]
            {
                $"{TabString}{AnyString}{Newline}{TabString}{AnyString}{Newline}{TabString}{TabString}{AnyString}",
                $"{AnyString}{Newline}{AnyString}{Newline}{TabString}{AnyString}"
            },
            new[]
            {
                $"{TabString}{AnyString}{Newline}{TabString}{Newline}{TabString}{AnyString}",
                $"{AnyString}{Newline}{Newline}{AnyString}"
            },
            new[]
            {
                $"{Newline}{Newline}{AnyString}",
                $"{Newline}{Newline}{AnyString}"
            },
            new []
            {
                $"{TabString}{AnyString}{AnyString}{Newline}{TabString}{TabString}{AnyString}{Newline}{Newline}{TabString}",
                $"{AnyString}{AnyString}{Newline}{TabString}{AnyString}{Newline}{Newline}"
            }
        };
    }
}