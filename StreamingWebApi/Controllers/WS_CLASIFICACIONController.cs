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
    public class WS_CLASIFICACIONController : Controller
    {
        IWS_CLASIFICACIONRepository ws_usuarioRepository;
        public WS_CLASIFICACIONController(IWS_CLASIFICACIONRepository _ws_usuarioRepository)
        {
            ws_usuarioRepository = _ws_usuarioRepository;
        }

        [Route("api/GetWS_CLASIFICACIONList")]
        public ActionResult GetWS_CLASIFICACIONList()
        {
            var result = ws_usuarioRepository.GetWS_CLASIFICACIONList();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("api/GetWS_CLASIFICACIONDetails/{clId}")]
        public ActionResult GetWS_CLASIFICACIONDetails(int clId)
        {
            var result = ws_usuarioRepository.GetWS_CLASIFICACIONDetails(clId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}