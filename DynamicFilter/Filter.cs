using System.Collections.Generic;

namespace DynamicFilterCore
{
    public class Filter
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public List<Item> Items { get; set; }

     
    }
    
    public enum OrderingDirection
    {
        Ascending = 1,
        Descending = -1
    }

    public enum LogicalOperation
    {
        And = 1,
        Or
    }
}
