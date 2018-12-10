using MLTP.Infrastructure.DataModels.Models;
using MLTP.Infrastructure.DataModels.RequestModel;
using System;

namespace MLTP.Infrastructure.DataLibrary.Common.UserManagement
{
    public class UserUnitOfWork : IUserUnitOfWork
    {
        private readonly MLTPDataContext _dbContext;

        public UserUnitOfWork(MLTPDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUserDevice(AddUserDeviceRequestModel model)
        {
            _dbContext.MltpUserDevice.Add(new MltpUserDevice
            {
                AppId = model.AppId,
                CreateDate = DateTime.Now,
                PhoneModel = model.PhoneModel,
                PhoneVersion = model.PhoneVersion,
                Platform = model.Platform,
                UserId = model.UserId
            });
            _dbContext.SaveChanges();
        }
    }
}