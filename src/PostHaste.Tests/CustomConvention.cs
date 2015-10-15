namespace PostHaste.Tests
{
    using Fixie;

    public class CustomConvention : Convention
    {
        public CustomConvention()
        {
            Classes.NameEndsWith("Tests");

            Methods.Where(m => m.IsVoid());

            Parameters.Add<ParameterProvider>();
        }
    }
}
