using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Interfaces
{
    interface DatabaseCalls
    {
        List<DataContentsModel> getAllData(string url);
        string writeData(DataContentsModel dataset);
    }
}
