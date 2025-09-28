//
//  TripletSum.swift
//  
//
//  Created by Vimal Veerachamy on 9/28/25.
//

func tripletSum(_ nums: [Int]) -> [[Int]] {
    let nums = nums.sorted()
    let count = nums.count
    var results = [[Int]]()
    
    for i in 0..<count - 1 {
        //Optimized to avoid duplicates
        if i > 0 && nums[i] == nums[i - 1] { continue }
        
        //Pairs for two sum with target
        let pairs = pairSumSorted(nums: nums, start: i + 1, target: -nums[i])
        
        //Add Triplet's pairs to result array
        for pair in pairs where pair.count > 1 {
            results.append([nums[i], pair[0], pair[1]])
        }
    }

    return results
}


func pairSumSorted(nums: [Int], start: Int, target: Int) -> [[Int]] {
    
    guard nums.count > 0 else { return [] }
    
    var pairs = [[Int]]()
    var left = start
    var right = nums.count - 1
    
    while left < right {
        let sum = nums[left] + nums[right]
        
        if sum == target {
            pairs.append([nums[left], nums[right]])
            left += 1
            
            //Skip duplicate along left pointer traversal
            while left < right && nums[left] == nums[left - 1] {
                left += 1
            }
            
        }else if sum < target {
            left += 1
        }else {
            right -= 1
        }
    }
    
    return pairs
}
