using System;


class Task
{
    public class Point
    {
        private int x, y;
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    public class Rectangle
    {
        private Point top_left;
        private Point botttom_right;

        public Point Top_left
        {
            get { return top_left; }
            set { top_left = value; }
        }

        public Point Bottom_right
        {
            get { return botttom_right; }
            set { botttom_right = value; }
        }

        public Rectangle(Point top_left, Point botttom_right)
        {
            this.Top_left = top_left;
            this.Bottom_right = botttom_right;
        }

        public bool contains(Point point)
        {
            return (point.X >= Top_left.X && point.X <= Bottom_right.X && point.Y >= Top_left.Y && point.Y <= Bottom_right.Y);
        }
    }

    static void Main()
    {
        Console.Write("Enter the coordinates of the square (top left X and Y, and then lower right) = ");
        string[] coordinates = Console.ReadLine().Split();

        Rectangle rectangle = new Rectangle(new Point(int.Parse(coordinates[0]), int.Parse(coordinates[1])), new Point(int.Parse(coordinates[2]), int.Parse(coordinates[3])));
        line();

        Console.Write("Now enter amount of points = ");
        int amount_points = int.Parse(Console.ReadLine());
        for(int i = 0; i < amount_points; i++)
        {
            Console.Write($"Enter coordinates of {i + 1} point = ");
            string[] temp_coordinates = Console.ReadLine().Split();

            Point temp_object = new Point(int.Parse(temp_coordinates[0]), int.Parse(temp_coordinates[1]));
            Console.WriteLine(rectangle.contains(temp_object));
            line();
        }



    }
    public static void line()
    {
        Console.WriteLine("=======================================");
    }
}