using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicFilterCore
{
    public class Item
    {
        public dynamic Value { get; set; }
        public OperatorName Operator { get; set; }
        public string Property { get; set; }
        public string Type { get; set; }
        public bool IsList { get; set; }
        public bool Exclude { get; set; }

    }
}
