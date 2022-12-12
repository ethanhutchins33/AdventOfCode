List<string> AreasToClean = new List<string>();

foreach (var line in System.IO.File.ReadAllLines("./input.txt"))
{
  AreasToClean.Add(line);
}

String Elf1Area = "";
String Elf2Area = "";
int part1Result = 0;

for (int i = 0; i < AreasToClean.Count; i++)
{
  Elf1Area = AreasToClean[i].Substring(0, commaIndex(AreasToClean[i]));

  Elf2Area = AreasToClean[i].Substring(
      (commaIndex(AreasToClean[i]) + 1),
      AreasToClean[i].Length - (commaIndex(AreasToClean[i]) + 1));

  int Elf1Lowest = returnLowest(Elf1Area);
  int Elf1Highest = returnHighest(Elf1Area);
  int Elf2Lowest = returnLowest(Elf2Area);
  int Elf2Highest = returnHighest(Elf2Area);

  if ((Elf1Lowest <= Elf2Lowest && Elf1Highest >= Elf2Highest) || (Elf2Lowest <= Elf1Lowest && Elf2Highest >= Elf1Highest))
  {
    part1Result++;
  }
}

System.Console.WriteLine(part1Result);

int hyphenIndex(string area)
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

int commaIndex(string area)
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

int returnLowest(string AreaWithHyphen)
{
  return int.Parse(AreaWithHyphen.Substring(0, hyphenIndex(AreaWithHyphen)));
}

int returnHighest(string AreaWithHyphen)
{
  return int.Parse(AreaWithHyphen.Substring(hyphenIndex(AreaWithHyphen) + 1, AreaWithHyphen.Length - (hyphenIndex(AreaWithHyphen) + 1)));
}
