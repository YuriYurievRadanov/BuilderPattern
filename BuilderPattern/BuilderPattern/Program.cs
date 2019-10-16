using System;

namespace BuilderPattern
{
    // Product class
    public class Pizza
    {
        public string PizzaType { get; set; }
        public string Dough { get; set; }
        public string Souce { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", PizzaType, Dough, Souce);
        }
    }

    // Builder class
    public abstract class PizzaBuilder
    {
        protected Pizza _pizza;

        public Pizza Pizza
        {
            get { return _pizza; }
        }

        public abstract void MakeSouce();
        public abstract void MakeDough();
    }

    // ConcreteBuilder class
    public class SpicyPizzaBuilder : PizzaBuilder
    {
        public SpicyPizzaBuilder()
        {
            _pizza = new Pizza { PizzaType = "Spicy" };
        }
        public override void MakeSouce()
        {
            _pizza.Souce = "Hot souce, pepperoni, pepper";
        }

        public override void MakeDough()
        {
            _pizza.Dough = "Thin base, with cheese";
        }
    }

    // ConcreteBuilder Class
    public class FourSeasonsPizzaBuilder : PizzaBuilder
    {
        public FourSeasonsPizzaBuilder()
        {
            _pizza = new Pizza { PizzaType = "Four Seaons" };
        }
        public override void MakeSouce()
        {
            _pizza.Souce = "Pepper, Tomato, Cheese, sausage";
        }

        public override void MakeDough()
        {
            _pizza.Dough = "Thick, origano";
        }
    }

    // Director Class
    public class PizzaMaker
    {
        public void DoIt(PizzaBuilder vBuilder)
        {
            vBuilder.MakeSouce();
            vBuilder.MakeDough();
        }
    }

    // Client class
    class Program
    {
        static void Main(string[] args)
        {
            PizzaBuilder vBuilder;

            PizzaMaker maker = new PizzaMaker();
            vBuilder = new SpicyPizzaBuilder();

            maker.DoIt(vBuilder);
            Console.WriteLine(vBuilder.Pizza.ToString());

            vBuilder = new FourSeasonsPizzaBuilder();
            maker.DoIt(vBuilder);
            Console.WriteLine(vBuilder.Pizza.ToString());
        }
    }
}
