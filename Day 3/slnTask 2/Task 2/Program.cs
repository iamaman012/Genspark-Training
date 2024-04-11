namespace Task_2
{
    internal class Program
    {   static void GreatestNumber()
        {
            int ans = 0;
            int num;
            while(true)
            {
                Console.WriteLine("Please Enter the Number");
                num = int.Parse(Console.ReadLine());
                if (num < 0)
                {
                    break;
                }
                if(num>=ans)
                {
                    ans = num;
                }
            }
            Console.WriteLine($"{ans} is the greatest");
        }

        static void Main(string[] args)
        {
            GreatestNumber();
        }
    }
}
