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
  System.Console.WriteLine($"Left: {LeftCompartments[i]}, Right: {RightCompartments[i]}");

  foreach (var characterL in LeftCompartments[i])
  {
    foreach (var characterR in RightCompartments[i])
    {
      System.Console.WriteLine($"LeftChar: {characterL}, RightChar: {characterR}");

      if (characterL == characterR)
      {
        repeatingChars.Add(characterL);
        System.Console.WriteLine($"Match Found! {characterL} == {characterR} => {ReturnValueOfChar(characterL)}");
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