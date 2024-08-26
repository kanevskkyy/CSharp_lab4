using System;
using System.Collections.Generic;

class Task
{
    public class Treasure
    {
        public int quantity { get; set; }
        public string type_of_treasure { get; set; }
        public static List<Treasure> treasures = new List<Treasure>();

        public Treasure(string type, int quantity)
        {
            type_of_treasure = type;
            this.quantity = quantity;
        }

        public static void add_treasure(Treasure treasure)
        {
            treasures.Add(treasure);
        }
    }

    static void Main()
    {
        Console.Write("Enter size of backpack: ");
        int capacity = int.Parse(Console.ReadLine());
        print_line();
        Console.Write("Enter treasures: ");
        string[] array = Console.ReadLine().Split();
        print_line();

        int cash = 0;
        int gem = 0;
        int golds = 0;

        for (int i = 0; i < array.Length - 1; i += 2)
        {
            string name = array[i].ToLower();
            int quantity = int.Parse(array[i + 1]);

            if (capacity - quantity < 0)
            {
                Console.WriteLine("Bag capacity exceeded");
                continue;
            }

            if (name == "gold" && golds + quantity >= gem)
            {
                Treasure.add_treasure(new Treasure(name, quantity));
                golds += quantity;
                capacity -= quantity;
            }
            else if (name.Contains("gem") && gem + quantity >= cash)
            {
                Treasure.add_treasure(new Treasure(name, quantity));
                gem += quantity;
                capacity -= quantity;
            }
            else if (name.Length == 3 && gem >= cash + quantity)
            {
                Treasure.add_treasure(new Treasure(name, quantity));
                cash += quantity;
                capacity -= quantity;
            }
        }

        if (golds > 0)  print_result("Gold", "gold", golds);
        if (gem > 0)    print_result("Gem", "gem", gem);
        if (cash > 0)   print_result("Cash", "", cash);
    }

    public static void print_result(string category, string type, int totalQuantity)
    {
        bool has_item = false;
        for (int i = 0; i < Treasure.treasures.Count; i++)
        {
            if ((type == "" && Treasure.treasures[i].type_of_treasure.Length == 3) ||
                (Treasure.treasures[i].type_of_treasure == type || Treasure.treasures[i].type_of_treasure.Contains(type)))
            {
                has_item = true;
                break;
            }
        }

        if (has_item)
        {
            Console.WriteLine($"<{category}> ${totalQuantity}");
            List<Treasure> sort = new List<Treasure>();
            for (int i = 0; i < Treasure.treasures.Count; i++)
            {
                if ((type == "" && Treasure.treasures[i].type_of_treasure.Length == 3) ||
                    (Treasure.treasures[i].type_of_treasure == type || Treasure.treasures[i].type_of_treasure.Contains(type)))
                {
                    sort.Add(Treasure.treasures[i]);
                }
            }

            for (int i = 0; i < sort.Count - 1; i++)
            {
                for (int j = i + 1; j < sort.Count; j++)
                {
                    if (String.Compare(sort[i].type_of_treasure, sort[j].type_of_treasure) < 0 ||
                        (sort[i].type_of_treasure == sort[j].type_of_treasure && sort[i].quantity > sort[j].quantity))
                    {
                        Treasure temp = sort[i];
                        sort[i] = sort[j];
                        sort[j] = temp;
                    }
                }
            }
            for (int i = 0; i < sort.Count; i++)
            {
                Console.WriteLine($"##{sort[i].type_of_treasure} - {sort[i].quantity}");
            }
        }
    }

    public static void print_line()
    {
        Console.WriteLine("=======================================");
    }
}