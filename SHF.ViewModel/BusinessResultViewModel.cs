using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{   
    public class BusinessResultViewModel<TEntity> where TEntity : class
    {
        public System.String Draw { get; set; }
        public System.Int32 RecordsFiltered { get; set; }
        public System.Int32 RecordsTotal { get; set; }
        public IEnumerable<TEntity> Data { get; set; }
    }
}
