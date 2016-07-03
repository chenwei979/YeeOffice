using System;
using System.Collections.Generic;
using YeeOffice.UserCenter.DataAccess;
using YeeOffice.UserCenter.Entities;

namespace YeeOffice.UserCenter.BusnissLogic
{
    public class UserBusnissLogic : IDisposable
    {
        public UserDataAccess DataAccess { get; set; }

        public UserBusnissLogic(UserDataAccess dataAccess)
        {
            DataAccess = dataAccess;
        }

        public void Save(params UserEntity[] entities)
        {
            DataAccess.Save(entities);
        }

        public bool Login(string username, string password)
        {
            return DataAccess.Login(username, password);
        }

        public void GetItemById(long id)
        {
            DataAccess.GetItemById(id);
        }

        public IList<UserEntity> GetAllItems()
        {
            return DataAccess.GetAllItems();
        }

        public void Dispose()
        {
            DataAccess.Dispose();
        }
    }
}
