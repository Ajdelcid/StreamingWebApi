using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingWebApi.Repositories
{
    public interface IWS_FACTURARepository
    {
        object GetWS_FACTURAList();

        object GetWS_FACTURADetails(int fcId);
    }
}
