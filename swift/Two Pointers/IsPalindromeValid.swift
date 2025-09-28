//
//  IsPalindromeValid.swift
//  
//
//  Created by Vimal Veerachamy on 9/28/25.
//

func isPalindrome(_ s: String) -> Bool {
    //Convert s "String" to Character with lowercase
    let chars = Array(s).map { Character($0.lowercased()) }
    var left = 0
    var right = chars.count - 1
    
    //Iterate character collection with two pointer
    while left < right {
        
        //Shift left pointer to next char if char is NOT alphanumeric
        while left < right && !(chars[left].isLetter || chars[left].isNumber) {
            left += 1
        }
        
        //Shift right pointer to next char if char is NOT alphanumeric
        while left < right && !(chars[right].isLetter || chars[right].isNumber) {
            right -= 1
        }
        
        //Return false if character doesn't match between left and right
        if chars[left] != chars[right] { return false }
        else {
            left += 1
            right -= 1
        }
    }

    return true
}
