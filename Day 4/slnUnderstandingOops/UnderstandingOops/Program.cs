namespace UnderstandingOops
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int[] ages= new int[3];
            ages[0] = 10;
            ages[1] = 20;
            ages[2] = 30;
            Console.WriteLine(ages[0]);
            //for (int i = 0; i < ages.Length; i++)
            //{
            //    Console.WriteLine(ages[i]);
            //}
            int i = ages.Length-1;
            while(i>=0) {
                Console.WriteLine(ages[i]);
                i--;

        }


    }


    
    

