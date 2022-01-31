using System;

namespace adapter
{
    //pattern used when we want to modify an existing interface in something the client can use
    //different from decorator as adapter doesn't add behavior to the object but decorator does
    class Program
    {
        static void Main(string[] args)
        {
            IShape circle = new CircleAdapter(new Circle());
            Console.WriteLine(circle.GetWidth());
        }
    }

    public interface IShape
    {
        int GetWidth();
    }

    public class Square : IShape
    {
        private int l = 1;

        public int GetWidth()
        {
            return l;
        }
    }

    public class Rectangle : IShape
    {
        private int L = 2;

        private int B = 1;
        public int GetWidth()
        {
            return L;
        }
    }

    public class Circle
    {
        private int R = 3;

        public int GetRadius()
        {
            return R;
        }
    }

    public class CircleAdapter: IShape
    {
        private readonly Circle circle;

        public CircleAdapter(Circle circle)
        {
            this.circle = circle;
        }

        public int GetWidth()
        {
            return circle.GetRadius() * 2;
        }
    }
}
