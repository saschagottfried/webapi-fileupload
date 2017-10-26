using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApiFileUpload.API.Models;

namespace WebApiFileUpload.DesktopClient
{
    internal class ApiClient
    {
        private readonly HttpClient httpClient;

        public ApiClient()
            : this(ConfigurationManager.AppSettings.Get("uploadServiceBaseAddress"))
        {
        }

        public ApiClient(string baseAddress)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
        }

        public async Task<FileUploadResult> UploadFileAsync(string pathToFile)
        {
            var fileStream = File.OpenRead(pathToFile);
            var fileName = Path.GetFileName(pathToFile);

            var content = new MultipartFormDataContent();
            content.Add(new StreamContent(fileStream), "\"file\"", string.Format("\"{0}\"", fileName)
            );

            var response = await httpClient.PostAsync("api/fileupload", content);
            if (!response.IsSuccessStatusCode)
            {
                Debug.WriteLine("File upload was not successful.");
                Debug.WriteLine("Status Code: {0} - {1}", response.StatusCode, response.ReasonPhrase);
                Debug.WriteLine("Response Body: {0}", await response.Content.ReadAsStringAsync());
            }

            // Read other header values if you want ...
            foreach (var header in response.Content.Headers)
            {
                Debug.WriteLine("{0}: {1}", header.Key, string.Join(",", header.Value));
            }

            // Process response
            var fileUploadResult = await response.Content.ReadAsAsync<FileUploadResult>();

            return fileUploadResult;
        }
    }
}
