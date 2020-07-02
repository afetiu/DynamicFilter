using DynamicFilter;
using DynamicFilterCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var Goals = new List<Goal>
            {
                new Goal { Id = 1, Title = "hellowdkasmdasd", Description = "sdsnvd k sd" , Active = true},
                new Goal { Id = 2, Title = "ksasksksks c s skcs k skc", Description = "aaaaa k sd", Active = true , Projects = new List<Project>()},
                new Goal { Id = 3, Title = "kdvsd kd s", Description = "vvv k sd", Projects = new List<Project>() }
            };


            var filters = new List<Item>
            {
                new Item
                {
                    Value = "hello",
                    Property = "Title",
                    Operator = OperatorName.Contains
                },

                  new Item
                {
                    Value = 1,
                    IsList = true,
                    Property = "Projects.Id",
                    Operator = OperatorName.Equal
                }
            };

            var filter = new Filter
            {
                Skip = 0,
                Take = 10
            };

            filter.Items = new List<Item>();
            filter.Items.AddRange(filters);

            var test = Goals.Filter(filter);
            var data = test.Data.FirstOrDefault();


        }
    }
    public class Goal
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
        public List<Project> Projects { get; set; }
    }

    public class Project
    {
        public int Id { get; set; }
    }
}
