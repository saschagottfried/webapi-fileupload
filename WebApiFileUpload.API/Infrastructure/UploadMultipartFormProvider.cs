using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace WebApiFileUpload.API.Infrastructure
{
    public class UploadMultipartFormProvider : MultipartFormDataStreamProvider
    {
        public UploadMultipartFormProvider(string rootPath) : base(rootPath) { }

        /// <summary>
        /// this is here because Chrome submits files in quotation marks which get treated as part of the filename and get escaped
        /// https://www.strathweb.com/2012/08/a-guide-to-asynchronous-file-uploads-in-asp-net-web-api-rtm/
        /// </summary>
        /// <param name="headers"></param>
        /// <returns></returns>
        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            if (headers != null &&
                headers.ContentDisposition != null)
            {
                return headers
                    .ContentDisposition
                    .FileName.TrimEnd('"').TrimStart('"');
            }

            return base.GetLocalFileName(headers);
        }

        public IEnumerable<FileUploadResult> GetFileUploadResults()
        {
            var results = this.FileData.Select(fileData => new FileUploadResult
            {
                LocalFilePath = fileData.LocalFileName,
                FileName = Path.GetFileName(fileData.LocalFileName),
                FileLength = new FileInfo(fileData.LocalFileName).Length
            });

            return results;
        }

        public FileUploadResult GetFileUploadResult()
        {
            var result = this.FileData.Select(fileData => new FileUploadResult
            {
                LocalFilePath = fileData.LocalFileName,
                FileName = Path.GetFileName(fileData.LocalFileName),
                FileLength = new FileInfo(fileData.LocalFileName).Length
            }).FirstOrDefault();

            return result;
        }
    }
}