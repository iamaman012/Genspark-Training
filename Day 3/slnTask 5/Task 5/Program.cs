namespace Task_5
{
    internal class Program

    {
        static void CheckUser(string username, string password)
        {
            if(username != "ABC" || password != "123")
            {
                Console.WriteLine("Invalid Credentials")
            }
        }

        static void TakeInput(string s,out string data)
        {
            data = "";
            data = Console.WriteLine($"Enter the {s}");
        }
        static void UserCredentials()
        {
            string uname,password;
            TakeInput("Username", uname);
            TakeInput("Password", password);
            checkUser(uname,password);

        }
        static void Main(string[] args)
        {
            UserCredentials();
        }
    }
}
