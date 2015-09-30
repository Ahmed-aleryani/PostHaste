namespace PostHaste.Core
{
    internal class HasteResponse
    {
        public string Key { get; set; }

        public string GetUrl(string baseUrl)
        {
            return $"{baseUrl}/{Key}";
        }
    }
}
