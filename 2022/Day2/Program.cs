
List<int> OpponentMoves = new List<int>();
List<int> MyMoves = new List<int>();

foreach (var line in File.ReadAllLines("./input.txt"))
{
  OpponentMoves.Add(GetValueOfHand(line.Substring(0, 1)));
  MyMoves.Add(GetValueOfHand(line.Substring(2, 1)));
}

int score = 0;
for (int i = 0; i < OpponentMoves.Count; i++)
{
  score += WinDrawLoseValue(OpponentMoves[i], MyMoves[i]) + MyMoves[i];
}

System.Console.WriteLine($"Final Score Part 1: {score}");

int WinDrawLoseValue(int o, int m)
{
  if (o == m)
  {
    return 3;
  }
  else if ((o - ((m + 1) % 3)) == 1)
  {
    return 6;
  }
  else
  {
    return 0;
  }
}

int GetValueOfHand(string hand)
{
  return hand switch
  {
    "A" or "X" => 1,
    "B" or "Y" => 2,
    "C" or "Z" => 3,
    _ => 0,
  };
}

//Part 2 Code
