using Microsoft.AspNetCore.Mvc;
using N5ChallengeFullStack.Common;
using N5ChallengeFullStack.Dto;
using N5ChallengeFullStack.Model;
using N5ChallengeFullStack.Service;

namespace N5ChallengeFullStack.Controllers
{
    [ApiController]
    [Route("api/permissiontype")]
    public class PermissionTypeController : ControllerBase
    {
        private readonly PermissionTypeService _Service;
        public PermissionTypeController(PermissionTypeService _service)
        {
            _Service = _service;
        }
        [HttpPost(CommonAction.ADD)]
        public ActionResult add(PermissionTypeDto _entity)
        {
            return Ok(_Service.AddEntity(_entity));
        }
        [HttpGet(CommonAction.GET_SINGLE)]
        public ActionResult getSingle(long _id)
        {
            return Ok(_Service.GetSingle(_id));
        }
        [HttpPut(CommonAction.UPDATE)]
        public ActionResult Update(PermissionTypeDto _entity)
        {
            return Ok(_Service.UpdateEntity(_entity));

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
