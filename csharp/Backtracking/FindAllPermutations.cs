public class Solution
{
    public int[][] FindAllPermutations(int[] nums)
    {
        List<int[]> res = new List<int[]>();
        backtrack(nums, [], new HashSet<int>(), res);

        return res.ToArray();
    }

    private void backtrack(int[] nums, List<int> candidate, HashSet<int> used, List<int[]> res)
    {
        // If the current candidate is a complete permutation, add it to the result.
        if (candidate.Count == nums.Length)
        {
            res.Add([.. candidate]);
            return;
        }

        foreach (int num in nums)
        {
            if (!used.Contains(num))
            {
                // Add 'num' to the current permutation and mark it as used.
                candidate.Add(num);
                used.Add(num);

                // Recursively explore all branches using the updated permutation candidate.
                backtrack(nums, candidate, used, res);

                // Backtrack by reversing the changes made.
                candidate.RemoveAt(candidate.Count - 1);
                used.Remove(num);
            }
        }
    }
}
