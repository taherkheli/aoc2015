using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JsonDoc
{
  class Program
  {
    static void Main()
    {
      string path = "input.txt";
      using StreamReader r = new StreamReader(path);
      string json = r.ReadToEnd();
      var allNumbers = GatherNumbers(json);
      Console.WriteLine("\nPartI: The sum of all numbers in the json doc: {0}", GetSum(allNumbers));

      allNumbers = GatherNumbersPartII(json);
      Console.WriteLine("\nPartII: The sum of all numbers in the json doc excluding 'reds': {0}", GetSum(allNumbers));
    }     
    
    //Json Object could contain --> value | object | array
    public static List<int> GatherNumbers(dynamic json)
    {
      List<int> numbers = new List<int>();
      var input = JsonConvert.DeserializeObject(json);

      if (input != null)
      {
        if (input is JValue)
          HandleValue(input, numbers);

        else if (input is JObject)
          HandleObject(input, numbers);

        else if (input is JArray)
          HandleArray(input, numbers);
      }

      return numbers;
    }

    //TODO: Tried to combine bith parts into a single method but it is not trivial due to recursive nature of the method
    public static List<int> GatherNumbersPartII(dynamic json)
    {
      List<int> numbers = new List<int>();
      var input = JsonConvert.DeserializeObject(json);

      if (input != null)
      {
        if (input is JValue)
          HandleValue(input, numbers);

        else if (input is JObject)
          HandleObjectPartII(input, numbers);

        else if (input is JArray)
          HandleArrayPartII(input, numbers);
      }

      return numbers;
    }

    private static void HandleValue(dynamic input, List<int> numbers)
    {
      JValue v = JValue.FromObject(input);

      if (int.TryParse(v.ToObject<string>(), out int x))
        numbers.Add(x);
    }

    private static void HandleObject(dynamic input, List<int> numbers)
    {
      JObject jObject = JObject.FromObject(input);
      var props = jObject.Properties();

      foreach (var prop in props)
      {
        if (prop.Value is JValue)
        {
          JValue v = (JValue)JValue.FromObject(prop.Value);

          if (int.TryParse(v.ToObject<string>(), out int x))
            numbers.Add(x);
        }

        if (prop.Value is JObject || prop.Value is JArray)
        {
          var subNumbers = GatherNumbers(prop.Value.ToString());

          if (subNumbers != null && subNumbers.Count() > 0)
            numbers.AddRange(subNumbers);
        }
      }
    }

    private static void HandleArray(dynamic input, List<int> numbers)
    {
      JArray jArray = JArray.FromObject(input);

      foreach (var item in jArray)
      {
        if (item is JValue)
        {
          if (int.TryParse(item.ToObject<string>(), out int x))
            numbers.Add(x);
        }

        else if ((item is JObject) || (item is JArray))
        {
          var subNumbers = GatherNumbers(item.ToString());

          if (subNumbers != null && subNumbers.Count() > 0)
            numbers.AddRange(subNumbers);
        }
      }
    }

    private static void HandleObjectPartII(dynamic input, List<int> numbers)
    {
      JObject jObject = JObject.FromObject(input);
      var props = jObject.Properties();

      var list = props.ToList();
      var temp = list.Find(p => p.Value.ToString() == "red");

      if (temp == null)   //no red property found
      {
        foreach (var prop in props)
        {
          if (prop.Value is JValue)
          {
            JValue v = (JValue)JValue.FromObject(prop.Value);

            if (int.TryParse(v.ToObject<string>(), out int x))
              numbers.Add(x);
          }

          if (prop.Value is JObject || prop.Value is JArray)
          {
            var subNumbers = GatherNumbersPartII(prop.Value.ToString());

            if (subNumbers != null && subNumbers.Count() > 0)
              numbers.AddRange(subNumbers);
          }
        }
      }
    }

    private static void HandleArrayPartII(dynamic input, List<int> numbers)
    {
      JArray jArray = JArray.FromObject(input);

      foreach (var item in jArray)
      {
        if (item is JValue)
        {
          if (int.TryParse(item.ToObject<string>(), out int x))
            numbers.Add(x);
        }

        else if ((item is JObject) || (item is JArray))
        {
          var subNumbers = GatherNumbersPartII(item.ToString());

          if (subNumbers != null && subNumbers.Count() > 0)
            numbers.AddRange(subNumbers);
        }
      }
    }

    private static int GetSum(List<int> allNumbers)
    {
      int sum = 0;

      foreach (var num in allNumbers)
        sum += num;

      return sum;
    }
  }
}