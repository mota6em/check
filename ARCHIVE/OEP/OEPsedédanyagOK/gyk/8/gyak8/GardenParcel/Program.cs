namespace GardenParcel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Garden nice = new(5);
            Gardener joe = new Gardener(nice);

            Plant flower1 = Rose.Instance();
            Plant flower2 = Lily.Instance();
            if (flower1 is Rose)
            {
                Console.WriteLine("Flower 1 is Rose");
            }
        }
    }
}