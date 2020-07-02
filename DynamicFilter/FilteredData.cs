using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicFilterCore
{
    public class FilteredData<T>
    {
        public IQueryable<T> Data { get; set; }
        public int Count { get; set; }

    }
}
