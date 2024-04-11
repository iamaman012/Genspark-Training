namespace FirstApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float fNum1;
            int iNum2;
            Console.WriteLine("Please enter a number");
            fNum1 = Convert.ToSingle(Console.ReadLine());
            iNum2 = (int)fNum1;//explicit casting
            Console.WriteLine($"The numbe is {fNum1}");
            Console.WriteLine($"The numbe is {iNum2}");
        }
    }
}


