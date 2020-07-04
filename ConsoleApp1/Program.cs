using DynamicFilter;
//using DynamicFilterCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using UtilsCore.DynamicFilter;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            var Goals = new List<Goal>
            {
                new Goal { Id = 1, Title = "hellowdkasmdasd", Description = "sdsnvd k sd" , Active = true},
                new Goal { Id = 2, Title = "ksasksksks c s skcs k skc", Description = "aaaaa k sd", Active = true , Projects = new List<Project>()},
                new Goal { Id = 3, Title = "kdvsd kd s", Description = "vvv k sd", Projects = new List<Project>() }
            };


            //var filters = new List<Item>
            //{

            //      new Item
            //    {
            //        Value = 1,
            //        //IsList = true,
            //        Property = "Id",
            //        Operator = OperatorName.Equal
            //    }
            //};

            //var filter = new Filter
            //{
            //    Skip = 0,
            //    Take = 10
            //};

            //filter.Items = new List<Item>();
            //filter.Items.AddRange(filters);

            //FilteredData<Goal> test = Goals.Filter(filter);
            //var data = test.Data.FirstOrDefault();


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

        public int score = 0;
        public int speed = 30;
        public int level = 1;
        public int step = 100; 
        public int target = 100;

        public void HitElementChecker(int score)
        {
            if (score >= target)
            {
                target += step; 
                level++;
                speed += 3;
            } 
        }

       
    }

    public class Project
    {
        public int Id { get; set; }
    }
}
