using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingWebApi.Repositories
{
    public interface IWS_MULTIMEDIARepository
    {
        object GetWS_MULTIMEDIAList();

        object GetWS_MULTIMEDIADetails(int muId);
    }
}
