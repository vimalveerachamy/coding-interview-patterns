public class Solution
{
    public string[] KMostFrequentStringsMinHeap(string[] strs, int k)
    {
        Dictionary<string, int> freqs = new Dictionary<string, int>();

        PriorityQueue<string, (string str, int freq)> minHeap = new(
            Comparer<(string str, int freq)>.Create((x, y) =>
            {
                if (x.freq == y.freq)
                    return x.str.CompareTo(y.str);

                return x.freq - y.freq;
            }));

        // Count the frequency of each string.
        foreach (string str in strs)
            freqs[str] = freqs.GetValueOrDefault(str) + 1;

        foreach ((string str, int freq) in freqs)
        {
            minHeap.Enqueue(str, (str, freq));

            // If heap size exceeds 'k', pop the lowest frequency string to 
            // ensure the heap only contains the 'k' most frequent words so far.
            if (minHeap.Count > k)
                minHeap.Dequeue();
        }

        // Return the 'k' most frequent strings by popping the remaining 'k' 
        // strings from the heap. Since we're using a min-heap, we need to 
        // reverse the result after popping the elements to ensure the most 
        // frequent strings are listed first.
        List<string> res = [];
        for (int i = 0; i < k && minHeap.Count > 0; i++)
            res.Add(minHeap.Dequeue());

        res.Reverse();

        return [.. res];
    }
}
