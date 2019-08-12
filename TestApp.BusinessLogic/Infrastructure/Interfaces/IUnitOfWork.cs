namespace TestApp.BusinessLogic.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        void SaveChagnes();
    }
}
