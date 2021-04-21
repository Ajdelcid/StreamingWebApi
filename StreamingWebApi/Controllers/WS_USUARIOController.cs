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
    public class WS_USUARIOController : Controller
    {
        IWS_USUARIORepository ws_usuarioRepository;
        public WS_USUARIOController(IWS_USUARIORepository _ws_usuarioRepository)
        {
            ws_usuarioRepository = _ws_usuarioRepository;
        }

        [Route("api/GetWS_USUARIOList")]
        public ActionResult GetWS_USUARIOList()
        {
            var result = ws_usuarioRepository.GetWS_USUARIOList();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("api/GetWS_USUARIODetails/{usId}")]
        public ActionResult GetWS_USUARIODetails(int usId)
        {
            var result = ws_usuarioRepository.GetWS_USUARIODetails(usId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}