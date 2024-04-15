namespace CownBullGame
{
    internal class Program
    {
        static void CheckWord(string GuessWord,string SecretWord,ref int cow,ref int bull)
        {
            cow = 0; bull = 0;
            char[] SecretWordChar = SecretWord.ToCharArray();
            char[] GuessWordChar = GuessWord.ToCharArray();
            int i = 0;
            while(i< SecretWordChar.Length && i <GuessWordChar.Length) {
                if (SecretWordChar[i]== GuessWordChar[i])
                {
                    cow++;
                    SecretWordChar[i] = '#';
                    GuessWordChar[i] = '?';

                }
                i++;
            }
            foreach(char c in GuessWordChar) {
              int indx = Array.IndexOf(SecretWordChar,c);
                if (indx >= 0)
                {
                    bull++;
                    SecretWordChar[indx] = '#';

                }
            }





        }
        static string GetInputFromConsole()
        {
            Console.WriteLine("Enter the Guess Word");
            string UserInput=string.Empty;
            while(UserInput.Length!=4)
            {   
                UserInput = Console.ReadLine();
                if(UserInput.Length!=4)
                {
                    Console.WriteLine("Please Enter the Valid Guess Word");
                }


            }
            return UserInput;
        }
       static void StartGame()
        {
            Console.WriteLine("Enter the secret Word");
            string SecretWord = Console.ReadLine();
            string UserInput;
            int Attempt = 0;
            int cow = 0, bull = 0;
            do
            {
               
                UserInput = GetInputFromConsole();
                Attempt++;
                CheckWord(UserInput,SecretWord,ref cow,ref bull);
                Console.WriteLine("*******************************");
                Console.WriteLine($"Cow - {cow}, Bull - {bull} ,  Input Word :{UserInput}, Secert Word : {SecretWord}");
                Console.WriteLine("*******************************");
            } while (cow != 4 || bull == 4);
            Console.WriteLine($"Congratss you won at {Attempt} attempt!!!");

        }
            
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Game of Cow and Bull");
            StartGame();
        }
    }
}
