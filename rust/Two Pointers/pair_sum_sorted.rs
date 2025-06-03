fn pair_sum_sorted(nums: &[i32], target: i32) -> Vec<usize> {
    let mut first_pointer = 0;
    let mut last_pointer = nums.len() - 1;
    while first_pointer < last_pointer {
        let first_value = nums[first_pointer];
        let last_value = nums[last_pointer];
        let cur_sum = first_value + last_value;
        // If the sum is smaller, increment the left pointer, aiming
        // to increase the sum toward the target value.
        if cur_sum < target {
            first_pointer += 1;
        } else if cur_sum > target {
            // If the sum is larger, decrement the right pointer, aiming
            // to decrease the sum toward the target value.
            last_pointer -= 1;
        } else {
            // If the target pair is found, return its indexes.
            return vec![first_pointer, last_pointer];
        }
    }
    vec![]
}
