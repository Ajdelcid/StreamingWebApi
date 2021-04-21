using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingWebApi.Repositories
{
    public interface IWS_CLASIFICACIONRepository
    {
        object GetWS_CLASIFICACIONList();

        object GetWS_CLASIFICACIONDetails(int clId);
    }
}
