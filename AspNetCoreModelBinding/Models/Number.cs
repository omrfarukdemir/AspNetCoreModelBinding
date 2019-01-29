
using AspNetCoreModelBinding.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreModelBinding.Models
{
    //[ModelBinder(typeof(NumberBinder))]
    public class Number
    {
        public int First { get; set; }
        public int Second { get; set; }

        public Operation Op { get; set; }
        public Number(int first, int second,Operation op)
        {
            First = first;
            Second = second;
            Op = op;
        }
    }

    public class Operation
    {
        public bool Add { get; set; }
        public bool Double { get; set; }
    }
}
