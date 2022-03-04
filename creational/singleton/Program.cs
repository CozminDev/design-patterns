using System;

namespace singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Singleton.GetInstance.id);
            Console.WriteLine(Singleton.GetInstance.id);

        }
    }

    public class Singleton
    {
        public Guid id = Guid.NewGuid();
        private readonly static Singleton Instance = new Singleton();
        private Singleton()
        {

        }

        public static Singleton GetInstance
        {
            get
            {
                return Instance;
            }
        }
    }
}
