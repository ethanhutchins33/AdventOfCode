List<string> LeftCompartments = new List<string>();
List<string> RightCompartments = new List<string>();

foreach (string line in System.IO.File.ReadAllLines("./input.txt"))
{
  LeftCompartments.Add(line.Substring(0, line.Length / 2));
  RightCompartments.Add(line.Substring(line.Length / 2, line.Length / 2));
}

char Get()
{

  char charL = Char.Parse(LeftCompartments[0].Substring(0, 1));
  char charR = Char.Parse(RightCompartments[0].Substring(0, 1));
  if (charL == charR)
  {
    return charL;
  }

}
foreach (var charL in LeftCompartments)
{
  foreach (var charR in RightCompartments)
  {
    if (charL == charR)
    {

    }
  }
}

