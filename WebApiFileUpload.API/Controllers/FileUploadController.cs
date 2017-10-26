using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiFileUpload.API.Infrastructure;
using WebApiFileUpload.API.Models;

namespace WebApiFileUpload.API.Controllers
{
    public class FileUploadController : ApiController
    {
        [MimeMultipart]
        [ResponseType(typeof(FileUploadResult))]
        public async Task<IHttpActionResult> PostAsync()
        {
            var uploadPath = HttpContext.Current.Server.MapPath("~/Uploads");
            var multipartFormDataStreamProvider = new UploadMultipartFormProvider(uploadPath);

            // Read the MIME multipart asynchronously
            await Request.Content.ReadAsMultipartAsync(multipartFormDataStreamProvider);

            // Create response
            return Ok(multipartFormDataStreamProvider.GetFileUploadResult());
        }
    }
}
