using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        var pairs = new List<string>();
        var wordset = new HashSet<string>(words);
        foreach (var word in words)
        {
            var reversed = new string([word[1], word[0]]);
            if(word!=reversed && wordset.Contains(reversed))
            {
                if (string.Compare(word, reversed) < 0) // to avoid duplicates like "am & ma" and "ma & am"
                    pairs.Add(reversed + " & " + word);
            }
        }
        return pairs.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>(); 
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            var degree = fields[3]; 
            if (degrees.ContainsKey(degree))
            {
                degrees[degree] += 1;
            }
            else
            {
                degrees[degree] = 1;
            }
        }
        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2) // I feel like this one required me to think more out of the box than the other two before it.
    {
        word1 = word1.Replace(" ", "").ToLower(); // getting rid of spaces and lowering case
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length) { return false; } // qualifier round, if they are different lengths, they're not anagrams
        var counts = new Dictionary<char, int>(); // storing how often a letter occurs in each word, Godd and Good are not anagrams, despite having the same letters and length
        foreach (var c in word1)
        {
            if (!counts.ContainsKey(c)) { counts[c] = 0; } // increases the occurance count for each letter in word1. 
            counts[c]++;
        }
        foreach (var c in word2)
        {
            if (!counts.ContainsKey(c)) { return false; } // decreases the count for each letter in word2
            counts[c]--;

            if (counts[c] < 0 ) {return false; } // if any letter occurs more in word2 than in word1, they are not anagrams
        }
        return true; // if they pass these checks, all that can remain is that they are anagrams.
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.

        if (featureCollection?.Features == null) {return[]; } // Checking for empty data
        var results = new List<string>(); // Container for earthquakes found and there summaries
        foreach (var feature in featureCollection.Features) // Running through the earthquakes pulled
        {
            var place = feature.Properties?.Place; // Checking and getting Place Value
            var mag = feature.Properties?.Mag; // Checking and getting Magnitude Value
            if (place != null && mag.HasValue) // If both values exist, add them to results. I looked up a lot about nullables to satisfy this portion, thank you for the challenge, and extra credit opportunity!
            {
                results.Add($"Place: {place} - Mag {mag}");
            }
        }

        return results.ToArray(); 
    }
}