using System;

class Task
{
    public class Hospital
    {
        static List<Hospital> list = new List<Hospital>();
        public string department { get; set; }
        public string doctor_name { get; set; }
        public string doctor_surname { get; set; }
        public string patient { get; set; }

        public Hospital(string department,  string doctor, string doctor_surname, string patient)
        {
            this.department = department;
            this.doctor_name = doctor;
            this.doctor_surname = doctor_surname;
            this.patient = patient;
        }

        public Hospital() { }

        public void add_patient(Hospital new_client)
        {
            list.Add(new_client);
        }

        public void show_department_or_doctor(string input)
        {
            int counter = 0;
            for(int i = 0; i < list.Count; i++)
            {
                if (list[i].department == input)
                {
                    Console.WriteLine($"Patient {counter + 1}: {list[i].patient}");
                    counter++;
                }
            }
            if (counter == 0)
            {
                for(int i = 0; i < list.Count; i++)
                {
                    for(int j = i + 1; j < list.Count; j++)
                    {
                        if (string.Compare(list[i].patient, list[j].patient) > 0)
                        {
                            var temp = list[i];
                            list[i] = list[j];
                            list[j] = temp;
                        }
                    }
                }
                for(int i = 0; i < list.Count; i++)
                {
                    if (list[i].doctor_surname == input)
                    {
                        Console.WriteLine($"Patient {counter + 1} = {list[i].patient}");
                        counter++;
                    }
                }
            }
        }

        public void show_patient_in_palats(string department, int number_of_palet)
        {
            int counter = 0;
     
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (string.Compare(list[i].patient, list[j].patient) > 0)
                    {
                        var temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }


            List<Hospital> temp_array = new List<Hospital>();
            for(int i = 0; i < list.Count; i++)
            {
                if (list[i].department == department) temp_array.Add(list[i]);
            }


            if (number_of_palet == 0) number_of_palet = 0;
            else number_of_palet = number_of_palet * 3 - 1; 

            for (int i = number_of_palet; i < number_of_palet + 3; i++)
            {
                Console.WriteLine($"Patient {counter} in {department}: {temp_array[i].patient};");
                counter++;
            }

        }
    }


    static void Main()
    {
        Console.WriteLine("Enter data in the format {department} {doctor name} {doctor surname} {patient}");
        line();
        Hospital hospital = new Hospital();
        int counter = 0;

        while (true)
        {
            Console.Write($"Enter information of {counter + 1} = ");
            string[] input = Console.ReadLine().Split();

            string department, doctor_name, doctor_surname, patient;
            if (input[0].ToLower() == "output") break;
            else department = input[0];

            doctor_name = input[1];
            doctor_surname = input[2];
            patient = input[3];

            Hospital new_client = new Hospital(department, doctor_name, doctor_surname, patient);
            hospital.add_patient(new_client);
            counter++;
            line();
        }
        line();

        Console.Write("Attention! If you enter {doctor}, enter him surname");
        Console.Write("\nAttention! Number of palet starts from 0 !!!");
        Console.Write("\nEnter choice (department/department chamber/doctor) = ");

        string[] choice = Console.ReadLine().Split();

        if (choice.Length == 1) hospital.show_department_or_doctor(choice[0]);
        else hospital.show_patient_in_palats(choice[0], int.Parse(choice[1]));

    }
    public static void line()
    {
        Console.WriteLine("=======================================");
    }
}