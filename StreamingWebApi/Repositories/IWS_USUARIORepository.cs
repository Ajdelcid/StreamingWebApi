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

        object GetWS_USUARIOLogin(string usIdC, string usPass);

        object PostWS_USUARIOInsert(int usIdC, string usName, string usSName, string uLastName, string usSLastName, string usEmail, string usPass, string usTel);
    }
}
