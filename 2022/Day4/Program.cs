List<string> areasToClean = new List<string>();

foreach (var line in System.IO.File.ReadAllLines("./input.txt"))
{
  areasToClean.Add(line);
}

String elf1Area = "";
String elf2Area = "";
int p1Result = 0;

for (int i = 0; i < areasToClean.Count; i++)
{
  elf1Area = areasToClean[i].Substring(0, CommaIndex(areasToClean[i]));

  elf2Area = areasToClean[i].Substring(
      (CommaIndex(areasToClean[i]) + 1),
      areasToClean[i].Length - (CommaIndex(areasToClean[i]) + 1));

  int elf1Lowest = Lowest(elf1Area);
  int elf1Highest = Highest(elf1Area);
  int elf2Lowest = Lowest(elf2Area);
  int elf2Highest = Highest(elf2Area);

  if ((elf1Lowest <= elf2Lowest && elf1Highest >= elf2Highest) || (elf2Lowest <= elf1Lowest && elf2Highest >= elf1Highest))
  {
    p1Result++;
  }
}

System.Console.WriteLine("Part 1: " + p1Result);

int HyphenIndex(string area)
{
  int result = 0;

  foreach (char c in area)
  {
    if (c == '-')
    {
      break;
    }
    result += 1;
  }

  return result;
}

int CommaIndex(string area)
{
  int result = 0;

  foreach (char c in area)
  {
    if (c == ',')
    {
      break;
    }
    result += 1;
  }

  return result;
}

int Lowest(string area)
{
  return int.Parse(area.Substring(0, HyphenIndex(area)));
}

int Highest(string area)
{
  return int.Parse(area.Substring(HyphenIndex(area) + 1, area.Length - (HyphenIndex(area) + 1)));
}
