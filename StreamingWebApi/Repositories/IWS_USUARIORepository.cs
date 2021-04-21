using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingWebApi.Repositories
{
    public interface IWS_USUARIORepository
    {
        object GetWS_USUARIOList();

        object GetWS_USUARIODetails(int usId);
    }
}
