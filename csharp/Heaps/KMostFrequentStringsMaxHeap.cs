using ds.Pair;

/*
    Definition of Pair:
    class Pair
    {
	    public string Str { get; }
	    public int Freq { get; }

	    public Pair(string str, int freq)
	    {
		    Str = str;
		    Freq = freq;
	    }
    }
*/

class MaxHeapPairComparer : IComparer<Pair>
{
    public int Compare(Pair a, Pair b)
    {
        // Prioritize lexicographical order for strings with equal frequencies.
        if (a.Freq == b.Freq)
            return string.Compare(a.Str, b.Str, StringComparison.Ordinal);

        // Otherwise, prioritize strings with higher frequencies.
        return b.Freq - a.Freq;
    }
}

public class Solution
{
    public string[] KMostFrequentStringsMaxHeap(string[] strs, int k)
    {
        // We use a Dictionary to count the frequency of each string.
        Dictionary<string, int> freqs = new Dictionary<string, int>();
        foreach (string str in strs)
            freqs[str] = freqs.GetValueOrDefault(str) + 1;

        // Create the max heap by adding all Pair objects.
        PriorityQueue<Pair, Pair> maxHeap = new(new MaxHeapPairComparer());
        foreach ((string str, int freq) in freqs)
            maxHeap.Enqueue(new Pair(str, freq), new Pair(str, freq));

        // Pop the most frequent strings off the heap 'k' times.
        List<string> result = new();
        for (int i = 0; i < k && maxHeap.Count > 0; i++)
            result.Add(maxHeap.Dequeue().Str);

        return result.ToArray();
    }
}