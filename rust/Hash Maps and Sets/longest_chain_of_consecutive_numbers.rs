use std::collections::HashSet;

fn longest_chain_of_consecutive_numbers(nums: Vec<i32>) -> i32 {
    if nums.is_empty() {
        return 0;
    }
    let num_set: HashSet<i32> = nums.into_iter().collect();
    let mut longest_chain = 0;
    for num in &num_set {
        // If the current number is the smallest number in its chain, search for
        // the length of its chain
        if !num_set.contains(&(num - 1)) {
            let mut current_num = *num;
            let mut current_chain = 1;
            // Continue to find the next consecutive numbers in the chain
            while num_set.contains(&(current_num + 1)) {
                current_num += 1;
                current_chain += 1;
            }
            longest_chain = longest_chain.max(current_chain);
        }
    }
    longest_chain
}
