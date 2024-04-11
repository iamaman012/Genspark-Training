
namespace Task_1
{
    internal class Program
    {   static int Multiplication(int num1, int num2)
        {
            return (num1 * num2);
        }
        static void PrintResult(int ans, string msg)
        {
            Console.WriteLine($"The {msg} is {ans}");
        }
        static int Addition(int num1,int num2)
        {
               return num1 + num2;  
        }
        static int TakeNumber()
        {
            int num;
            while(!int.TryParse(Console.ReadLine(),out num))
            {
                Console.WriteLine("Please Enter a Valid Interger!!");
            }
            return num;
        }
        static void Calculate()
        {
            int num1, num2;
            num1 = TakeNumber();
            num2 = TakeNumber();
            int sum = Addition(num1, num2);
            PrintResult(sum, "Addition");
            int mul = Multiplication(num1,num2);
            PrintResult(mul, "Multiplication");



        }

       

        static void Main(string[] args)
        {
            Calculate();
        }
    }
}
