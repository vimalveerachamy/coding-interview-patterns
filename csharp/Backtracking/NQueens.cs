public class Solution
{
    int res = 0;

    public int NQueens(int n)
    {
        dfs(0, new HashSet<int>(), new HashSet<int>(), new HashSet<int>(), n);

        return res;
    }

    private void dfs(int r, ISet<int> diagonalsSet, ISet<int> antiDiagonalsSet, ISet<int> colsSet, int n)
    {
        // Termination condition: If we have reached the end of the rows,
        // we've placed all 'n' queens.
        if (r == n)
        {
            res++;
            return;
        }

        for (int c = 0; c < n; c++)
        {
            int currDiagonal = r - c;
            int currAntiDiagonal = r + c;

            // If there are queens on the current column, diagonal or
            // anti−diagonal, skip this square.
            if (colsSet.Contains(c) ||
                diagonalsSet.Contains(currDiagonal) ||
                antiDiagonalsSet.Contains(currAntiDiagonal))
                continue;

            // Place the queen by marking the current column, diagonal, and
            // anti −diagonal as occupied.
            colsSet.Add(c);
            diagonalsSet.Add(currDiagonal);
            antiDiagonalsSet.Add(currAntiDiagonal);

            // Recursively move to the next row to continue placing queens.
            dfs(r + 1, diagonalsSet, antiDiagonalsSet, colsSet, n);

            // Backtrack by removing the current column, diagonal, and
            // anti −diagonal from the hash sets.
            colsSet.Remove(c);
            diagonalsSet.Remove(currDiagonal);
            antiDiagonalsSet.Remove(currAntiDiagonal);
        }
    }
}
