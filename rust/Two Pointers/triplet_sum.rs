fn triplet_sum(mut nums: Vec<i32>) -> Vec<Vec<i32>> {
    let mut triplets: Vec<Vec<i32>> = vec![];
    nums.sort();
    let len = nums.len();

    for i in 0..len {
        // Optimization: triplets consisting of only positive numbers
        // will never sum to 0.
        if nums[i] > 0 {
            break;
        }

        // To avoid duplicate triplets, skip 'a' if it's the same as
        // the previous number.
        if i > 0 && nums[i] == nums[i - 1] {
            continue;
        }

        // Find all pairs that sum to a target of '-a' (-nums[i]).
        let pairs = pair_sum_sorted_all_pairs(&nums, i + 1, -nums[i]);
        for pair in pairs {
            triplets.push(vec![nums[i], pair[0], pair[1]]);
        }
    }

    triplets
}

fn pair_sum_sorted_all_pairs(nums: &Vec<i32>, start: usize, target: i32) -> Vec<Vec<i32>> {
    let mut pairs = Vec::new();
    let mut left = start;
    let mut right = nums.len() - 1;

    while left < right {
        let sum = nums[left] + nums[right];

        if sum == target {
            pairs.push(vec![nums[left], nums[right]]);
            left += 1;

            // To avoid duplicate '[b, c]' pairs, skip 'b' if it's the
            // same as the previous number.
            while left < right && nums[left] == nums[left - 1] {
                left += 1;
            }
        } else if sum < target {
            left += 1;
        } else {
            right -= 1;
        }
    }

    pairs
}
