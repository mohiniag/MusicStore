using MusicStore.Models;
using System.Collections.Generic;

namespace MusicStore.Interfaces
{
    interface DatabaseCalls
    {
        List<DataContentsModel> GetAllData(string url);
       
        string RemoveFromCart(int Id);

        string AddToCart(DataContentsModel dataset);
    }
}
