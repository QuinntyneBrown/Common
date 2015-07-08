using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Common.Dtos;
using Common.Services.Contracts;
using Common.Stream;

namespace Common.Services
{
    public class FileUploadService : IFileUploadService
    {
        public async Task<List<FileDto>> Upload(System.Net.Http.HttpRequestMessage Request)
        {
            var fileDtos = new List<FileDto>();

            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var provider = await Request.Content.ReadAsMultipartAsync<InMemoryMultipartFormDataStreamProvider>(new InMemoryMultipartFormDataStreamProvider());

            NameValueCollection formData = provider.FormData;
            IList<HttpContent> files = provider.Files;

            foreach (var file in files)
            {
                var filename = new FileInfo(file.Headers.ContentDisposition.FileName.Trim(new char[] {'"'})
                    .Replace("&", "and")).Name;

                System.IO.Stream stream = await file.ReadAsStreamAsync();

                var bytes = StreamHelper.ReadToEnd(stream);

                var fileDto = new FileDto();
                fileDto.Filename = filename;
                fileDto.Bytes = bytes;
                fileDto.ContentType = Convert.ToString(file.Headers.ContentType);

                fileDtos.Add(fileDto);
            }

            return fileDtos;
        }
    }
}
