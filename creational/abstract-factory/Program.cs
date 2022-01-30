using System;

namespace abstract_factory
{
    class Program
    {
        static void Main(string[] args)
        {
            IFactory factory = null;

            if(args.Length > 0 && args[0] == "-complex")
            {
                factory = new ComplexFactory();
            }
            else
            {
                factory = new SimpleFactory();
            }

            factory.CrateProduct("A").Description();
            factory.CrateProduct("B").Description();
        }
    }

    public interface IProduct
    {
        public void Description();
    }

    public class ProductA : IProduct
    {
        public void Description()
        {
            Console.WriteLine("Prod A");
        }
    }

    public class ProductB : IProduct
    {
        public void Description()
        {
            Console.WriteLine("Prod B");
        }
    }

    public class ComplexProductA : IProduct
    {
        public void Description()
        {
            Console.WriteLine("Complex Prod A");
        }
    }

    public class ComplexProductB : IProduct
    {
        public void Description()
        {
            Console.WriteLine("Complex Prod B");
        }
    }

    public interface IFactory
    {
        public IProduct CrateProduct(string type);
    }

    public class SimpleFactory: IFactory
    {
        public IProduct CrateProduct(string type)
        {
            switch (type)
            {
                case "A": return new ProductA();
                case "B": return new ProductB();
                default:
                    return null;
            }
        }
    }

    public class ComplexFactory: IFactory
    {
        public IProduct CrateProduct(string type)
        {
            switch (type)
            {
                case "A": return new ComplexProductA();
                case "B": return new ComplexProductB();
                default:
                    return null;
            }
        }
    }
}
