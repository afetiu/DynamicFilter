using DynamicFilterCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace DynamicFilter
{
    public static class ExtensionMethods
    {
        public static FilteredData<T> Filter<T>(this IQueryable<T> query, Filter filter, LogicalOperation logicalOperation = LogicalOperation.And, string orderByField = "Id", OrderingDirection orderingDirection = OrderingDirection.Descending)
        {
            var predicate = BuildQuery(filter.Items, logicalOperation);
            query = string.IsNullOrEmpty(predicate) ? query : query.AsQueryable().Where(predicate);

            IQueryable<T> pagedQuery = query.AsQueryable()
                .OrderBy(orderByField + " " + orderingDirection)
                .Skip(filter.Skip)
                .Take((filter.Take)); 


            return new FilteredData<T> { Data = pagedQuery, Count = query.Count() };
        }

        public static string BuildQuery(List<Item> filters, LogicalOperation logicalOperation = LogicalOperation.And)
        {
            string query = "";
            var filledFilters = filters.Where(a => a.Value != null && a.Value.ToString() != "" && !a.Exclude).ToList();

            for (int i = 0; i < filledFilters.Count(); i++)
            {
                var item = filledFilters[i];
                var op = BuildOperator(item.Operator);

                if (item.IsList)
                {
                    string[] propertyString = item.Property.Split(".");


                    query += string.Format(" {0} {1}.Any(a=>a.{2}{3}{4}{5} ) ",
                        i == 0 ? "" : logicalOperation.ToString(),
                        propertyString.First(),
                        propertyString.Last(),
                        op.Begin,
                        item.Value,
                        op.End);

                }
                else query += string.Format(" {0} {1}{2}{3}{4}",
                    i == 0 ? "" : logicalOperation.ToString(),
                    item.Property,
                    op.Begin,
                    item.Value,
                    op.End);
            }

            return query;
        }

        public static Operator BuildOperator(OperatorName op)
        {
            var result = new Operator();


            switch (op)
            {
                case OperatorName.Equal:
                    {
                        result.Begin = "=\"";
                        result.End = "\"";
                    }
                    break;
                case OperatorName.NotEqual:
                    {
                        result.Begin = "!=\"";
                        result.End = "\"";
                    }
                    break;
                case OperatorName.Greater:
                    {
                        result.Begin = ">\"";
                        result.End = "\"";
                    }
                    break;
                case OperatorName.Less:
                    {
                        result.Begin = "<\"";
                        result.End = "\"";
                    }

                    break;
                case OperatorName.EqualOrGreater:
                    {
                        result.Begin = ">=\"";
                        result.End = "\"";
                    }
                    break;
                case OperatorName.EqualOrLess:
                    {
                        result.Begin = "<=\"";
                        result.End = "\"";
                    }

                    break;
                case OperatorName.Contains:
                    {
                        result.Begin = ".Contains(\"";
                        result.End = "\")";
                    }
                    break;
                case OperatorName.StartsWith:
                    {
                        result.Begin = ".StartsWith(\"";
                        result.End = "\")";
                    }
                    break;
                case OperatorName.EndsWith:
                    {
                        result.Begin = ".EndsWith(\"";
                        result.End = "\")";
                    }
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
