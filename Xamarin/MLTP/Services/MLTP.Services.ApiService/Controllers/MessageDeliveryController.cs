using Microsoft.AspNetCore.Mvc;
using MLTP.Infrastructure.DataModels;
using MLTP.Infrastructure.MongoDB;
using MLTP.Infrastructure.Queue;
using MLTP.Infrastructure.Queue.DataModels;
using System;

namespace MLTP.Services.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageDeliveryController : Controller
    {
        private IQManager iqManager;
        private IMongoDBService _mongo;

        public MessageDeliveryController(IQManager _iqManager, IMongoDBService mongo)
        {
            iqManager = _iqManager;
            _mongo = mongo;
        }

        [HttpPost]
        [Route("EMailQueue")]
        public ResponseItem EMailQueue(EmailModel model)
        {
            ResponseItem result = new ResponseItem();
            result.Result = true;

            try
            {
                iqManager.EmailSend(model);
                result.Message = "Success";

                AppModel modelMongo = new AppModel
                {
                    Name = model.Subject,
                    Description = "EmailQueue",
                    Date = DateTime.Now
                };
                _mongo.Create(modelMongo);

            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpPost]
        [Route("SmsQueue")]
        public ResponseItem SmsQueue(SmsModel model)
        {
            ResponseItem result = new ResponseItem();
            result.Result = true;

            try
            {
                iqManager.SmsSend(model);
                result.Message = "Success";

                AppModel modelMongo = new AppModel
                {
                    Name = model.Message,
                    Description = "SmsQueue",
                    Date = DateTime.Now
                };
                _mongo.Create(modelMongo);
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}