using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    public interface IDessert : Idish
    {
    }// any class inherite from this interface must initiate a serve method in idish

    public class chooclate : Dish, IDessert
    {
        public chooclate(string name, string des) : base(name, des) { }


        public void serve() { Console.WriteLine($"chooclate {showDetails()}  "); }
    }


    public class icecreame : Dish, IDessert
    {
        public icecreame(string name, string des) : base(name, des) { }

       
        public void serve() { Console.WriteLine($"icecream {showDetails()}  "); }
    }


    public class mangoeice : Dish, IDessert
    {
        public mangoeice(string name, string des) : base(name, des) { }

      

        public void serve() { Console.WriteLine($"mangoice {showDetails()}  "); }
    }


}
