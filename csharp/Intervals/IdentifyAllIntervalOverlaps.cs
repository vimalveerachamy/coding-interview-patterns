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
    public Interval[] IdentifyAllIntervalOverlaps(Interval[] intervals1, Interval[] intervals2)
    {
        List<Interval> overlaps = [];
        int i = 0, j = 0;

        while (i < intervals1.Length && j < intervals2.Length)
        {
            Interval A = intervals1[i], B = intervals2[j];

            // Set A to the interval that starts first and B to the other interval.
            if (intervals1[i].Start <= intervals2[j].Start)
                (A, B) = (intervals1[i], intervals2[j]);
            else
                (A, B) = (intervals2[j], intervals1[i]);

            // If there's an overlap, add the overlap.
            if (A.End >= B.Start)
                overlaps.Add(new Interval(B.Start, Math.Min(A.End, B.End)));

            // Advance the pointer associated with the interval that ends first.
            if (intervals1[i].End < intervals2[j].End)
                i++;
            else
                j++;
        }

        return [.. overlaps];
    }
}
