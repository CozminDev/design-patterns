using System;

namespace prototype
{
    //this pattern is used when we want to clone an object and that object has private fields or hidden elements and we want to clone everything
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect1 = new Rectangle();
            rect1.height = 2;
            rect1.width = 2;
            Rectangle rect2 = (Rectangle)rect1.Clone();

            Console.WriteLine(rect2.height);
            Console.WriteLine(rect2.width);
        }
    }

    public interface IShape
    {
        object Clone();
    }

    public class Rectangle : IShape
    {
        public int height;
        public int width;
        private int somefield;

        public Rectangle()
        {

        }

        public Rectangle(Rectangle source)
        {
            height = source.height;
            width = source.width;
            somefield = source.somefield;
        }

        public object Clone()
        {
            return new Rectangle(this);
        }
    }

    public class Circle: IShape
    {
        public int radius;
        private int somefield;

        public Circle()
        {
            somefield = 2;
        }

        public Circle(Circle source)
        {
            radius = source.radius;
            somefield = source.somefield;
        }

        public object Clone()
        {
            return new Circle(this);
        }
    }
}
