using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StreamingWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace StreamingWebApi.Controllers
{
    [Produces("application/json")]
    public class WS_GENEROController : Controller
    {
        IWS_GENERORepository ws_generoRepository;
        public WS_GENEROController(IWS_GENERORepository _ws_generoRepository)
        {
            ws_generoRepository = _ws_generoRepository;
        }

        [Route("api/GetWS_GENEROList")]
        public ActionResult GetWS_GENEROList()
        {
            var result = ws_generoRepository.GetWS_GENEROList();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("api/GetWS_GENERODetails/{gnId}")]
        public ActionResult GetWS_GENERODetails(int gnId)
        {
            var result = ws_generoRepository.GetWS_GENERODetails(gnId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
