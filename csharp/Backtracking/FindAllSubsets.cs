public class Solution
{
    public int[][] FindAllSubsets(int[] nums)
    {
        List<int[]> res = new List<int[]>();
        backtrack(0, [], nums, res);

        return res.ToArray();
    }

    private void backtrack(int i, List<int> currSubset, int[] nums, IList<int[]> res)
    {
        // Base case: if all elements have been considered, add the
        // current subset to the output.
        if (i == nums.Length)
        {
            res.Add([.. currSubset]);
            return;
        }

        // Include the current element and recursively explore all paths
        // that branch from this subset.
        currSubset.Add(nums[i]);
        backtrack(i + 1, currSubset, nums, res);

        // Exclude the current element and recursively explore all paths
        // that branch from this subset.
        currSubset.RemoveAt(currSubset.Count - 1);
        backtrack(i + 1, currSubset, nums, res);
    }
}
