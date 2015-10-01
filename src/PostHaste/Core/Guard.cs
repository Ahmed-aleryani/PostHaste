namespace PostHaste.Core
{
    using System;

    public static class Guard
    {
        public static void ArgumentNotNull(string name, object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException($"{name} cannot be null");
            }
        }
    }
}
