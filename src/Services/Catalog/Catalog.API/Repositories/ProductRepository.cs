using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        //Khi tạo product repository cần triển khai hàm tạo của Base repository cho product trước
        //để đảm bảo rằng các thuộc tính và phương thức của lớp cha sẽ được khởi tạo trước khi khởi tạo các thuộc tính và phương thức của lớp con
        public ProductRepository(IDBContext dBContext) : base(dBContext.GetProductCollection())
        {

        }
    }
}
