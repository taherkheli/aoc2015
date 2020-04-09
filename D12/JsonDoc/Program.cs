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

      int sum = 0;
      foreach (var num in allNumbers)
        sum += num;

      Console.WriteLine("\nPartI: The sum of all numbers in the json doc: {0}", sum);
    }    

    //Json Object could contain --> value | object | array
    public static List<int> GatherNumbers(dynamic json)
    {
      List<int> numbers = new List<int>();

      var input = JsonConvert.DeserializeObject(json);

      if (input != null)
      {
        if (input is JValue)
        {
          JValue v = JValue.FromObject(input);

          if (int.TryParse(v.ToObject<string>(), out int x))
            numbers.Add(x);
        }

        else if (input is JObject)
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

        else if (input is JArray)
        {
          JArray jArray = JArray.FromObject(input);

          foreach (var item in jArray)
          {
            if (item is JValue)
            {
              if (int.TryParse(item.ToObject<string>(), out int x))
                numbers.Add(x);
            }

            else if (item is JObject)
            {
              var subNumbers = GatherNumbers(item.ToString());

              if (subNumbers != null && subNumbers.Count() > 0)
                numbers.AddRange(subNumbers);
            }

            else if (item is JArray)
            {
              var subNumbers = GatherNumbers(item.ToString());

              if (subNumbers != null && subNumbers.Count() > 0)
                numbers.AddRange(subNumbers);
            }
          }
        }
      }
      
      return numbers;
    }
  }
}