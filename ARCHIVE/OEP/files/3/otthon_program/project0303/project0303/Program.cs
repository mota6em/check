namespace project0303
{
    public class program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter the size of matrix needed: ");
            int n = int.Parse(Console.ReadLine());
            Diag a = new Diag(n);
            Console.WriteLine("Please enter the values of the DiagMatrix in one line:");
            string input = Console.ReadLine();
            string[] numbers = input.Split(' ');
            if(numbers.Length < n)
            {
                Console.WriteLine("Insufficient number of values entered.");
                return;
            }
            for(int i = 0; i < n; i++)
            {
                if (!double.TryParse(numbers[i], out double value))
                {
                    Console.WriteLine($"Invalid input: '{numbers[i]}' is not a valid double.");
                    return;
                }
                a.SetAt(i, i, value); 
            }
            Console.WriteLine(a);
            Diag x = new Diag(n);
            Diag y = new Diag(n);
            x = a + a;
            y = x * x;
            Console.WriteLine(Diag.Add(a,a));
            Console.WriteLine(a.GetAt(0, 0));
            Console.WriteLine(x);
            Console.WriteLine(y);
        }
    }
}