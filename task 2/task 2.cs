using System;
using static Task;

class Task
{

    public enum Season
    {
        Autumn = 1,
        Spring = 2,
        Winter = 3,
        Summer = 4
    }

    public enum Discount 
    {
        None = 0,
        SecondVisit = 10,
        VIP = 20
    }

    public class Reservation
    {
        private decimal price;
        private int amount_of_days;
        private Season season;
        private Discount discount_type;

        public Reservation(decimal price, int amount_of_days, Season season, Discount discount_type)
        {
            this.price = price;
            this.amount_of_days = amount_of_days;
            this.season = season;
            this.discount_type = discount_type;
        }

        public decimal calculate_price()
        {
            decimal start_price = this.price * this.amount_of_days * (int)season;
            decimal discount = (decimal)discount_type / 100;

            start_price = start_price - (start_price * discount);
            return start_price;
        }
    }

    static void Main()
    {
        Console.Write("Enter information = ");
        string[] array = Console.ReadLine().Split();
        decimal price = decimal.Parse(array[0]);
        int days = int.Parse(array[1]);
       
        Season season = (Season)Enum.Parse(typeof(Season), array[2], true);
        Discount discount;
       
        if (array.Length > 3) discount = (Discount)Enum.Parse(typeof(Discount), array[3], true);
        else discount = Discount.None;
        
        Reservation reservation = new Reservation(price, days, season, discount);
        Console.WriteLine($"Price : {reservation.calculate_price()}");

    }
    public static void line()
    {
        Console.WriteLine("=======================================");
    }
}