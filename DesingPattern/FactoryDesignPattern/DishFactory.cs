using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    public class DishFactory
    {//    //chicken Cheese potatoe

        public static IAppetizer createAppetizer(string dishType)
        {
            return dishType switch
            {
                "chicken" => new chicken("sdklf", "dasf"),
                "Cheese" => new Cheese("s", "f"),
                "potatoe" => new potatoe("3", "38903"),
                _ => throw new ArgumentOutOfRangeException()
            };
        
        
        }
        //        // chooclate icecreame mangoeice

        public static IDessert createdessert(string dishType)
        {
            return dishType switch
            {
                "chooclate" => new chooclate("choc", "dasf"),
                "icecreame" => new icecreame("ice", "f"),
                "mangoeice" => new mangoeice("mango", "38903"),
                _ => throw new ArgumentOutOfRangeException()
            };


        }

        public static IMainCourse createmain(string dishType)
        {//        //steak  molkyia  grilledChicken

            return dishType switch
            {
                "steak" => new steak("steak", "dasf"),
                "molkyia" => new molkyia("molkyia", "f"),
                "grilledChicken" => new grilledChicken("grilledChicken", "38903"),
                _ => throw new ArgumentOutOfRangeException()
            };


        }




    }
}
