namespace Task_5
{
    internal class Program
    {
        static void UserCredentials()
        {
            string name,password;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter the Name");
                name = Console.ReadLine();
                Console.WriteLine("Enter The Password");
                password = Console.ReadLine();
                if (check(name, password))
                { 
                    Console.WriteLine("Login Succesfully!!");

            }
        }
        static void Main(string[] args)
        {
            UserCredentials();
        }
    }
}
