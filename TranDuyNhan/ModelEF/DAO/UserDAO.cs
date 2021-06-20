using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class UserDAO
    {
        private TranDuyNhanContext dbContext;
        public UserDAO()
        {
            dbContext = new TranDuyNhanContext();
        }
        public IEnumerable<UserAccount> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<UserAccount> model = dbContext.UserAccounts;

            if (!string.IsNullOrEmpty(keysearch))
                return model.Where(x => x.Username.Contains(keysearch)).OrderBy(x => x.ID).ToPagedList(page, pagesize);
            return model.OrderBy(x => x.ID).ToPagedList(page, pagesize);
        }
        public void Delete(int id)
        {
            var model = dbContext.UserAccounts.Where(x => x.ID == id).FirstOrDefault();
            dbContext.UserAccounts.Remove(model);
            dbContext.SaveChanges();
        }
        public bool Find(UserAccount user)
        {
            var result = dbContext.UserAccounts.SingleOrDefault(x => x.Username.Contains(user.Username) && x.Password.Contains(user.Password));
            if (result != null)
            {
                return true;
            }
            return false;
        }
    }
}
