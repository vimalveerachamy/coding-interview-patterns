public class Solution
{
    public string[] PhoneKeypadCombinations(string digits)
    {
        Dictionary<char, string> keypadMap = new Dictionary<char, string>
        {
            ['2'] = "abc",
            ['3'] = "def",
            ['4'] = "ghi",
            ['5'] = "jkl",
            ['6'] = "mno",
            ['7'] = "pqrs",
            ['8'] = "tuv",
            ['9'] = "wxyz"
        };

        List<string> res = new List<string>();
        backtrack(0, [], digits, keypadMap, res);

        return res.ToArray();
    }

    private void backtrack(int i, List<char> currCombination, string digits, Dictionary<char, string> keypadMap, List<string> res)
    {
        // Termination condition: if all digits have been considered, add the
        // current combination to the output list.
        if (i == digits.Length)
        {
            res.Add(string.Join("", currCombination));
            return;
        }

        foreach (char letter in keypadMap[digits[i]])
        {
            // Add the current letter.
            currCombination.Add(letter);

            // Recursively explore all paths that branch from this combination.
            backtrack(i + 1, currCombination, digits, keypadMap, res);

            // Backtrack by removing the letter we just added.
            currCombination.RemoveAt(currCombination.Count - 1);
        }
    }
}
