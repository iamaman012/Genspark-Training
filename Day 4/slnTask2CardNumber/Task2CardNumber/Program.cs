using System.ComponentModel.DataAnnotations;

namespace Task2CardNumber
{
    internal class Program
    {
        static bool IsValidCard(string cardNumber)
        {
            string ReversedNumber = new string(cardNumber.Reverse().ToArray());
            int total = 0;
           

            for (int i = 0; i < ReversedNumber.Length; i++)
            {

                if ((i + 1) % 2 == 1)
                {


                    total += ((int)ReversedNumber[i] - 48);
                }
                else
                {
                    int num = ((int)ReversedNumber[i] - 48);
                    num = num * 2;

                    total += (num % 10) + (num / 10);
                }
            }
           
            return total%10 == 0;

        }
        static void Main(string[] args)
        {
            string CardNumber;
            Console.WriteLine("Please Enter the 16 digit Card Number!!");
            CardNumber = Console.ReadLine();
            if ( CardNumber.Length==16 && IsValidCard(CardNumber)) Console.WriteLine("Given Card Number is Valid");
            else Console.WriteLine("Given Card Number is Not Valid");

        }
    }
}
