using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicFilterCore
{
    public class Operator
    {
        public OperatorName Name { get; set; }
        public string Begin { get; set; }
        public string End { get; set; }

    }
}

public enum OperatorName
{
    Equal,
    NotEqual,
    Greater,
    Less,
    EqualOrGreater,
    EqualOrLess,
    Contains,
    StartsWith,
    EndsWith
}
 