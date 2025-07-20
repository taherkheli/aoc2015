namespace aoc.D02
{
	public static class Parser
	{
		public static Box[] Parse(string path)
		{
			Box[] result;
      var strings = File.ReadAllLines(path);
			result = new Box[strings.Length];

			for (int i = 0; i < result.Length; i++)
				result[i] = GetBox(strings[i]);

			return result;
		}

		private static Box GetBox(string s)
		{
			var strings = s.Split('x');

			if (strings.Length != 3)
				throw new Exception("Something wentw rong. Expected 3 values. Check input file!");

			return new Box(int.Parse(strings[0]), int.Parse(strings[1]), int.Parse(strings[2]));
		}
	}
}
