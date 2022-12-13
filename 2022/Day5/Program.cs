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

for (int i = 0; i < stacks.Count; i++)
{
  while (stacks[i].Count != 0)
  {
    System.Console.WriteLine(stacks[i].Pop().ToString());
  }
  System.Console.WriteLine("------------------");
}


