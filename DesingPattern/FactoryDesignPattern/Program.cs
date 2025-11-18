
using FactoryDesignPattern;

class Program
{
        public static void Main(string[] args)
        {

        (IMainCourse main, IAppetizer appetizer, IDessert dessert) meal = new ();

      
        
        int choice = 0;
        Console.WriteLine("----------- Appetizer ------------");
        Console.WriteLine(" 1  chicken");
        Console.WriteLine(" 2  cheese");
        Console.WriteLine(" 3  potatoes");
        if (int.TryParse (Console.ReadLine(), out choice))
        {
            switch (choice)//  //chicken Cheese potatoe
            {
                case 1:
                    //  meal.appetizer = new chicken("sdklf", "dasf");
                    meal.appetizer = DishFactory.createAppetizer("chicken");
                    break;
                case 2:
                    //    meal.appetizer = new Cheese("s", "f");
                    meal.appetizer = DishFactory.createAppetizer("Cheese");
                    break;
                case 3:
                   // meal.appetizer = new potatoe("3", "38903");
                    meal.appetizer = DishFactory.createAppetizer("potatoe");

                    break;
             
                default:
                    break;
            }
           
        }

     
        
        
        
        Console.Clear();





        Console.WriteLine("----------- Dessert ------------");
        Console.WriteLine(" 1  chooclate");
        Console.WriteLine(" 2  icecream");
        Console.WriteLine(" 3  mangoice");
        if (int.TryParse(Console.ReadLine(), out choice))
        {
            switch (choice)//
                           //        // chooclate icecreame mangoeice
            {
                case 1:
                    meal.dessert = DishFactory.createdessert("chooclate");

                 //   meal.dessert = new chooclate("sdklf", "dasf");
                    break;
                case 2:
                    //  meal.dessert = new icecreame("jj", "j");
                    meal.dessert = DishFactory.createdessert("icecreame");

                    break;
                case 3:
                    meal.dessert = DishFactory.createdessert("mangoeice");

                 //   meal.dessert = new mangoeice("mongo", "mango");
                    break;

                default:
                    break;
            }

        }

        Console.Clear();



        Console.WriteLine("----------- Main course ------------");
        Console.WriteLine(" 1  steak");
        Console.WriteLine(" 2  molokhyia");
        Console.WriteLine(" 3  grilledchicen");
        if (int.TryParse(Console.ReadLine(), out choice))
        {
            switch (choice)// //steak  molkyia  grilledChicken
            {
                case 1:
                    meal.main = DishFactory.createmain("steak");

                   // meal.main = new steak("steak", "steak");
                    break;
                case 2:
                    meal.main = DishFactory.createmain("molkyia");

                   // meal.main = new molkyia("molykyia", "mok");
                    break;
                case 3:
                    meal.main = DishFactory.createmain("grilledChicken");

               //     meal.main = new grilledChicken("grilled", "chicken");
                    break;

                default:
                    break;
            }

        }

        Console.Clear();


        meal.appetizer?.serve();

        meal.dessert?.serve();
        meal.main?.serve();





    }
}
