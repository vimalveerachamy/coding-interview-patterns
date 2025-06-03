fn triplet_sum(mut nums: Vec<i32>) -> Vec<Vec<i32>> {
    // Sort the vector
    nums.sort();
    // a + b + c = 0
    // use the pair sum sorted , b + c = -a (target);
    let len = nums.len();
    let mut result: Vec<Vec<i32>> = vec![];

    for index in 0..len - 1 {
        // To avoid duplicate triplets, skip 'a' if it's the same as 
        // the previous number.
        if index > 0 && nums[index] == nums[index - 1] {
            continue;
        }
        // Find all pairs that sum to a target of '-a' (-nums[i]).
        let triplet = pair_sum_sorted(&nums[index..], -nums[index]);
        if triplet.len() != 0 {
            result.push(triplet);
        }
    }

    result
}

fn pair_sum_sorted(remain_nums: &[i32], target: i32) -> Vec<i32> {
    let mut first_pointer = 0;
    let mut last_pointer = remain_nums.len() - 1;
    
    while first_pointer < last_pointer {
        let sum = remain_nums[first_pointer] + remain_nums[last_pointer];
        // If sum is equal to target return the  triplet [a,b,c]
        if sum == target {
            return vec![
                -target,
                remain_nums[first_pointer],
                remain_nums[last_pointer],
            ];
        } else if sum < target {
            first_pointer += 1;
        } else {
            last_pointer -= 1;
        }
    }
    // If there is no triplet return empty vector
    vec![]
}
