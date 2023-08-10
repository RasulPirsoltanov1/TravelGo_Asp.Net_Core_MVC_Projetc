using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Abstract
{
    public interface IDestinationService : IGenericService<Destination>
    {
        Destination GetDestinationWithGuide(Expression<Func<Destination, bool>> expression);
        List<Destination> GetLastDestinations(int take);
    }
}
