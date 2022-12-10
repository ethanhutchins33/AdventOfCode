List<string> LeftCompartments = new List<string>();
List<string> RightCompartments = new List<string>();

foreach (string line in System.IO.File.ReadAllLines("./input.txt"))
{
  LeftCompartments.Add(line.Substring(0, line.Length / 2));
  RightCompartments.Add(line.Substring(line.Length / 2, line.Length / 2));
}

List<char> repeatingChars = new List<char>();
bool matchFound = false;

for (int i = 0; i < LeftCompartments.Count(); i++)
{
  matchFound = false;
  //System.Console.WriteLine($"Left: {LeftCompartments[i]}, Right: {RightCompartments[i]}");

  foreach (var characterL in LeftCompartments[i])
  {
    foreach (var characterR in RightCompartments[i])
    {
      //.Console.WriteLine($"LeftChar: {characterL}, RightChar: {characterR}");

      if (characterL == characterR)
      {
        repeatingChars.Add(characterL);
        //System.Console.WriteLine($"Match Found! {characterL} == {characterR} => {ReturnValueOfChar(characterL)}");
        matchFound = true;
        break;
      }
    }

    if (matchFound)
    {
      break;
    }
  }
}

int ReturnValueOfChar(char x)
{
  if (Char.IsUpper(x))
  {
    return (int)x - 38;
  }
  else
  {
    return (int)x - 96;
  }
}

int result = 0;

repeatingChars.ForEach(x => result += ReturnValueOfChar(x));

System.Console.WriteLine($"Part 1: {result}");


// Part 2 ---------------------------------------------------------------


List<string> ElfBagContents = new List<string>();

foreach (var line in File.ReadAllLines("./input.txt"))
{
  ElfBagContents.Add(line);
}

List<char> Badges = new List<char>();
bool BadgeFound = false;

for (int i = 0; i < ElfBagContents.Count(); i += 3)
{
  BadgeFound = false;
  foreach (var Elf1Item in ElfBagContents[i])
  {
    foreach (var Elf2Item in ElfBagContents[i + 1])
    {
      if (Elf1Item == Elf2Item)
      {
        foreach (var Elf3Item in ElfBagContents[i + 2])
        {
          if (Elf1Item == Elf2Item && Elf2Item == Elf3Item)
          {
            Badges.Add(Elf1Item);
            BadgeFound = true;
          }
          if (BadgeFound) { break; }
        }
      }
      if (BadgeFound) { break; }
    }
    if (BadgeFound) { break; }
  }
}

int result2 = 0;

Badges.ForEach(x =>
{
  result2 += ReturnValueOfChar(x);
});

System.Console.WriteLine($"Part 2: {result2}");
