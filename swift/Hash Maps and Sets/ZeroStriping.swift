//
//  ZeroStriping.swift
//  
//
//  Created by Vimal Veerachamy on 9/28/25.
//

func setZeroes(_ matrix: inout [[Int]]) {
    
    var rows_set = Set<Int>()
    var col_sets = Set<Int>()
    
    //Record all row and col whose values equals to 0
    for r in 0..<matrix.count {
        for c in 0..<matrix.first!.count {
            if matrix[r][c] == 0 {
                rows_set.insert(r)
                col_sets.insert(c)
            }
        }
    }
    
    //Scan and set all row and col values to 0 if any rows or columns have contain 0
    for r in 0..<matrix.count {
        for c in 0..<matrix.first!.count {
            if rows_set.contains(r) || col_sets.contains(c) {
                matrix[r][c] = 0
            }
        }
    }
}
