using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace ModelEF.DAO
{
    public  class ProductDAO
    {
        private TranDuyNhanContext dbContext;
        public ProductDAO()
        {
            dbContext = new TranDuyNhanContext();
        }
        public IEnumerable<Product> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<Product> model = dbContext.Products;

            if (!string.IsNullOrEmpty(keysearch))
                return model.Where(x => x.Name.Contains(keysearch)).OrderBy(x => x.Quantity).ThenByDescending(x => x.UnitCost).ToPagedList(page, pagesize);
            return model.OrderBy(x => x.Quantity).ThenByDescending(x => x.UnitCost).ToPagedList(page, pagesize);
        }
        public Product Find(string masp)
        {
            return dbContext.Products.Where(x => x.ID.Contains(masp)).FirstOrDefault();
        }
        public void Create(Product pr)
        {
            dbContext.Products.Add(pr);
            dbContext.SaveChanges();
        }
    }
}
