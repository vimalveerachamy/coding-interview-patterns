public class Solution
{
	public int KSumSubArrays(int[] nums, int k)
	{
		int n = nums.Length;
		int count = 0;

		// Populate the prefix sum array, setting its first element to 0.
		int[] prefix_sum = new int[n + 1];
		prefix_sum[0] = 0;

		for (int i = 0; i < n; i++)
			prefix_sum[i + 1] = prefix_sum[i] + nums[i];

		// Loop through all valid pairs of prefix sum values to find all 
		// subarrays that sum to 'k'.
		for (int j = 1; j <= n; j++)
		{
			for (int i = 1; i <= j; i++)
			{
				if (prefix_sum[j] - prefix_sum[i - 1] == k)
					count++;
			}
		}

		return count;
	}
}