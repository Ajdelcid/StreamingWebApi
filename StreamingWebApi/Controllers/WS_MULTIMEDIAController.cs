
using StreamingWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace StreamingWebApi.Controllers
{
    public class WS_MULTIMEDIAController : Controller
    {
        IWS_MULTIMEDIARepository ws_multimediaRepository;
        public WS_MULTIMEDIAController(IWS_MULTIMEDIARepository _ws_multimediaRepository)
        {
            ws_multimediaRepository = _ws_multimediaRepository;
        }

        [Route("api/GetWS_MULTIMEDIAList")]
        public ActionResult GetWS_MULTIMEDIAList()
        {
            var result = ws_multimediaRepository.GetWS_MULTIMEDIAList();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("api/GetWS_MULTIMEDIADetails/{muId}")]
        public ActionResult GetWS_MULTIMEDIADetails(int muId)
        {
            var result = ws_multimediaRepository.GetWS_MULTIMEDIADetails(muId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
