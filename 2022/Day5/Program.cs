using System.Text.RegularExpressions;

List<string> lines = new List<string>();
List<Stack<char>> stacks = new List<Stack<char>>();

// Initialise Stacks
for (int i = 0; i < 9; i++)
{
  stacks.Add(new Stack<char>());
}

// Get all lines from the input.txt file
foreach (var line in System.IO.File.ReadAllLines("./input.txt"))
{
  lines.Add(line);
}

// Get characters from each line and put them into their respective stack
for (int i = 7; i >= 0; i--)
{
  for (int j = 0; j < 9; j++)
  {
    if (char.Parse(lines[i].Substring((4 * j) + 1, 1)) != ' ')
    {
      stacks[j].Push(char.Parse(lines[i].Substring((4 * j) + 1, 1)));
    }
  }
}

int numCratesToMove = 0;
int fromStack = 0;
int toStack = 0;
Stack<char> tempCrate = new Stack<char>();
string[] numbers;

for (int i = 10; i < lines.Count; i++)
{
  numbers = Regex.Split(lines[i], @"\D+");

  numCratesToMove = int.Parse(numbers[1]);
  fromStack = int.Parse(numbers[2]);
  toStack = int.Parse(numbers[3]);

  tempCrate.Clear();

  while (numCratesToMove != 0)
  {
    tempCrate.Push(stacks[fromStack - 1].Pop());
    numCratesToMove--;
  }

  while (tempCrate.Count != 0)
  {
    stacks[toStack - 1].Push(tempCrate.Pop());
  }
}

for (int i = 0; i < stacks.Count; i++)
{
  System.Console.Write(stacks[i].Pop().ToString());
}
