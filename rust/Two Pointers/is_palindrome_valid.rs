fn is_palindrome_valid(s: &str) -> bool {
    let chars: Vec<_> = s.chars().collect();
    let mut left = 0;
    let mut right = s.len() - 1;
    while left < right {
        // Skip non-alphanumeric characters from the left.
        while left < right && !chars[left].is_alphanumeric(){
            left += 1
        }       
        // Skip non-alphanumeric characters from the right.
        while left < right && !chars[right].is_alphanumeric(){
            right -= 1
        }
        // If the characters at the left and right pointers don't
        // match, the string is not a palindrome.
        if chars[left] != chars[right] {
            return false;
        }
        left += 1;
        right -= 1;
    }
    true
}
