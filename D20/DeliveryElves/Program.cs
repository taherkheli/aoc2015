using System;

namespace DeliveryElves
{
  class Program
  {
    static void Main()
    {
      int target = 36000000;
      int n = 831500; // to not loop forever :)

      while (true)
      {
        if (HasReachedTarget(n, target))
          break;

        n++;
      }

      Console.WriteLine("\nPartI: The lowest house number of the house to get at least 36000000 presents is: {0}", n);

      //PartII
      n = 884400; // to not loop forever :) 884400

      while (true)
      {
        if (HasReachedTargetPartII(n, target))
          break;

        n++;
      }

      Console.WriteLine("\nPartII: The lowest house number of the house to get at least 36000000 presents is: {0}", n);
    }

    //Given a number(id) of a house, calculate presents received.Return true if amount exceeds target otherwise
    private static bool HasReachedTarget(int num, int target)
    {
      int presents = 0;

      for (int i = 1; i < num + 1; i++)
      {
        var temp = 0;

        if (num % i == 0)   //will it deliver to me?
          temp = 10 * i;    //how much?

        //Console.WriteLine("elf [{0}] delivered = {1}", i, temp);

        presents += temp;
      }

      //Console.WriteLine("TOTAL = {0}\n", presents);

      if (presents >= target)
        return true;
      else
        return false;
    }

    private static bool HasReachedTargetPartII(int num, int target)
    {
      int presents = 0;

      for (int i = 1; i < num + 1; i++)
      {
        var temp = 0;

        var withinElfsRange = (num / i) <= 50;

        if (withinElfsRange && (num % i == 0))  //will it deliver to me?
          temp = 11 * i;    //how much?

        //Console.WriteLine("elf [{0}] delivered = {1}", i, temp);
        presents += temp;
      }

      //Console.WriteLine("TOTAL = {0}\n", presents);

      if (presents >= target)
        return true;
      else
        return false;
    }

  }
}