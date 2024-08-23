using Microsoft.AspNetCore.Mvc;
using N5ChallengeFullStack.Common;
using N5ChallengeFullStack.Model;
using N5ChallengeFullStack.Service;

namespace N5ChallengeFullStack.Controllers
{
    public class PermissionController : ControllerBase
    {
        private readonly PemissionService _Service;
        public PermissionController(PemissionService _service)
        {
            _Service = _service;
        }
        [HttpPost(CommonAction.ADD)]
        public ActionResult add(Permission _entity)
        {
            return Ok(_Service.AddEntity(_entity));
        }
        [HttpGet(CommonAction.GET_SINGLE)]
        public ActionResult getSingle(long _id)
        {
            return Ok(_Service.GetSingle(_id));
        }
        [HttpPut(CommonAction.UPDATE)]
        public ActionResult Update(Permission _entity)
        {
            return Ok(_Service.UpdateEntity(_entity));

        }
        [HttpPut(CommonAction.REMOVE)]
        public ActionResult Remove(long _id)
        {
            return Ok(_Service.Remove(_id));
        }
    }
}
