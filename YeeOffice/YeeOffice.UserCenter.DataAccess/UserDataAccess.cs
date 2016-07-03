using System.Collections.Generic;
using System.Linq;
using YeeOffice.Common.DataAccess;
using YeeOffice.UserCenter.Entities;

namespace YeeOffice.UserCenter.DataAccess
{
    public class UserDataAccess : Repository<UserEntity>, IRepository<UserEntity>
    {
        public UserDataAccess(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override void Save(params UserEntity[] entities)
        {
            base.Save(entities);
            UnitOfWork.SaveChanges();
        }

        public IList<UserEntity> GetItems()
        {
            var items = GetAllItems();

            //var updateItem = items.Where(item => item.Id == 3).FirstOrDefault();
            //updateItem.UserName = "bruce.chen1";
            //Save(updateItem);

            //var insertItem = new UserEntity()
            //{
            //    Guid = Guid.NewGuid(),
            //    UserName = "chenwei_9791",
            //    Password = "cw9791",
            //    DisplayName = "Bruce Chen"
            //};
            //Save(insertItem);

            //UnitOfWork.SaveChanges();

            return items;
        }

        public bool Login(string username, string password)
        {
            var items = GetAllItems();
            var user = items.Where(item => item.Account == username).FirstOrDefault();
            if (user == null) return false;

            return user.Password == password;
        }
    }
}
