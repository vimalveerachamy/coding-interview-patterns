package CodeRunner;

import DS.*;
import LinkedLists.*;
import java.util.*;

public class LinkedListsRunner {
    // Code runner
    public static void main(String[] args) {

        // System.out.println(testFlattenMultiLevelList());

        // System.out.println(testLinkedListIntersection());

        // System.out.println(testLinkedListReversal());

        // System.out.println(testLinkedListReversalRecursive());

        // System.out.println(testLRUCache());

    }

    private static boolean testFlattenMultiLevelList() {

        // Visual Representation:
        // 1 -> 2 -> 3 -> 4 -> null
        //      |
        //      5 -> 6 -> 7 -> 8
        //           |
        //           9
        MultiLevelListNode node1 = new MultiLevelListNode(1);
        MultiLevelListNode node2 = new MultiLevelListNode(2);
        MultiLevelListNode node3 = new MultiLevelListNode(3);
        MultiLevelListNode node4 = new MultiLevelListNode(4);
        MultiLevelListNode node5 = new MultiLevelListNode(5);
        MultiLevelListNode node6 = new MultiLevelListNode(6);
        MultiLevelListNode node7 = new MultiLevelListNode(7);
        MultiLevelListNode node8 = new MultiLevelListNode(8);
        MultiLevelListNode node9 = new MultiLevelListNode(9);
        node1.next = node2;
        node2.next = node3;
        node3.next = node4;
        node2.child = node5;
        node5.next = node6;
        node6.child = node9;
        node6.next = node7;
        node7.next = node8;

        System.out.println(multiLevelListNodeToString(node1));
        MultiLevelListNode flattened = FlattenMultiLevelList.Solution(node1);

        // 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7 -> 8 -> 9 -> null
        int counter = 1;
        MultiLevelListNode pointer = flattened;
        while (pointer.next != null) {
            if (pointer.val != counter) {
                return false;
            }
            counter++;
            pointer = pointer.next;
        }

        // print the flattened list
        System.out.println(multiLevelListNodeToString(flattened));

        return true;
    }

    private static boolean testLinkedListIntersection() {
        int[] valsA1 = {1, 2};
        int[] valsB1 = {6};
        int[] valsCommon1 = {3, 4, 5};

        ListNode headA1 = makeList(valsA1);
        ListNode headB1 = makeList(valsB1);
        ListNode common1 = makeList(valsCommon1);

        // Attach common part
        getNodeAt(headA1, valsA1.length - 1).next = common1;
        headB1.next = common1;

        System.out.println("Printing lists");
        System.out.println(listNodeToString(headA1));
        System.out.println(listNodeToString(headB1));

        ListNode intersection1 = LinkedListIntersection.Solution(headA1, headB1);

        if (intersection1 == null || intersection1.val != 3) {
            return false;
        }

        System.out.println("Intersection at node with value: " + intersection1.val);
        return true;
    }

    private static boolean testLinkedListReversal() {
        int[] valsA = {1, 2, 3, 4, 5};
        int[] valsAR = {5, 4, 3, 2, 1};

        ListNode headA = makeList(valsA);

        System.out.println("Printing lists");
        System.out.println(listNodeToString(headA));

        ListNode reversed = LinkedListReversal.Solution(headA);

        if (!verifyLinkedList(reversed, valsAR)) {
            return false;
        }

        System.out.println("Reversal of solution");
        System.out.println(listNodeToString(reversed));
        return true;
    }

    private static boolean testLinkedListReversalRecursive() {
        int[] valsA = {1, 2, 3, 4, 5};
        int[] valsAR = {5, 4, 3, 2, 1};

        ListNode headA = makeList(valsA);

        System.out.println("Printing lists");
        System.out.println(listNodeToString(headA));

        ListNode reversed = LinkedListReversalRecursive.Solution(headA);

        if (!verifyLinkedList(reversed, valsAR)) {
            return false;
        }

        System.out.println("Reversal of solution");
        System.out.println(listNodeToString(reversed));
        return true;
    }

    private static boolean testLRUCache() {
        LRUCache lru1 = new LRUCache(3);

        lru1.put(1, 2);
        lru1.put(2, 3);
        lru1.put(3, 5);
        lru1.put(4, 8);

        // 1, 2 was removed when 4, 8 is added
        if (lru1.get(1) != -1) {
            return false;
        }

        // 2, 3 is moved to the front after get
        if (lru1.get(2) != 3 && lru1.head.next.val != 3) {
            return false;
        }

        // 4, 8 is moved to the front after update with put 4, 9
        lru1.put(4,9);
        if (lru1.get(4) != 9 && lru1.head.next.val != 9) {
            return false;
        }

        // print current lru
        System.out.println(LRUCacheToString(lru1));

        return true;
    }

    // toString for LRUCache
    public static String LRUCacheToString(LRUCache lruCache) {
        StringBuilder sb = new StringBuilder();

        // Print HashMap entries
        sb.append("Cache Entries:\n");
        for (HashMap.Entry<Integer, DoublyLinkedListNode> entry : lruCache.cache.entrySet()) {
            sb.append("Key: ").append(entry.getKey())
                    .append(", Value: ").append(entry.getValue().val)
                    .append("\n");
        }

        // Print Doubly Linked List including sentinel nodes
        sb.append("\nDoubly Linked List:\n");
        DoublyLinkedListNode current = lruCache.head;
        while (current != null) {
            sb.append("[").append(current.key).append(", ").append(current.val).append("]");
            if (current.next != null) {
                sb.append(" <-> ");
            }
            current = current.next;
        }

        return sb.toString();
    }

    // toString for MultiLevelList
    public static String multiLevelListNodeToString(MultiLevelListNode head) {
        if (head == null) {
            return "null";
        }

        StringBuilder sb = new StringBuilder();
        Stack<MultiLevelListNode> stack = new Stack<>();
        MultiLevelListNode current = head;

        while (current != null || !stack.isEmpty()) {
            while (current != null) {
                sb.append(current.val);

                if (current.child != null) {
                    sb.append("![");
                    // If there's a next node, push it onto the stack to process later
                    if (current.next != null) {
                        stack.push(current.next);
                    }
                    // Move to the child node
                    current = current.child;
                } else {
                    if (current.next != null) {
                        sb.append(" -> ");
                    }
                    current = current.next;
                }
            }

            if (!stack.isEmpty()) {
                // Close the current child list
                sb.append("]");
                MultiLevelListNode nextNode = stack.pop();
                if (nextNode != null) {
                    sb.append(" -> ");
                }
                current = nextNode;
            }
        }

        sb.append(" -> null"); // Indicate the end of the list
        return sb.toString();
    }

    // toString for List
    public static String listNodeToString(ListNode head) {
        if (head == null) {
            return "null";
        }

        StringBuilder sb = new StringBuilder();
        ListNode cur = head;
        while (cur != null) {
            sb.append(cur.val).append(" -> ");
            cur = cur.next;
        }
        sb.append("null");
        return sb.toString();
    }

    // Helper for make linked list
    public static ListNode makeList(int[] list) {
        ListNode dummy = new ListNode(-1);
        ListNode cur = dummy;

        for (int value : list) {
            cur.next = new ListNode(value);
            cur = cur.next;
        }

        return dummy.next;
    }

    // Helper method to get a reference to the node at a specific index (0-based)
    public static ListNode getNodeAt(ListNode head, int index) {
        ListNode current = head;
        int count = 0;
        while(current != null && count < index) {
            current = current.next;
            count++;
        }
        return current;
    }

    // Helper method to compare linked list against fixed values
    public static boolean verifyLinkedList(ListNode head, int[] expected) {
        ListNode current = head;
        int index = 0;
        while (current != null && index < expected.length) {
            if (current.val != expected[index]) {
                return false;
            }
            current = current.next;
            index++;
        }
        return current == null && index == expected.length;
    }
}
