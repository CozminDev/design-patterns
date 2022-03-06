using System;

namespace strategy
{
    //use this pattern when we have a interchangable set of algorithms inside a context class
    class Program
    {
        static void Main(string[] args)
        {
            IStrategy sumStrategy = new SumStrategy();
            IStrategy productStrategy = new ProductStrategy();

            Context context = new Context(sumStrategy);
            Console.WriteLine(context.ExecuteStrategy(1, 2)); 
        }
    }

    public interface IStrategy
    {
        int Execute(int a, int b);
    }

    public class SumStrategy : IStrategy
    {
        public int Execute(int a, int b)
        {
            return a + b;
        }
    }

    public class ProductStrategy : IStrategy
    {
        public int Execute(int a, int b)
        {
            return a * b;
        }
    }

    public class Context
    {
        private readonly IStrategy strategy;

        public Context(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public int ExecuteStrategy(int a, int b)
        {
            return strategy.Execute(a, b);
        }
    }
}
