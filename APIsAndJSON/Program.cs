using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var quote = new RonVSKanyeAPI(client);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Kanye: '{quote.KanyeQuote()}'");
                Console.WriteLine($"---------------------");
                Console.WriteLine($"Ron: '{quote.RonQuote()}'");
                Console.WriteLine($"---------------------");
            }


            Console.WriteLine($"Please enter your API Key");
            var api_key = Console.ReadLine();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"Please enter the name of the city");
                var city_name = Console.ReadLine();
                var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city_name}&appid={api_key}";
                var response = client.GetStringAsync(weatherURL).Result;
                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                Console.WriteLine(formattedResponse);
                Console.WriteLine();
                Console.WriteLine($"Would you like to choose a different city?");
                var userinput = Console.ReadLine();
                Console.WriteLine();
                if(userinput.ToLower() == "no")
                {
                    break;
                }
            }
        }
        
    }
}
