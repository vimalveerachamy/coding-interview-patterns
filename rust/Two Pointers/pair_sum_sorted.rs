fn pair_sum_sorted(nums: &[i32], target: i32) -> Vec<usize> {
    let mut left = 0;
    let mut right = nums.len() - 1;
    while left < right {
        let sum = nums[left] + nums[right];
        // If the sum is smaller, increment the left pointer, aiming
        // to increase the sum toward the target value.
        if sum < target {
            left += 1;
        } else if sum > target {
            // If the sum is larger, decrement the right pointer, aiming
            // to decrease the sum toward the target value.
            right -= 1;
        } else {
            // If the target pair is found, return its indexes.
            return vec![left, right];
        }
    }
    vec![]
}
