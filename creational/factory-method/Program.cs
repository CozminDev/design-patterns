using System;

namespace factory_method
{
    class Program
    {
        static void Main(string[] args)
        {
            FactoryMethodClass factory = new FactoryMethodClass();
            IProduct prodA = factory.FactoryMethod("A");
            prodA.Description();
            IProduct prodB = factory.FactoryMethod("B");
            prodB.Description();
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

    public class ProductB: IProduct
    {
        public void Description()
        {
            Console.WriteLine("Prod B");
        }
    }

    public class FactoryMethodClass
    {
        public IProduct FactoryMethod(string type)
        {
            switch (type)
            {
                case "A" : return new ProductA();
                case "B" : return new ProductB();
                default:
                    return null;
            }
        }
    }
}
