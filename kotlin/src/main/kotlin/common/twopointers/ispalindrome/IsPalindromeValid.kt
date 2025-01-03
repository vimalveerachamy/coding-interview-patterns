package common.twopointers.ispalindrome

class IsPalindromeValid {

    fun solution(s: String): Boolean {
        var left = 0
        var right = s.length - 1
        while (left < right) {
            while (left < right && !s[left].isLetterOrDigit()) {
                left++
            }
            while (left < right && !s[right].isLetterOrDigit()) {
                right--
            }
            if (s[left] != s[right]) {
                return false
            }
            left++
            right--
        }
        return true
    }
}