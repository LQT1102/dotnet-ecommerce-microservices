using Catalog.API.Entities;

namespace Catalog.API.Repositories
{
    //Việc kế thừa IRepository<Product> là cần thiết vì nếu không, khi inject IProductRepository ở 1 service, sẽ bị thiếu các phương thức trong IRepository
    //mặc dù ProductRepository đã có phần triển khai nó (khi ProductRepository đã kế thừa Repository<Product>)
    public interface IProductRepository : IRepository<Product>
    {
        
    }
}
