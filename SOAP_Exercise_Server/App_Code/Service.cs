using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Configuration;
using System.Xml;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
	private static readonly HttpClient client = new HttpClient();
	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}

	public int Add(int a, int b)
	{
		return a + b;
	}

    public async Task<PictureDTO[]> GetPictures(string query)
    {
		var doc = new XmlDocument();
		var appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		doc.Load(appdata + @"\Microsoft\UserSecrets\SI_MP1_SOAP\secrets.xml");
		var APIKey = doc.DocumentElement.SelectSingleNode("secrets/secret").InnerText;
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

		return await Task.FromResult(pictureDTOs.ToArray());
	}
}
