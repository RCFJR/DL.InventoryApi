using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace DL.InventoryApi.Controllers
{
    public class UploadController : ApiController
    {
        public async Task<HttpResponseMessage> Post()
        {
            string fileSaveLocation = HttpContext.Current.Server.MapPath("~/Images/UserProfile/");
            CustomMultipartFormDataStreamProvider provider = new CustomMultipartFormDataStreamProvider(fileSaveLocation);
            List<string> files = new List<string>();
            try
            {
                // Ler conteúdo da requisição para CustomMultipartFormDataStreamProvider. 
                await Request.Content.ReadAsMultipartAsync(provider);
                string id_user = provider.FormData.GetValues(0).FirstOrDefault() + "_";
                
                foreach (MultipartFileData file in provider.FileData)
                {
                    files.Add(Path.GetFileName(file.LocalFileName));
                    System.IO.File.Move(file.LocalFileName, fileSaveLocation+id_user + "profile.jpg");
                }
                // OK se tudo deu certo.
                return Request.CreateResponse(HttpStatusCode.OK, files);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }

    public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public CustomMultipartFormDataStreamProvider(string path) : base(path) { }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            return headers.ContentDisposition.FileName.Replace("\"", string.Empty);
        }
    }
}
