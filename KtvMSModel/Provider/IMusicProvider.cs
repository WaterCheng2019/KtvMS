using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtvMSModel
{
    public interface IMusicProvider
    {
        string Name { get; }
        string getDownloadUrl(Song1 song);
        List<Song1> SearchSongs(string keyword,int page,int pageSize);
    }
}
