using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class CategoryDAO
    {
        private TranDuyNhanContext dbContext;
        public CategoryDAO()
        {
            dbContext = new TranDuyNhanContext();
        }
        public List<Category> ListAll()
        {
            return dbContext.Categories.ToList();
        }
    }
}
