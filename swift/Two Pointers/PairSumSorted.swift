

func pairSumSorted(nums: [Int], target: Int) -> [Int] {
    
    guard nums.count > 0 else { return [] }
    
    var left = 0
    var right = nums.count - 1
    
    while left < right {
        let sum = nums[left] + nums[right]
        
        if sum < target {
            left += 1
        }else if sum > target {
            right -= 1
        }else { return [left, right] }
    }
    
    return []
}

