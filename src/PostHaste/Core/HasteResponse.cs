namespace PostHaste.Core
{
    internal class HasteResponse
    {
        public string Key { get; set; }

        public string GetUrl(string baseUrl, string extension)
        {
            var url = $"{baseUrl}/{Key}";

            if (!string.IsNullOrWhiteSpace(extension))
            {
                url += $".{extension}";
            }

            return url;
        }
    }
}
