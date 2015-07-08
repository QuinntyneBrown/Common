using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Dtos;

namespace Common.Services.Contracts
{
    public interface IFileUploadService
    {
        Task<List<FileDto>> Upload(System.Net.Http.HttpRequestMessage Request);
    }
}
