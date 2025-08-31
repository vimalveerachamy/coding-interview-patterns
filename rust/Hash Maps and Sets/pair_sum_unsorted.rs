use std::collections::HashMap;

pub fn pair_sum_unsorted(nums: &[i32], target: i32) -> Vec<i32> {
    let mut hashmap: HashMap<i32, i32> = HashMap::new();
    for (i, &x) in nums.iter().enumerate() {
        let complement = target - x;
        if let Some(&complement_idx) = hashmap.get(&complement) {
            return vec![complement_idx, i as i32];
        }
        hashmap.insert(x, i as i32);
    }
    vec![]
}
