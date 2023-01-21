using System.Collections.Generic;

namespace ShoppingList.Services
{
    public interface IProvider<T>
    {
        IEnumerable<T> Provide();
    }
}
