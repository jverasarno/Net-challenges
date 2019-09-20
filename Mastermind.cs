using System.Collections.Generic;
using System.Linq;

class Mastermind
{
    private List<CodePeg> code;

    public Mastermind(List<CodePeg> code)
    {
        this.code = code;
    }

    public List<ResultPeg> GetHints(List<CodePeg> guess)
    {
        // Implement the logic here
        List<ResultPeg> resultPegs = new List<ResultPeg>();

        //IF BOTH LIST ARE THE SAME RETURN ALL BLACK, SAME ORDER AND SAME COLOR
        if (guess.SequenceEqual(code))
        {
            for (int i = 0; i<code.Count;i++)
                resultPegs.Add(ResultPeg.Black);
            return resultPegs;
        }

        for (int j = 0; j < code.Count; j++)
        {    
            //IF CURRENT COLOR IS CONTAINED
            if (guess.Contains(code[j]))
                //IF COLOR IN BOTH LIST ARE DIFFERENT ADD WHITE, ELSE ADD BLACK
                if (guess[j] != code[j])
                    resultPegs.Add(ResultPeg.White);
                else
                    resultPegs.Add(ResultPeg.Black);

        }

        return resultPegs;
    }
}

enum CodePeg {
    Black,
    Blue,
    Green,
    Red,
    White,
    Yellow,
}

enum ResultPeg {
    Black,
    White,
}

