using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace aoc.D12
{
  public class JsonPartII
  {
    public static int CountNumbers(string jsonText)
    {
      var allNumbers = GatherNumbers(jsonText);
      return GetSum(allNumbers);
    }

    //Json Object could contain --> value | object | array
    private static List<int> GatherNumbers(dynamic json)
    {
      var numbers = new List<int>();

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
            var subNumbers = GatherNumbers(prop.Value.ToString());

            if (subNumbers != null && subNumbers.Count > 0)
              numbers.AddRange(subNumbers);
          }
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

          if (subNumbers != null && subNumbers.Count > 0)
            numbers.AddRange(subNumbers);
        }
      }
    }

    private static int GetSum(List<int> numbers)
    {
      int sum = 0;

      foreach (var num in numbers)
        sum += num;

      return sum;
    }
  }
}