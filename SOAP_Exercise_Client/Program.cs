using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SOAP_Exercise_Client
{
    class Program
    {
		static readonly HttpClient client = new HttpClient();

		static async System.Threading.Tasks.Task Main(string[] args)
        {
			//ServiceReference1.ServiceClient test = new ServiceReference1.ServiceClient();

			//var result = test.add(1, 2);

			//Console.WriteLine(result);

			//NetworkCredential myCred = new NetworkCredential(SecurelyStoredUserName, SecurelyStoredPassword, SecurelyStoredDomain);

			//CredentialCache myCache = new CredentialCache();

			//myCache.Add(new Uri("www.contoso.com"), "Basic", myCred);
			//myCache.Add(new Uri("app.contoso.com"), "Basic", myCred);

			//WebRequest wr = WebRequest.Create("www.contoso.com");
			//wr.Credentials = myCache;


			string APIKey = "563492ad6f917000010000011f7173f386214f4dafc6ffcec257ce89";
			string query = "monkey";
			var uri = "https://api.pexels.com/v1/search?query=" + query + "&per_page=10";



			//// Create a request for the URL.
			//WebRequest request = WebRequest.Create(uri);
			//// If required by the server, set the credentials.
			//request.Credentials = CredentialCache.DefaultCredentials;

			//// Get the response.
			//WebResponse response = request.GetResponse();
			//// Display the status.
			//Console.WriteLine(((HttpWebResponse)response).StatusDescription);

			//// Get the stream containing content returned by the server.
			//// The using block ensures the stream is automatically closed.
			//using (Stream dataStream = response.GetResponseStream())
			//{
			//	// Open the stream using a StreamReader for easy access.
			//	StreamReader reader = new StreamReader(dataStream);
			//	// Read the content.
			//	string responseFromServer = reader.ReadToEnd();
			//	// Display the content.
			//	Console.WriteLine(responseFromServer);
			//}

			//// Close the response.
			//response.Close();

			try
			{
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", APIKey);
				HttpResponseMessage response = await client.GetAsync(uri);
				response.EnsureSuccessStatusCode();
				string responseBody = await response.Content.ReadAsStringAsync();
				// Above three lines can be replaced with new helper method below
				// string responseBody = await client.GetStringAsync(uri);

				Console.WriteLine(responseBody);
			}
			catch (HttpRequestException e)
			{
				Console.WriteLine("\nException Caught!");
				Console.WriteLine("Message :{0} ", e.Message);
			}
		}


    }
}
