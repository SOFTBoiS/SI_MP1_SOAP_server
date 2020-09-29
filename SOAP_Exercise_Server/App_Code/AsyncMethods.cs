using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;


/// <summary>
/// Summary description for Class1
/// </summary>
public class AsyncMethods
{
    private static readonly HttpClient client = new HttpClient();

	public static async System.Threading.Tasks.Task<PictureDTO[]> GetPicturesAsync(string query)
	{
		Console.WriteLine("Hello");
		string APIKey = "563492ad6f917000010000011f7173f386214f4dafc6ffcec257ce89";
		var uri = "https://api.pexels.com/v1/search?query=" + query + "&per_page=10";
		List<PictureDTO> pictureDTOs = new List<PictureDTO>();

		try
		{
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", APIKey);
			HttpResponseMessage response = await client.GetAsync(uri);
			response.EnsureSuccessStatusCode();
			string responseBody = await response.Content.ReadAsStringAsync();
			// Above three lines can be replaced with new helper method below
			// string responseBody = await client.GetStringAsync(uri);

			// Console.WriteLine(PrettyJson(responseBody));

			JObject rss1 = JObject.Parse(responseBody);
			JArray photos = (JArray)rss1["photos"];


			foreach (var photo in photos)
			{
				var photoUrl = (string)photo["src"]["original"];
				var width = (string)photo["width"];
				var height = (string)photo["height"];

				pictureDTOs.Add(new PictureDTO(photoUrl, width, height));
			}

		}
		catch (HttpRequestException e)
		{
			Console.WriteLine("\nException Caught!");
			Console.WriteLine("Message :{0} ", e.Message);
		}

		return pictureDTOs.ToArray();
	}
}