fn is_palindrome_valid(s: &str) -> bool {
    // Edge case
    if s.len() == 0 || s.len() == 1 {
        return true;
    }

    let chars: Vec<_> = s.chars().collect();
    let mut first_pointer = 0;
    let mut last_pointer = s.len() - 1;
    while first_pointer < last_pointer {
        // Skip non-alphanumeric characters from the left. 
        let first_char = chars[first_pointer];
        if !first_char.is_alphanumeric() {
            first_pointer += 1;
            continue;
        }

        // Skip non-alphanumeric characters from the right.
        let last_char = chars[last_pointer];
        if !last_char.is_alphanumeric() {
            last_pointer -= 1;
            continue;
        }

        // If the characters at the left and right pointers don't
        // match, the string is not a palindrome.
        if first_char.to_ascii_lowercase() != last_char.to_ascii_lowercase() {
            return false;
        }

        // Shrink the pointers
        first_pointer += 1;
        last_pointer -= 1;
    }
    true
}
