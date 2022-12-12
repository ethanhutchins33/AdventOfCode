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
  Elf1Area = convertHyphenToInLineString(
    AreasToClean[i]
    .Substring(
      0,
      commaIndex(AreasToClean[i])
    )
  );

  Elf2Area = convertHyphenToInLineString(
    AreasToClean[i]
    .Substring(
      (commaIndex(AreasToClean[i]) + 1),
      AreasToClean[i].Length - (commaIndex(AreasToClean[i]) + 1)
    )
  );

  System.Console.WriteLine($"Elf1Area: {Elf1Area}");
  System.Console.WriteLine($"Elf2Area: {Elf2Area}");

  if (Elf1Area.Contains(Elf2Area) || Elf2Area.Contains(Elf1Area))
  {
    System.Console.WriteLine("Match!");
    part1Result++;
    System.Console.WriteLine($"Part 1 Answer: {part1Result}");
  }
}

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


string convertHyphenToInLineString(string AreaWithHyphen)
{
  int hyIndex = hyphenIndex(AreaWithHyphen);

  int num1 = int.Parse(AreaWithHyphen.Substring(0, hyIndex));
  int num2 = int.Parse(AreaWithHyphen.Substring(hyIndex + 1, AreaWithHyphen.Length - (hyIndex + 1)));

  string result = "";

  for (int i = num1; i <= num2; i++)
  {
    result = result + i.ToString();
  }

  return result;

}

