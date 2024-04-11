namespace Task_4
{
    internal class Program
    {
        static void InputLength()
        {
            Console.WriteLine("Please Enter the Name");
            string s;
            s=Console.ReadLine();
            s = s.Replace(" ", "");
            Console.WriteLine($"The Length of User name is {s.Length}");
        }
        static void Main(string[] args)
        {
            InputLength();
        }
    }
}
