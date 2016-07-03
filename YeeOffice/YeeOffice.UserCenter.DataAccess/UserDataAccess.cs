using System.Collections.Generic;
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
    }
}
