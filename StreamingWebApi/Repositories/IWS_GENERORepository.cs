using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingWebApi.Repositories
{
    public interface IWS_GENERORepository
    {
        object GetWS_GENEROList();

        object GetWS_GENERODetails(int gnId);
    }
}
