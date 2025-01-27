function is_palindrome_valid(s: string): boolean {
    let left = 0, right = s.length - 1
    while (left < right) {
        // Skip non-alphanumeric characters from the left. 
        while (left < right && !isalnum(s[left]))
            left++
        // Skip non-alphanumeric characters from the right.
        while (left < right && !isalnum(s[right]))
            right--
        // If the characters at the left and right pointers don't
        // match, the string is not a palindrome.
        if (s[left] !== s[right])
            return false
        left++
        right--
    }
    return true
}

const isalnum = (c: string): boolean => /^[a-z0-9]+$/i.test(c);
