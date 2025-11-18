using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{

    public interface IMainCourse : Idish
    {
    }// any class inherite from this interface must initiate a serve method in idish

    public class steak : Dish, IMainCourse
    {
        public steak(string name, string des) : base(name, des) { }


        public void serve() { Console.WriteLine($"steak {showDetails()}  "); }
    }


    public class molkyia : Dish, IMainCourse
    {
        public molkyia(string name, string des) : base(name, des) { }

       
        public void serve() { Console.WriteLine($"molkyia {showDetails()}  "); }
    }


    public class grilledChicken : Dish, IMainCourse
    {
        public grilledChicken(string name, string des) : base(name, des) { }

      

        public void serve() { Console.WriteLine($"grilledChicen {showDetails()}  "); }
    }


}
