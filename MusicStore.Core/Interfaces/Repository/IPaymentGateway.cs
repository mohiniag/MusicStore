using MusicStore.Core.Models;

namespace MusicStore.Core.Interfaces.Repository
{
   public interface IPaymentGateway
    {
        void FetchedCustomerDetails(CustomerDetails customerDetails);
    }
}
