using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Common.Services.Contracts
{
    public interface IGenericRESTService<TRequestDto, TResponseDto> 
    {
        TResponseDto Add(TRequestDto dto);

        TResponseDto GetById(int id);

        ICollection<TResponseDto> GetAll();

    }
}
