using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.Helper
{
    public class PaggedObjectList<T>
    {
        public IEnumerable<T> ItemList;
        public int Count { get; set; }
    }
}
