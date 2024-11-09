using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services
{
    public interface ICartService
    {

        Task<IEnumerable<object>> GetCartItemsAsync(int customerId);
        Task<string> RemoveCartItemAsync(int cartId);
        Task<string> UpdateCartItemAsync(int cartId, int quantity);
    }
}
