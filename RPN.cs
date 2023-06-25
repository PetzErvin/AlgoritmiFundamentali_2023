static void RPNProblem(string toEval)
{
    Console.WriteLine(EvaluateRPN(ToRPN(toEval)));
}
static string EvaluateRPN(string RPNString)
{
    string[] tokens = RPNString.Split(' ');
    Stack<string> stack = new Stack<string>();
    foreach (string token in tokens)
    {
        if (int.TryParse(token, out int value))
        {
            stack.Push(token);
        }
        else if (token == "+")
        {
            int x1 = int.Parse(stack.Pop());
            int x2 = int.Parse(stack.Pop());
            stack.Push((x2 + x1).ToString());
        }
        else if (token == "-")
        {
            int x1 = int.Parse(stack.Pop());
            int x2 = int.Parse(stack.Pop());
            stack.Push((x2 - x1).ToString());
        }
        else if (token == "*")
        {
            int x1 = int.Parse(stack.Pop());
            int x2 = int.Parse(stack.Pop());
            stack.Push((x2 * x1).ToString());
        }
        else if (token == "/")
        {
            int x1 = int.Parse(stack.Pop());
            int x2 = int.Parse(stack.Pop());
            stack.Push((x2 / x1).ToString());
        }
    }
    return stack.Pop();
}
static string ToRPN(string toEval)
{
    string result = string.Empty;
    string[] tokens = toEval.Split(' ');
    Stack<string> ops = new Stack<string>();
    Stack<string> output = new Stack<string>();

    int i = 0;
    while (i < tokens.Length)
    {
        string token = tokens[i];
        if (int.TryParse(token, out int value))
        {
            output.Push(token);
        }
        else if (token == "+" || token == "-" || token == "*" || token == "/")
        {
            while (ops.Any() && ops.Peek() != "(" && GetPriority(ops.Peek()) >= GetPriority(token))
            {
                output.Push(ops.Pop());
            }
            ops.Push(token);
        }
        else if (token == "(")
        {
            ops.Push(token);
        }
        else // ")"
        {
            while (ops.Any() && ops.Peek() != "(")
            {
                output.Push(ops.Pop());
            }
            ops.Pop();
        }
        i++;
    }
    while (ops.Count > 0)
    {
        output.Push(ops.Pop());
    }

    while (output.Count > 0)
    {
        ops.Push(output.Pop());
    }

    while (ops.Count > 0)
    {
        result += ops.Pop() + " ";
    }

    return result;
}
static int GetPriority(string op)
{
    if (op == "+" || op == "-")
    {
        return 0;
    }
    else return 1;
}