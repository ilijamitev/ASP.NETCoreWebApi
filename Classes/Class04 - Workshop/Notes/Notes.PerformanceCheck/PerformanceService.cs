namespace Notes.PerformanceCheck
{
    // CHAIN CALLING => 
    public class PerformanceService : ISetUrl, ICheckPerformance
    {
        private string _url = string.Empty;

        public ICheckPerformance SetUrl(string url)
        {
            _url = url;
            return this;
        }

        public void CheckPerformance()
        {
            using HttpClient client = new();
            var limit = 100;
            using HttpResponseMessage response = client.GetAsync(_url).Result;
            string responseBody = response.Content.ReadAsStringAsync().Result;
            if (int.Parse(responseBody) > limit)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine($"Performance: {responseBody} [Limit: {limit}]");

        }
    }
    public interface ISetUrl
    {
        ICheckPerformance SetUrl(string url);
    }

    public interface ICheckPerformance
    {
        void CheckPerformance();

    }
}
