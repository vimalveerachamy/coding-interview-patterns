public class Solution
{
    public int[][] CombinationsOfSumK(int[] nums, int target)
    {
        List<int[]> res = new List<int[]>();
        dfs([], 0, nums, target, res);

        return res.ToArray();
    }

    private void dfs(List<int> combination, int startIndex, int[] nums, int target, List<int[]> res)
    {
        // Termination condition: If the target is equal to 0, we found a combination 
        // that sums to 'k'.
        if (target == 0)
        {
            res.Add([.. combination]);
            return;
        }

        // Termination condition: If the target is less than 0, no more valid 
        // combinations can be created by adding it to the current combination.
        if (target < 0)
            return;

        // Starting from start_index, explore all combinations after adding nums[i].
        for (int i = startIndex; i < nums.Length; i++)
        {
            // Add the current number to create a new combination.
            combination.Add(nums[i]);

            // Recursively explore all paths that branch from this new combination.
            dfs(combination, i, nums, target - nums[i], res);

            // Backtrack by removing the number we just added.
            combination.RemoveAt(combination.Count - 1);
        }
    }
}
