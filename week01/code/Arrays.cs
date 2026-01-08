public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    /// public static double[] MultiplesOf(double number, int length) | Returns a double array accepting the number you want multiples for, and the number of multiples you want, as arguments.
    /// var result = new double[length] | Creates the double array set to the number of multiples you want to know, i.e. if You are asking for 5 multiples, it'll only create an array of 5.
    /// for (int i = 1; i <= length; i++) | Run the loop for each number leading up to the length
    /// result[i-1] = number * i | assign the multiple of the number to that index minus 1 (i.e. if we are doing 7 and 5 index 0 would be 7*1 and index 4 would be 7*5)
    /// return result | return the resulting array of multiples
    public static double[] MultiplesOf(double number, int length)
    {
        var result = new double[length];
        for (int i = 1; i <= length; i++)
        {
            result[i - 1] = number * i;
        }
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // var firstElements = data.getRange(data.Count - amount, amount) gets the last elements that are moving, in order, by starting at the index of the rotation and moving to the end of the list
        // data.getRange(0, data.Count - amount) gets the rest by starting at 0 and going to the index location where the rotation starts
        // data.clear() emptys the list so we can refill with the rotated numbers
        // data.addRange(firstElements) adds the numbers which were after the rotation to the beginnning in order
        // data.addRange(restElements) adds the rest of the elements after the moved elements
        // returns nothing because it modifies the existing list
        var firstElements = data.GetRange(data.Count - amount, amount);
        var oldFirstElements = data.GetRange(0, data.Count - amount);
        data.Clear();
        data.AddRange(firstElements);
        data.AddRange(oldFirstElements);
    }
}
