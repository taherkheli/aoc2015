using System.Collections.Generic;

namespace Happiness
{
  public class Table
  {
    private List<Person> _persons;
    private Dictionary<string, Dictionary<string, int>> _happinessLookUp;

    public Table(string[] info)
    {
      _persons = new List<Person>();
      _happinessLookUp = new Dictionary<string, Dictionary<string, int>>();
      Initialize(info);
    }

    public List<Person> Persons { get => _persons; set => _persons = value; }
    public Dictionary<string, Dictionary<string, int>> HappinessLookUp { get => _happinessLookUp; set => _happinessLookUp = value; }

    private void Initialize(string[] info)
    {      
      foreach (var s in info)
      {
        int happiness = -1;
        var s_array = s.Trim().Split(' ');
        var p1 = s_array[0].Trim();
        var p2 = s_array[^1].Trim().Trim('.');

        s_array = s.Split("gain");

        if (s_array.Length > 1)
        {
          s_array = s_array[1].Trim().Split(' ');
          happiness = int.Parse(s_array[0]);
        }
        else 
        {
          s_array = s.Split("lose");
          s_array = s_array[1].Trim().Split(' ');
          happiness *= int.Parse(s_array[0]);
        }

        var temp = _persons.Find(p => p.Name == p1);

        if (temp == null)
        {
          _persons.Add(new Person(p1));
          _happinessLookUp.Add(p1, new Dictionary<string, int>());
          _happinessLookUp[p1].Add(p2, happiness);
        }
        else
          _happinessLookUp[temp.Name].Add(p2, happiness);
      }
    }

    public int CalculateTotalChangeInHappiness(List<Person> seating)
    {
      int sum = 0;

      for (int i = 0; i < seating.Count; i++)
      {
        int temp1, temp2;

        if (i == 0)
        {
          temp1 = _happinessLookUp[seating[i].Name][seating[seating.Count - 1].Name];
          temp2 = _happinessLookUp[seating[i].Name][seating[i + 1].Name];
        }
        else if (i == seating.Count - 1)
        {
          temp1 = _happinessLookUp[seating[i].Name][seating[i - 1].Name];
          temp2 = _happinessLookUp[seating[i].Name][seating[0].Name];
        }
        else
        {
          temp1 = _happinessLookUp[seating[i].Name][seating[i - 1].Name];
          temp2 = _happinessLookUp[seating[i].Name][seating[i + 1].Name];
        }

        sum += (temp1 + temp2);
      }

      return sum;
    }

    public void AddPerson(Person person)
    {
      var temp = _persons.Find(p => p.Name == person.Name);

      if (temp == null)
      {
        _persons.Add(person);
        _happinessLookUp.Add(person.Name, new Dictionary<string, int>());

        foreach (var p in _persons)
        {
          if (p.Name != person.Name)
          {
            _happinessLookUp[person.Name].Add(p.Name, 0);
            _happinessLookUp[p.Name].Add(person.Name, 0);
          }
        }
      }
    }
  }
}
