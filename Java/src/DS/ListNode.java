package DS;

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val) { this.val = val; }
    public ListNode(int val, ListNode next) {
        this(val);
        this.next = next;
    }
}

