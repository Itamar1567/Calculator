public struct Operations
{
    public string input { get; set; }
    public String EnterInputToCalculate(string screenText)
    {
        int operandStreak = 0;
        string tempHolder = "";
        Stack<char> operators = new Stack<char>();
        Stack<float> List = new Stack<float>();
        screenText = screenText.Replace(" ", "");
        //makes sure the user does not plug in an operator at the beginning or end of the calculation
        if (IsOperator(screenText[0]) || IsOperator(screenText[screenText.Length - 1]))
        {
            //throw new Exception("Invalid Input");
            //textBoxMainScreen.Text = "Error";
            return "Error";
        }
        foreach (char charachter in screenText)
        {

            if (char.IsDigit(charachter) || charachter == '.')
            {
                operandStreak = 0;
                tempHolder += charachter;
            }
            if (IsOperator(charachter))
            {
                operandStreak += 1;
                //Makes sure the user does not plug in an operand after another such as ++ 
                if (operandStreak > 1)
                {
                    //textBoxMainScreen.Text = "Error";
                    return "Error";
                }
                List.Push(float.Parse(tempHolder));
                tempHolder = "";
                if (operators.Count == 0)
                {
                    operators.Push(charachter);
                }
                else
                {
                    //adds all operators until it reaches a lower operator(using pemdas) and then this fires off and calculates the numbers
                    while (operators.Count > 0 && Precedence(charachter) <= Precedence(operators.Peek()))
                    {
                        float a = List.Pop();
                        float b = List.Pop();
                        char op = operators.Pop();
                        //This takes in b and a and completes an operation on them (The reason for placing b before a is that a is the last number added and b is the number before it, due to stack rules, think of stacking plates)
                        List.Push(Calculate(b, a, op));
                    }

                    operators.Push(charachter);

                }

            }
        }

        if (!string.IsNullOrEmpty(tempHolder))
        {
            List.Push(float.Parse(tempHolder));
        }

        while (operators.Count > 0)
        {
            float a = List.Pop();
            float b = List.Pop();
            char op = operators.Pop();
            List.Push(Calculate(b, a, op)); // b op a
        }

        return List.Pop().ToString();


    }

    //Checks if the given character is an operand, if it is this function will return true else false
    private bool IsOperator(char ch)
    {
        return ch == '+' || ch == '-' || ch == '*' || ch == '/' || ch == '^';
    }

    //checks whether an operator is - or + in which case it would return 1, or anything else, being * / in which case it would return 2
    private int Precedence(char op)
    {
        return (op == '+' || op == '-') ? 1 : 2;
    }
    public readonly float Calculate(float a, float c, char op)
    {
        //Takes in an operand and completes its operation
        switch (op)
        {
            case '+': return a + c;
            case '-': return a - c;
            case '*': return a * c;
            case '/': return a / c;
        }

        return 0;

    }
}