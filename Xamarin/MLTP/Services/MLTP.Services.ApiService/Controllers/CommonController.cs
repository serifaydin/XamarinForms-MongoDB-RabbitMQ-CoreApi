using Microsoft.AspNetCore.Mvc;
using MLTP.Infrastructure.DataModels;
using MLTP.Infrastructure.DataModels.RequestModel;
using MLTP.Infrastructure.DataModels.ResponseModel.Common;
using MLTP.Modules.Common.Common.Contracts;

namespace MLTP.Services.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ICommonLoginWorkFlow _commonWf;
        private readonly IUserWorkFlow _userWf;

        public CommonController(ICommonLoginWorkFlow commonWf, IUserWorkFlow userWf)
        {
            _commonWf = commonWf;
            _userWf = userWf;
        }

        [HttpGet]
        [Route("login/{userName}/{password}")]
        public ResponseItem Login(string userName, string password)
        {
            ResponseItem result = new ResponseItem();

            result.Result = true;
            try
            {
                result.Data = _commonWf.Authenticate(userName, password);
                if (result.Data == null)
                {
                    result.Result = false;
                    result.Data = new AuthenticateModel();
                }
                result.Message = "Success";
            }
            catch (System.Exception ex)
            {
                result.Result = false;
                result.Message = ex.Message;
            }

            return result;
        }

        [HttpPost]
        [Route("AddUserDevice")]
        public ResponseItem AddUserDevice(AddUserDeviceRequestModel model)
        {
            ResponseItem result = new ResponseItem();

            result.Result = true;
            try
            {
                _userWf.AddUserDevice(model);
                result.Message = "Success";
            }
            catch (System.Exception ex)
            {
                result.Result = false;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}