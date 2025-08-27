use std::collections::HashSet;

fn verify_sudoku_board(board: Vec<Vec<i32>>) -> bool {
    // Create hash sets for each row, column, and subgrid to keep
    // track of numbers previously seen on any given row, column, or
    // subgrid.
    let mut row_sets: Vec<HashSet<i32>> = vec![HashSet::new(); 9];
    let mut column_sets: Vec<HashSet<i32>> = vec![HashSet::new(); 9];
    let mut subgrid_sets: Vec<Vec<HashSet<i32>>> = vec![vec![HashSet::new(); 3]; 3];
    for r in 0..9 {
        for c in 0..9 {
            let num = board[r][c];
            if num == 0 {
                continue;
            }
            // Check if 'num' has been seen in the current row,
            // column, or subgrid.
            if row_sets[r].contains(&num) {
                return false;
            }
            if column_sets[c].contains(&num) {
                return false;
            }
            if subgrid_sets[r / 3][c / 3].contains(&num) {
                return false;
            }
            // If we passed the above checks, mark this value as seen
            // by adding it to its corresponding hash sets.
            row_sets[r].insert(num);
            column_sets[c].insert(num);
            subgrid_sets[r / 3][c / 3].insert(num);
        }
    }
    true
}
