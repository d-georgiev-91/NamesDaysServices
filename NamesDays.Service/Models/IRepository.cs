namespace NamesDays.Service.Models
{
    using System.Linq;

    public interface IRepository<T>
    {
        IQueryable<T> All();

        T Get(int id);
    }
}
