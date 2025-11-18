using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    public interface Idish
    {
        void serve();

    }
    public abstract class Dish
    {
        public string Name { get; set; }
        public  string Description { get; set; }

        public Dish(string name,string desc) 
        {
            Name = name;
            Description = desc;
        
        }
       
        protected string showDetails()
        {
            return $" name = {Name} ,   description = {Description}";
        }
    }
}
