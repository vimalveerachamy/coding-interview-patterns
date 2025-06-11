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

// Since this is a min-heap comparator, we define it to prioritize
// lower frequency, and in case of tie, lexicographically larger string.
class MinHeapPairComparer : IComparer<Pair>
{
    public int Compare(Pair a, Pair b)
    {
        if (a.Freq == b.Freq)
            return string.Compare(b.Str, a.Str, StringComparison.Ordinal); // Reverse order for tie

        return a.Freq - b.Freq; // Lower frequency has higher priority
    }
}

public class Solution
{
    public string[] KMostFrequentStringsMinHeap(string[] strs, int k)
    {
        // Count the frequency of each string using a dictionary.
        Dictionary<string, int> freqs = new Dictionary<string, int>();
        foreach (string str in strs)
            freqs[str] = freqs.GetValueOrDefault(str) + 1;

        // Initialize the min-heap with custom Pair comparator.
        PriorityQueue<Pair, Pair> minHeap = new(new MinHeapPairComparer());

        // Add all (string, frequency) pairs to the heap.
        foreach ((string str, int freq) in freqs)
        {
            minHeap.Enqueue(new Pair(str, freq), new Pair(str, freq));

            // If heap size exceeds 'k', pop the lowest frequency string to 
            // ensure the heap only contains the 'k' most frequent words so far.
            if (minHeap.Count > k)
                minHeap.Dequeue();
        }

        // Pop the remaining 'k' strings and reverse the result so that 
        // most frequent strings are listed first.
        List<string> result = [];
        while (minHeap.Count > 0)
            result.Add(minHeap.Dequeue().Str);

        result.Reverse();
        return result.ToArray();
    }
}