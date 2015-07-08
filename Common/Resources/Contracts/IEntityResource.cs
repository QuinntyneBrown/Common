using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dtos;

namespace Common.Resources.Contracts
{
    public interface IEntityResource<T>
    {
        T GetById(int? id, string authorizationScheme = null, string authorizationToken = null);

        ICollection<T> GetAll(string authorizationScheme = null, string authorizationToken = null);

        PagedResultDto<T> GetPage(int setSize, int offSet, string authorizationScheme = null, string authorizationToken = null);

    }
}
