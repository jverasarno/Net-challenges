public bool IsGoodFormedBraces(string sequence)
        {
            bool isGood = true;
            int openBraces = 0;
            string currentChar = "";
            string allowedOpenBraces = ",(,[,{,";
            string allowedClosedBraces = ",),],},";
            int closedBraces = 0;

            Stack<char> s = new Stack<char>();

            if (sequence.Length == 0)
                return isGood;

            for (int i = 0; i < sequence.Length; i++)
            {
                currentChar = sequence.Substring(i, 1);
                if (allowedOpenBraces.Contains(currentChar))
                {
                    openBraces++;
                    s.Push(Convert.ToChar(currentChar));
                }
                else if (allowedClosedBraces.Contains(currentChar))
                {
                    closedBraces++;
                    if (!CheckMatch(s.Pop(), Convert.ToChar(currentChar)))
                    {
                        isGood = false;
                        return isGood;
                    }
                }

                if (i>=sequence.Length-1)
                {
                    if (openBraces != closedBraces)
                    {
                        isGood = false;
                        return isGood;
                    }
                }

            }

            return isGood;


        }

        private bool CheckMatch(char a, char b)
        {
            return a == '(' && b == ')' ||
                   a == '[' && b == ']' ||
                   a == '{' && b == '}';
        }