public class Solution
{
	public int[] ProductArrayWithoutCurrentElement(int[] nums)
	{
		int n = nums.Length;

		int[] res = new int[n];
		Array.Fill<int>(res, 1);

		// Populate the output with the running left product.
		for (int i = 1; i < n; i++)
			res[i] = res[i - 1] * nums[i - 1];

		// Multiply the output with the running right product, from right to left.
		int right_product = 1;

		for (int i = n - 1; i >= 0; i--)
		{
			res[i] *= right_product;
			right_product *= nums[i];
		}

		return res;
	}
}