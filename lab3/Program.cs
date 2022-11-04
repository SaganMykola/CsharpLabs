using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;


namespace ConsoleApp6
{
    public class Baggage
    {
        protected int number;
        public int Number { get { return number; } set { number = value; } }

        protected int total_weight;
        public int Total_weight { get { return total_weight; } set { total_weight = value; } }



        public Baggage(int number, int total_weight)
        {
            this.number = number;
            this.total_weight = total_weight;
        }
        public Baggage()
        {

        }
    }
    public class BaggageList
    {
        public List<Baggage> baggages = new List<Baggage>();

        public BaggageList()
        {

        }
        public void Add(int number, int total_weight)
        {
            baggages.Add(new Baggage(number, total_weight));
        }
        public void CreatePO(string filename)
        {
            string json = JsonSerializer.Serialize(baggages);
            File.WriteAllText(filename, json);
        }
        public void ReadPO(string filename)
        {
            string json = File.ReadAllText(filename);
            this.baggages = JsonSerializer.Deserialize<List<Baggage>>(json);
        }
        public void MostThings()
        {
            var mostthings = this.baggages.Max(item => item.Number);
            foreach (Baggage item in baggages)
            {
                if (item.Number == mostthings)
                    Console.WriteLine("Інформація про багажі із найбільшою кількістю речей: {0}, {1}", mostthings, item.Total_weight);
            }





        }
        public void TotalWeight()
        {
            List<int> task = new List<int>();
            foreach (Baggage item in baggages)
            {

                task.Add(item.Total_weight);

            }

            for (int i = 0; i < task.Count; i++)
                Console.WriteLine("Інформація про загальну вагу багажу{0}: {1}", i + 1, task[i]);

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"C:\Users\Kolya\source\repos\Lab2\Jsonfile1.json";

            var rnd = new Random();

            BaggageList baggages = new BaggageList();

            for (int i = 0; i < 10; i++)
            {
                baggages.Add(rnd.Next(1, 10), rnd.Next(1, 15));
            }

            baggages.CreatePO(fileName);

            baggages.ReadPO(fileName);

            baggages.MostThings();

            Console.WriteLine();
            baggages.TotalWeight();
        }
    }
}