using de_1_codeFirst.Data;

namespace de_1_codeFirst.Repository
{
    public class ProductRepo
    {
        private readonly ProductDbContext db;
        public ProductRepo(ProductDbContext db)
        {
            this.db = db;
        }


    }
}
