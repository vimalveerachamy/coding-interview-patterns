use std::{
    cmp::{max, min}
};

fn largest_container(heights: Vec<i32>) -> i32 {
    let mut max_water = 0;
    let mut left = 0;
    let mut right = heights.len() - 1;

    while left < right {
        // Calculate the water contained between the current pair of lines.
        let water = min(heights[left], heights[right])
            * (right as i32 - left as i32);
            max_water = max(max_water, water);
        //  Move the pointers inward, always moving the pointer at the
        //  shorter line. If both lines have the same height, move both
        //  pointers inward.
        if heights[left] < heights[right] {
            left += 1;
        } else if heights[left] > heights[right] {
            right -= 1;
        } else {
            left += 1;
            right -= 1;
        }
    }
    max_water
}
