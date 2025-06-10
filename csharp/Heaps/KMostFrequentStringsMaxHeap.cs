public class Solution
{
    public string[] KMostFrequentStringsMaxHeap(string[] strs, int k)
    {
        Dictionary<string, int> freqs = new Dictionary<string, int>();

        PriorityQueue<string, (string str, int freq)> maxHeap = new(
            Comparer<(string str, int freq)>.Create((x, y) =>
            {
                if (x.freq == y.freq)
                    return y.str.CompareTo(x.str);

                return y.freq - x.freq;
            }));

        // Count the frequency of each string.
        foreach (string str in strs)
            freqs[str] = freqs.GetValueOrDefault(str) + 1;

        // Enqueue all the (string, frequency) pairs in the maxHeap
        // which will ensure the most frequent strs are at the top
        foreach ((string str, int freq) in freqs)
            maxHeap.Enqueue(str, (str, freq));

        // Pop the most frequent string off the heap 'k' times and return 
        // these 'k' most frequent strings.
        List<string> res = [];
        for (int i = 0; i < k && maxHeap.Count > 0; i++)
            res.Add(maxHeap.Dequeue());

        return [.. res];
    }
}
