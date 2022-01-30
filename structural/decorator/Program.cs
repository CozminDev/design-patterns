using System;

namespace decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Espresso espresso = new Espresso();
            Milk milkEspresso = new Milk(espresso);
            Mocha mochaMilkEspresso = new Mocha(milkEspresso);
            Console.WriteLine(mochaMilkEspresso.Description());
        }
    }

    abstract class Beverage
    {
        public abstract int Cost();

        public abstract string Description();
    }

    abstract class CondimentDecorator : Beverage
    {
    }

    class DarkRoast : Beverage
    {
        public override int Cost()
        {
            return 1;
        }

        public override string Description()
        {
            return "DarkRoast";
        }
    }

    class Espresso : Beverage
    {
        public override int Cost()
        {
            return 2;
        }

        public override string Description()
        {
            return "Espresso";
        }
    }

    class Milk : CondimentDecorator
    {
        private readonly Beverage beverage;

        public Milk(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override int Cost()
        {
            return 3 + beverage.Cost();
        }

        public override string Description()
        {
            return beverage.Description() + " Milk";
        }
    }

    class Mocha : CondimentDecorator
    {
        private readonly Beverage beverage;

        public Mocha(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override int Cost()
        {
            return 4 + beverage.Cost();
        }

        public override string Description()
        {
            return beverage.Description() + " Mocha";
        }
    }

}
