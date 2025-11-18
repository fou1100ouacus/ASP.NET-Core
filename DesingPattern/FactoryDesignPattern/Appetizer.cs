using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    public interface  IAppetizer:Idish
    {
    }// any class inherite from this interface must initiate a serve method in idish

    public class chicken : Dish, IAppetizer
    {
        public chicken(string name, string des) : base(name, des) { }


        public void serve() { Console.WriteLine($"chicken {showDetails()}  "); }
    }

    public class Cheese : Dish, IAppetizer
    {
        public Cheese(string name, string des) : base(name, des) { }

        public void serve() { Console.WriteLine($"cheese {showDetails()}  "); }
    }


    public class potatoe : Dish, IAppetizer
    {
        public potatoe(string name, string des) : base(name, des) { }

        

        public void serve() { Console.WriteLine($"potatoe {showDetails()}  "); }
    }



}
