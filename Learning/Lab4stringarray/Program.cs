namespace Lab4stringarray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[args.Length];
            int j = 0;
            for(int i=0; i < args.Length; i++)
            {
                if (int.TryParse(args[i], out nums[j]))
                    j++;
                else
                    Console.WriteLine($"Invalid number format: {args[i]}");
            }

            nums = nums[0..j];

            int summa = 0;
            foreach (int k in nums) summa += k;

            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
                Console.WriteLine(nums[i]);

            Console.WriteLine($"Summa : {summa}");

        }
    }
}
