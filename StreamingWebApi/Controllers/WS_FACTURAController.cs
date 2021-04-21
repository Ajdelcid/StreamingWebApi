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
        IWS_FACTURARepository ws_usuarioRepository;
        public WS_FACTURAController(IWS_FACTURARepository _ws_usuarioRepository)
        {
            ws_usuarioRepository = _ws_usuarioRepository;
        }

        [Route("api/GetWS_FACTURAList")]
        public ActionResult GetWS_FACTURAList()
        {
            var result = ws_usuarioRepository.GetWS_FACTURAList();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("api/GetWS_FACTURADetails/{clId}")]
        public ActionResult GetWS_FACTURADetails(int clId)
        {
            var result = ws_usuarioRepository.GetWS_FACTURADetails(clId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}