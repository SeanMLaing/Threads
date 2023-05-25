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

            Thread calculation = new Thread(() =>
            {
                // Do the calculations


            });

            calculation.Start();

            while (loading)
            {
                Console.Write($"Loading");
                
                // Check if count divisible by 3, remainder + 1 is how many '.' to show after 'Loading'
                int remainder = whileCount % 3;
                
                switch (remainder + 1)
                {
                    case 1:
                    {

                        break;
                    }
                    case 2:
                    {

                        break;
                    }
                    case 3:
                    {

                        break;
                    }
                    default:
                    {
                            throw new Exception("How did we get here!?");
                        break;
                    }
                }
                



            }
            


            Console.WriteLine($"Program Complete...");
        }







    }
}
