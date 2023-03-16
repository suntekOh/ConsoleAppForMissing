using System.Reflection.Metadata;

namespace ConsoleApp_Missing;

class Program
{
    static void Main(string[] args)
    {
        try
        {
           var input = InputData();
           var numberOfMissing = Missing(input.target, input.startValue, input.endValue);
           Console.WriteLine($"values of target list: {string.Join(", ", input.target)}");
           Console.WriteLine($"start value: {input.startValue}");
           Console.WriteLine($"end value: {input.endValue}");
           Console.WriteLine($"number of missing values: {numberOfMissing}");
           Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }


    //Implement int Missing(int[] list, int a, int b) which returns the number of
    //integers between a and b that are missing from the list. 

   static int Missing(int[] list, int a, int b)
    {
        IEnumerable<int> source = Enumerable.Range(a, b-a+1).ToArray();

        var q = from p in source
                where list.Contains(p) == false
                select p;

        return q.Count();
    }

    static (int[] target ,int startValue, int endValue) InputData()
    {
        Random rnd = new Random();
        int[] target = new int[20];

        for (int i = 0; i < target.Length; i++)
        {
            target[i] = rnd.Next(1, 100);
        }

        Console.WriteLine("Type any number between 1 and 99");
        if (int.TryParse(Console.ReadLine(), out var startValue) && startValue > 0 && startValue <= 99)
        {

        }
        else
        {
            throw new InvalidOperationException("integer value required that is between 1 and 99");
        }

        Console.WriteLine($"Type any number between {startValue+1} and 100");
        if (int.TryParse(Console.ReadLine(), out var endValue) && endValue > startValue && endValue <= 100)
        {

        }
        else
        {
            throw new InvalidOperationException($"integer value required that is between {startValue+1} and 100");
        }

        return (target, startValue, endValue);
    }

}

