//
//  LargestContainer.swift
//  
//
//  Created by Vimal Veerachamy on 9/28/25.
//

func maxArea(_ height: [Int]) -> Int {
    
    var left = 0
    var right = height.count - 1
    var max_area = 0
    
    while left < right {
        
        //Calculate max_area based on current pair
        max_area = max(max_area, min(height[left], height[right]) * (right - left))
        
        //Adjust the pointer inwards based on height's position
        if height[left] < height[right] {
            left += 1
        }else if height[left] > height[right] {
            right -= 1
        }else {
            left += 1
            right -= 1
        }
    }

    return max_area
}
