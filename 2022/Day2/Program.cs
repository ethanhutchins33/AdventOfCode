List<string> lineInput = new List<string>();

foreach (var line in File.ReadAllLines("input.txt"))
{
  lineInput.Add(line);
}

//lineInput.ForEach(x => Console.WriteLine(x));

List<char> OpponentMoves = new List<char>();
List<char> MyMoves = new List<char>();

lineInput.ForEach(x =>
{
  OpponentMoves.Add(Char.Parse(x.Substring(0, 1)));
  MyMoves.Add(Char.Parse(x.Substring(2, 1)));
});

//OpponentMoves.ForEach(x => System.Console.WriteLine(x));
//MyMoves.ForEach(x => System.Console.WriteLine(x));

//A, X = Rock = 1
//B, Y = Paper = 2
//C, Z = Scissors = 3

int score = 0;

for (int i = 0; i < OpponentMoves.Count; i++)
{
  switch (OpponentMoves[i])
  {
    case 'A':
      if (MyMoves[i] == 'Y')
      {
        score = score + GetScoreOfMyHand(MyMoves[i]) + 6;
      }
      else if (MyMoves[i] == 'X')
      {
        score = score + 1;
      }
      else if (MyMoves[i] == 'Z')
      {
        score = score + 3;
      }
      break;
    case 'B':

      break;
    case 'C':

      break;
  }

}

static int GetScoreOfMyHand(char myMove)
{
  return myMove switch
  {
    'X' => 1,
    'Y' => 2,
    'Z' => 3,
    _ => 0,
  };
}