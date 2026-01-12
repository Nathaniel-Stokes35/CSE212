using System;
using System.Collections.Generic;

class D
{
    public static void Run()
    {
        int[] d = R(5); // Randomly roll 5 dice
        Array.Sort(d); // Sort array from lowest to highest
        Console.WriteLine("Values: " + string.Join(", ", d)); // Display the values
        int s = C(d); // Calculate the score
        Console.WriteLine("Total: " + s); // write out the score
    }

    static int[] R(int n)
    {
        Random r = new Random();
        int[] d = new int[n]; // container for the random numbers
        for (int i = 0; i < n; i++) // run for each roll
        {
            d[i] = r.Next(1, 7); // get a random number between 1 and 6
        }
        return d; // return the array of random numbers
    }

    static int C(int[] d)
    {
        int s = 0; // Empty Score Container
        Dictionary<int, int> c = new Dictionary<int, int>(); // Create a dictionary to count occurrences | <Face Value>,<Count> |
        foreach (int x in d) // Counting occurrences of values
        {
            if (c.ContainsKey(x))
            {
                c[x]++; // Increment count if key exists
            }
            else
            {
                c[x] = 1; // If key doesn't exist, set count to 1
            }
        }
        foreach (int v in c.Values) // Calculate score based on occurrences
        {
            switch (v)
            {
                case 2: // If two occurances of the same number increase score by 10
                    s += 10;
                    break;
                case 3: // If three occurances of the same number increase score by 20
                    s += 20;
                    break;
                case 4: // If four occurances of the same number increase score by 30
                    s += 30;
                    break;
                case 5: // If five occurances of the same number increase score by 40
                    s += 40;
                    break;
            }
        }
        return s;
    }
}