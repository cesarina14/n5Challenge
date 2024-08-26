using Microsoft.AspNetCore.Mvc;
using N5ChallengeFullStack.Common;
using N5ChallengeFullStack.Dto;
using N5ChallengeFullStack.Model;
using N5ChallengeFullStack.Service;

namespace N5ChallengeFullStack.Controllers
{
    [ApiController]
    [Route("api/permission")]
    public class PermissionController : ControllerBase
    {
        private readonly PermissionService _Service;
        public PermissionController(PermissionService _service)
        {
            _Service = _service;
        }
        [HttpPost(CommonAction.ADD)]
        public ActionResult add(PermissionDto _entity)
        {
            return Ok(_Service.Add(_entity));
        }
        [HttpGet(CommonAction.GET_SINGLE)]
        public ActionResult getSingle(long _id)
        {
            return Ok(_Service.GetSingle(_id));
        }
        [HttpPut(CommonAction.UPDATE)]
        public ActionResult Update(PermissionDto _entity)
        {
            return Ok(_Service.UpdateEntityAsync(_entity));

        }
        [HttpPut(CommonAction.REMOVE)]
        public ActionResult Remove(long _id)
        {
            return Ok(_Service.Remove(_id));
        }
        [HttpGet(CommonAction.LIST)]
        public ActionResult List()
        {
            return Ok(_Service.GetList());
        }
    }
}
