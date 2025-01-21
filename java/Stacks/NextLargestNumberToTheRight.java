import java.util.ArrayDeque;
import java.util.Deque;

public class NextLargestNumberToTheRight {
    public int[] nextLargestNumberToTheRight(int[] nums) {
        int[] res = new int[nums.length];
        Deque<Integer> stack = new ArrayDeque<>();
        // Find the next largest number of each element, starting with the 
        // rightmost element.
        for (int i = nums.length - 1; i >= 0; i--) {
            // Pop values from the top of the stack until the current 
            // value's next largest number is at the top.
            while (!stack.isEmpty() && stack.peek() <= nums[i]) {
                stack.pop();
            }
            // Record the current value's next largest number, which is at 
            // the top of the stack. If the stack is empty, record -1.
            res[i] = stack.isEmpty() ? -1 : stack.peek();
            stack.push(nums[i]);
        }
        return res;
    }
}
