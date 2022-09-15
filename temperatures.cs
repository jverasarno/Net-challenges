using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()); // the number of temperatures to analyse
        string[] inputs = Console.ReadLine().Split(' ');
        int minValue = 0;
        

        for (int i = 0; i < n; i++)
        {
            int t = int.Parse(inputs[i]);// a temperature expressed as an integer ranging from -273 to 5526
            
             if (minValue == 0) {
                minValue = t;
            } else if (t > 0 && t <= Math.Abs(minValue)) {
                minValue = t;
            } else if (t < 0 && - t < Math.Abs(minValue)) {
                minValue = t;
            }

         
            
        }

        if (inputs.Length == 0)
            Console.WriteLine("0");
        
        Console.WriteLine(minValue.ToString());

    }
}