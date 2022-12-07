
List<int> OpponentMoves = new List<int>();
List<int> MyMoves = new List<int>();

foreach (var line in File.ReadAllLines("./input.txt"))
{
  OpponentMoves.Add(GetValueOfShape(line.Substring(0, 1)));
  MyMoves.Add(GetValueOfShape(line.Substring(2, 1)));
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

int GetValueOfShape(string shape)
{
  return shape switch
  {
    "A" or "X" => 1,
    "B" or "Y" => 2,
    "C" or "Z" => 3,
    _ => 0,
  };
}

//Part 2 Code -------------------------------------------------
//1 = Rock
//2 = Paper
//3 = Scissors

//X: lose, 
//Y: draw,
//Z: win.

List<char> ExpectedOutcomes = new List<char>();

foreach (var line in File.ReadAllLines("./input.txt"))
{
  ExpectedOutcomes.Add(Char.Parse(line.Substring(2, 1)));
}

int WhatIShouldThrow(char ExpectedOutcome, int o)
{
  if (ExpectedOutcome == 'Z') //Win
  {
    return o switch
    {
      1 => 2,
      2 => 3,
      3 => 1,
      _ => 0,
    };
  }
  else if (ExpectedOutcome == 'X') //Lose
  {
    return o switch
    {
      1 => 3,
      2 => 1,
      3 => 2,
      _ => 0,
    };
  }
  else //Draw
  {
    return o;
  }
}

score = 0;
int myMove = 0;

for (int i = 0; i < OpponentMoves.Count; i++)
{
  myMove = WhatIShouldThrow((ExpectedOutcomes[i]), OpponentMoves[i]);
  score += WinDrawLoseValue(OpponentMoves[i], myMove) + myMove;
}

System.Console.WriteLine($"Final Score Part 2: {score}");