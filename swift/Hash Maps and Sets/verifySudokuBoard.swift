//
//  verifySudokuBoard.swift
//  
//
//  Created by Vimal Veerachamy on 9/28/25.
//

func isValidSudoku(_ board: [[Character]]) -> Bool {

    let count = board.count
    
    //Initialize row, col and grid with Set
    var row_sets = Array(repeating: Set<Character>(), count: count)
    var col_sets = Array(repeating: Set<Character>(), count: count)
    var grid_sets = Array(repeating: Set<Character>(), count: count)
    
    for r in 0..<board.count {
        for c in 0..<board.count {
            let char = board[r][c]
            let idx = (r / 3) * 3 + (c / 3)
            
            //Skip if char == "."
            if char == "." { continue }
            
            //Return invalid state if any row or col or grid contains duplicate
            if row_sets[r].contains(char) { return false }
            if col_sets[c].contains(char) { return false }
            if grid_sets[idx].contains(char) { return false }
            
            row_sets[r].insert(char)
            col_sets[c].insert(char)
            grid_sets[idx].insert(char)
            
        }
    }
    
    return true
}
