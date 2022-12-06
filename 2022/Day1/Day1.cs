namespace AdventOfCode2022.Day1;

public class Day1
{
  public static List<int> GetLinesInTxtFile(string filepath)
  {
    List<int> intArray = new List<int>();

    foreach (var line in System.IO.File.ReadAllLines(filepath))
    {
      intArray.Add(string.IsNullOrEmpty(line) ? 0 : int.Parse(line));
    }

    return intArray;
  }

  public static void GetHighestCalories()
  {
    List<int> calories = GetLinesInTxtFile("input.txt");

    int count = 0;
    List<int> sums = new List<int>();

    for (int i = 0; i < calories.Count; i++)
    {
      if (calories[i] != 0)
      {
        count += calories[i];
      }
      else
      {
        sums.Add(count);
        //Console.WriteLine(count);
        count = 0;
        continue;
      }
    }

    int largest1 = sums.Max();
    sums.Remove(largest1);
    int largest2 = sums.Max();
    sums.Remove(largest2);
    int largest3 = sums.Max();
    sums.Remove(largest3);

    Console.WriteLine("Top 3 Largest: " + (largest1 + largest2 + largest3).ToString());
  }

}