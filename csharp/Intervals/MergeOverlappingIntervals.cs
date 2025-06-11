using ds.Interval;

/*
	Definition of Interval:
	class Interval
    {
        public Interval(int start, int end)
        {
            Start = start; 
            End = end;
        }

        public int Start { get; set; }

        public int End { get; set; }
    }
*/

public class Solution
{
    public Interval[] MergeOverlappingIntervals(Interval[] intervals)
    {
        Array.Sort(intervals, (a, b) => a.Start - b.Start);
        List<Interval> merged = [intervals[0]];

        foreach (Interval B in intervals[1..])
        {
            Interval A = merged[^1];

            // If A and B don't overlap, add B to the merged list.
            if (A.End < B.Start)
                merged.Add(B);
            // If they do overlap, merge A with B.
            else
                merged[^1] = new Interval(A.Start, Math.Max(A.End, B.End));
        }

        return [.. merged];
    }
}
