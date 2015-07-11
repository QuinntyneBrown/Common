using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Common.Web.Contracts
{
    public interface IWebApiConfiguration
    {
        void Configure(HttpConfiguration config);
    }
}
