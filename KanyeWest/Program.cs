using Newtonsoft.Json.Linq;
using System.Net.Http;


for (int i = 0; i < 5; i++)
{
    //Create an HttpClient instance, this is what actually makes the api call
    var client = new HttpClient();

    //Build an api URL from where the api call comes from
    var kanyeURL = "https://api.kanye.rest/";

    //Using the HttpClient instance we created above
    //Send a GET request to url created above, this will give us back a string of JSON (Be sure to use .Result)
    var kanyeResponse = client.GetStringAsync(kanyeURL).Result;

    //Parse the JSON response we just got back into a JObject, we do this so we can access certain pieces of the JSON
    //In this case we will be getting the value of "quote" which will be the actual quote itself and not the whole JSON body
    //Without ToString it will be a JToken so we would never be able to use it in string format
    //var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
    var kanyeQuote = JObject.Parse(kanyeResponse)["quote"].ToString();

    Thread.Sleep(2000);
    Console.WriteLine("Kanye's coming around again. What will he say next?\n");
    Console.Write(". ");
    Thread.Sleep(500);
    Console.Write(". ");
    Thread.Sleep(500);
    Console.Write(". \n\n");
    Thread.Sleep(2000);
    Console.WriteLine($"Kanye says, '{kanyeQuote}'\n");
    Thread.Sleep(2000);
    Console.WriteLine("Bye Kanye..\n");
}


//Using api key

//Grab appsettings file
var apiKeyObj = File.ReadAllText("appsettings.json");

//Get the api key from the appsettings file using the key "apiKey"
var apiKey = JObject.Parse(apiKeyObj).GetValue("apiKey").ToString();

//Build the api url using the provided zip and api key
var apiURL = $"https://api.openweathermap.org/data/2.5/weather?zip=35091&appid={apiKey}";