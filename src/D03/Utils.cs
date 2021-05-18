using System.Collections.Generic;

namespace aoc.D03
{
	public static class Utils
	{
		public static List<House> GetUnion(List<House> a, List<House> b)
		{
			//treat incoming lists as read only
			List<House> result = null;

			if (a.Count < b.Count)
			{
				result = new List<House>(b);

				foreach (var house in a)
				{
					var index = result.FindIndex(h => (h.X == house.X) && (h.Y == house.Y));

					if (index == -1)
						result.Add(new House(house.X, house.Y)
						{
							VisitCount = house.VisitCount
						});
					else
						result[index].VisitCount += house.VisitCount;
				}
			}
			else
			{
				result = new List<House>(a);

				foreach (var house in b)
				{
					var index = result.FindIndex(h => (h.X == house.X) && (h.Y == house.Y));

					if (index == -1)
						result.Add(new House(house.X, house.Y)
						{
							VisitCount = house.VisitCount
						});
					else
						result[index].VisitCount += house.VisitCount;
				}
			}

			return result;
		}
	}
}
