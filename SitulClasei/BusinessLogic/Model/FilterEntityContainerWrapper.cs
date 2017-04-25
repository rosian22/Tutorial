using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Model
{
    public class FilterEntityContainerWrapper<T> where T : class, ISinglePkModel, new()
    {
        public IList<EntityContainer<T>> EntityContainers { get; set; }

        public int TotalItems { get; set; }
    }
}
