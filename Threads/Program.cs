using System.Security.Cryptography;
using System.Text;

namespace Threads
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine($"Starting Threads...");

            // Global Variables
            bool loading = true;
            int whileCount = 0;

            double resultNum = 0;


            Console.WriteLine($"Our objective is to run some cumputationally heavy functions and to show a loading message using different threads");
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;

            Thread calculation = new Thread(() =>
            {
                start = DateTime.Now;
                for (int i = 0; i < 200000000; i++)
                {
                    // Do the calculations 
                    using (SHA256 mySHA256 = SHA256.Create())
                    {
                        Random random = new Random(1000000000);

                        // hash above num
                        byte[] bytes = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(random.ToString()));
                        //Console.WriteLine("Hashed 1");

                    }
                }
                end = DateTime.Now;
            });

            calculation.Start();

            while (loading)
            {
                if (!calculation.IsAlive)
                {
                    calculation.Join();
                    loading = false;
                }

                Console.Write($"\nLoading");
                
                // Check if count divisible by 3, remainder + 1 is how many '.' to show after 'Loading'
                int remainder = whileCount % 3;
                
                switch (remainder + 1)
                {
                    case 1:
                    {
                        Console.Write(".");
                        break;
                    }
                    case 2:
                    {
                        Console.Write("..");
                        break;
                    }
                    case 3:
                    {
                        Console.Write("...");
                        break;
                    }
                    default:
                    {
                        throw new Exception("How did we get here!?");
                        break;
                    }
                }



                whileCount++;
                Thread.Sleep(250);
            }


            

            Console.WriteLine($"Thread has completed, time taken: {end - start}");

            Console.WriteLine($"Program Complete...");
        }



        public static double Calc(int i)
        {
            return 1 + i / (2.0 * i + 1) * Calc(i + 1);
        }



    }
}
