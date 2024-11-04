using System.Net;
using System.Text.Json;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string API_KEY = "46888119-4f479de33dd5134b283fe7a2f";
            string SEARCH = "cats";

            string URL = $"https://pixabay.com/api/?key={API_KEY}&q={SEARCH}&image_type=photo&previewURL&" +
                $"webformatURL&downloads&likes&USERNAME&comments";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (StreamReader reader = new StreamReader(response.GetResponseStream())) 
            {
                string responseText = reader.ReadToEnd();
                
                //Console.WriteLine(responseText);


                Console.WriteLine(" ");
                Console.WriteLine(response.StatusCode);



                ///то что ниже тупо скопипастил чтоб в консоли было все читабельно, а так в соло разобрался))
                ///
                var jsonElement = JsonSerializer.Deserialize<JsonElement>(responseText);
                string formattedJson = JsonSerializer.Serialize(jsonElement,
                new JsonSerializerOptions { WriteIndented = true });
                Console.WriteLine("Форматированный ответ от сервера:");
                Console.WriteLine(formattedJson);
                Console.WriteLine(" ");
                Console.WriteLine("Статус код: " + response.StatusCode);
            }
        }
    }
}
