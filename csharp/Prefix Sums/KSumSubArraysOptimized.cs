public class Solution
{
	public int KSumSubArraysOptimized(int[] nums, int k)
	{
		int count = 0;

		// Initialize the map with 0 to handle subarrays that sum to 'k' 
		// from the start of the array.
		Dictionary<int, int> prefixSumMap = new Dictionary<int, int>
		{
			[0] = 1
		};

		int currPrefixSum = 0;

		foreach (int num in nums)
		{
			// Update the running prefix sum by adding the current number.
			currPrefixSum += num;

			// If a subarray with sum 'k' exists, increment 'count' by the 
			// number of times it has been found.
			if (prefixSumMap.ContainsKey(currPrefixSum - k))
				count += prefixSumMap[currPrefixSum - k];

			// Update the frequency of 'curr_prefix_sum' in the hash map.
			int freq = prefixSumMap.GetValueOrDefault(currPrefixSum, 0);
			prefixSumMap[currPrefixSum] = freq + 1;
		}

		return count;
	}
}