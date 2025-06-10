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
    public int LargestOverlapOfIntervals(Interval[] intervals)
    {
        List<(int time, char pointType)> points = [];

        foreach (Interval interval in intervals)
        {
            points.Add((interval.Start, 'S'));
            points.Add((interval.End, 'E'));
        }

        // Sort in chronological order. If multiple points occur at the same 
        // time, ensure end points are prioritized before start points.
        points.Sort((a, b) => a.time == b.time ? a.pointType.CompareTo(b.pointType) : a.time - b.time);

        int activeIntervals = 0, maxOverlaps = 0;

        foreach ((int time, int pointType) in points)
        {
            if (pointType == 'S')
                activeIntervals++;
            else
                activeIntervals--;

            maxOverlaps = Math.Max(maxOverlaps, activeIntervals);
        }

        return maxOverlaps;
    }
}
