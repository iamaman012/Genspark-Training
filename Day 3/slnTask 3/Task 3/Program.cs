namespace Task_3
{
    internal class Program
    {
        static void Average()
        {   int sum = 0;
            int count = 0;
            int num;
            while(true)
            {   Console.WriteLine("Enter the Number");
                num=int.Parse(Console.ReadLine());
                if(num<0)
                {
                    Console.WriteLine($"The average is {(sum*1.0)/count}");
                    break;
                }
                else if(num%7==0) {
                    sum = sum + num;
                    count++;
                }
               

            }
           

        }
        static void Main(string[] args)
        {
            Average();
        }
    }
}
