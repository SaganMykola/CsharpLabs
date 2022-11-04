namespace ConsoleApp7
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            
            
            var airport = new Dictionary<int, Dictionary<string, string>>();
           
            Console.Write("Введіть кількість рейсів: ");
            var n = Convert.ToInt32(Console.ReadLine());
            
        

            for (int i = 0; i < n; i++)
            {
                var dictionary = new Dictionary<string, string>();
                Console.Write("Введіть номер рейсу: ");
                dictionary.Add("number", Console.ReadLine());

                Console.Write("Введіть місто прибуття: ");
                dictionary.Add("place", Console.ReadLine());

                Console.Write("Введіть кількість місць: ");
                dictionary.Add("number of seats", Console.ReadLine());

                Console.Write("Введіть час перельоту: ");
                dictionary.Add("time", Console.ReadLine());

                Console.Write("Введіть ціну білету: ");
                dictionary.Add("price", Console.ReadLine());

                Console.Write("Введіть кількість пасажирів: ");
                dictionary.Add("passengers", Console.ReadLine());

                airport.Add(i, dictionary);
            }

            foreach (KeyValuePair<int, Dictionary<string, string>> item in airport)
            {
                    foreach (KeyValuePair<string, string> el in item.Value)
                {
                    Console.WriteLine("{0}: {1}", el.Key, el.Value);
                }
                Console.WriteLine();
            }

            var a = true;
            int sum = 0;

            while (a == true) {
                Console.Write("Введіть місто: ");
                var place = Console.ReadLine();
                foreach (KeyValuePair<int, Dictionary<string, string>> item in airport)
                {
                    if (item.Value["place"].ToLower() == place.ToLower())
                    {
                        if (Convert.ToInt32(item.Value["time"]) <= 5)
                        {
                            sum += Convert.ToInt32(item.Value["passengers"]);
                            a = false;
              
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Рейси, що відповідають запиту відстутні");
                        break;
                    }
                }
            }

            Console.WriteLine("Загальна кількість пасажирів, які летять в місто: {0}", sum);
            Console.WriteLine();

            foreach (KeyValuePair<int, Dictionary<string, string>> item in airport)
            {
                foreach (KeyValuePair<string, string> el in item.Value)
                {
                    
                    if (el.Key == "passengers")
                        Console.WriteLine("Загальна кількість пасажирів для рейсу {0}: {1}", item.Value["number"] , el.Value);
                }
                
            }

        }
    }
}