using System.Collections;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Markup;
using NuGet.Frameworks;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;
        
        return n * n + SumSquaresRecursive(n-1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            char currLetter = letters[i];
            string remaining = letters.Remove(i, 1);
            PermutationsChoose(results, remaining, size, word + currLetter);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        remember ??= new Dictionary<int, decimal>();
        if(remember.ContainsKey(s))
        {
            return remember[s];
        }

        // Solve using recursion
        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);

        // CountWaysToClimb(5) = (13)
        // CountWaysToClimb(4) + 4 + 2
        // 4 + 2 + 1 + 4 + 2

        /* CountWaysToClimb(9) = 
        * CountWaysToClimb(8) + CountWaysToClimb(7) + CountWaysToClimb(6)
        * CountWaysToClimb(7) {Which it is about to calculate} + CountWaysToClimb(6) {Which it is about to Calculate} + CountWaysToClimb(5) {Which is 12}
        * CountWaysToClimb(6) {Third Time this function was called exactly the same way} + CountWaysToClimb(5) {Which we know is 12} + CountWaysToClimb(4) {Which we know is 6}
        * CountWaysToClimb(5) {Which is 12} + CountWaysToClimb(4) {Which is 6} + CountWaysToClimb(3) {Which automatically returns 4} {So we now know "CountWaysToClimb(6)" = 22}
        * CountWaysToClimb(4) + CoutWaysToClimb(3) {Which we know is 4} + CountWaysToClimb(2) {Which we know is 2}
        * CountWaysToClimb(3) {Which is automatically given 4} + CountWaysToClimb(2) {Which is automatically given the value 2} + CountWaysToClimb(1) {Which is automaticaly given the value 1}
        * So now we know that CountWaysToClimb(4) = 4 + 2 + 1 or 7, meaning (5) is 7 + 4 + 2 = 13, (6) is 13 + 7 + 2 = 22
        * Meaning CountWaysToClimb(7) = 22 + 13 + 6 = 41, so CountWaysToClimb(8) = 41 + 22 + 13 = 76, Meaning CountWaysToClimb(9) = 76 + 41 + 22 = 149 with Monetization*/

        remember[s] = ways; // Saving the value to the future calls
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // Base Case
        if (!pattern.Contains('*'))
        {
            results.Add(pattern);
            return;
        }

        int wildcardIndex = pattern.IndexOf('*'); // Finding a single wildcard, recursion will have it pull a new wildcard each time until there is none

        string pattern0 = pattern[..wildcardIndex] + '0' + pattern[(wildcardIndex + 1)..]; // Replacing with 0
        string pattern1 = pattern[..wildcardIndex] + '1' + pattern[(wildcardIndex + 1)..]; // Replacing with 1

        WildcardBinary(pattern0, results); // Running Recursion Loops to check if this is the last wildCard  
        WildcardBinary(pattern1, results); // Replacing with both a 1 and a 0 so I get both options in the results List.
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        if (currPath == null) {
            currPath = new List<ValueTuple<int, int>>();
        }
        // currPath.Add((1,2)); // Use this syntax to add to the current path
        currPath.Add((x, y)); // adding the starting position and subsequent moves

        // Base Case // results.Add(currPath.AsString()); // Use this to add your path to the results array keeping track of complete maze solutions when you find the solution.
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1); //Back Tracking
            return;
        }
        
        var up = x - 1;
        var down = x + 1;
        var right = y + 1;
        var left = y - 1;

        // Checking both, if there is a valid move and if we would be moving just back and forth.     
        if (maze.IsValidMove(currPath, up, y))
            if (!(x == down))
                SolveMaze(results, maze, up, y, currPath);
        if (maze.IsValidMove(currPath, down, y))
            if (!(x == up))
                SolveMaze(results, maze, down, y, currPath);
        if (maze.IsValidMove(currPath, x, left))
            if (!(y == right))
                SolveMaze(results, maze, x, left, currPath);
        if (maze.IsValidMove(currPath, x, right))
            if (!(y == left))
                SolveMaze(results, maze, x, right, currPath);

        currPath.RemoveAt(currPath.Count - 1); // BackTracking to keep the path clean
    }
}