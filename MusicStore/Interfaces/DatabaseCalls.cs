using MusicStore.Models;
using System.Collections.Generic;

namespace MusicStore.Interfaces
{
    interface DatabaseCalls
    {
        List<DataContentsModel> getAllData(string url);
        string writeData(DataContentsModel dataset);
    }
}
