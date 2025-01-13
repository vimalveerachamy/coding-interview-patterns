public class SubstringAnagrams {
    public int substringAnagrams(String s, String t) {
        int lenS = s.length();
        int lenT = t.length();
        if (lenT > lenS) return 0;
        int count = 0;
        int[] expectedFreqs = new int[26];
        int[] windowFreqs = new int[26];
        // Populate 'expected_freqs' with the characters in string 't'.
        for (char c : t.toCharArray()) {
            expectedFreqs[c - 'a'] += 1;
        }
        int left, right;
        left = right = 0;
        while (right < lenS) {
            // Add the character at the right pointer to 'window_freqs' 
            // before sliding the window.
            windowFreqs[s.charAt(right) - 'a'] += 1;
            // If the window has reached the expected fixed length, we 
            // advance the left pointer as well as the right pointer to 
            // slide the window.
            if (right - left + 1 == lenT) {
                if (compareFreqs(windowFreqs, expectedFreqs)) {
                    count += 1;
                }
                // Remove the character at the left pointer from 
                // 'window_freqs' before advancing the left pointer.
                windowFreqs[s.charAt(left) - 'a'] -= 1;
                left += 1;
            }
            right += 1;
        }
        return count;
    }

    private boolean compareFreqs(int[] windowFreqs, int[] expectedFreqs) {
        for (int i = 0; i < 26; i++) {
            if (windowFreqs[i] != expectedFreqs[i]) return false;
        }
        return true;
    }
}
