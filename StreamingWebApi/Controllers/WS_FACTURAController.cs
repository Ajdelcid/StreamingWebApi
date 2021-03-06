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
    public class WS_FACTURAController : Controller
    {
        IWS_FACTURARepository ws_facturaRepository;
        public WS_FACTURAController(IWS_FACTURARepository _ws_facturaRepository)
        {
            ws_facturaRepository = _ws_facturaRepository;
        }

        [Route("api/GetWS_FACTURAList")]
        public ActionResult GetWS_FACTURAList()
        {
            var result = ws_facturaRepository.GetWS_FACTURAList();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("api/GetWS_FACTURADetails/{clId}")]
        public ActionResult GetWS_FACTURADetails(int fcId)
        {
            var result = ws_facturaRepository.GetWS_FACTURADetails(fcId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}