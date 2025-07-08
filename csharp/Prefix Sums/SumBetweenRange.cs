public class SumBetweenRange
{
	private int[] _prefix_sum;

	public SumBetweenRange(int[] nums)
	{
		_prefix_sum = new int[nums.Length];
		_prefix_sum[0] = nums[0];

		for (int i = 1; i < nums.Length; i++)
			_prefix_sum[i] = _prefix_sum[i - 1] + nums[i];
	}

	public int SumRange(int i, int j)
	{
		if (i == 0)
			return _prefix_sum[j];

		return _prefix_sum[j] - _prefix_sum[i - 1];
	}
}