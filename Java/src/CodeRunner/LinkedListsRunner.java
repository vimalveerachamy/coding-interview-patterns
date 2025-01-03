package CodeRunner;

import DS.DoublyLinkedListNode;
import LinkedLists.LRUCache;

import java.util.HashMap;

public class LinkedListsRunner {
    // Code runner
    public static void main(String[] args) {
        System.out.println(testLRUCache());
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
}
