/*
Reverse a singly linked list.
Example:
Input: 1->2->3->4->5->NULL
Output: 5->4->3->2->1->NULL
*/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode(int x) { val = x; }
 * }
 */
//iterative approach
class Solution {
    public ListNode reverseList(ListNode head) {
        ListNode result = null, resultHead = null;
        while(head != null){
            resultHead = new ListNode(head.val);
            resultHead.next = result;
            result = resultHead;
            head = head.next;
        }
        return resultHead;
    }
}

//recursive approach
class Solution {
    public ListNode reverseList(ListNode head) {
        ListNode result = null, resultHead = null;
        return helper(head, result, resultHead);
    }
    
    public ListNode helper(ListNode head, ListNode result, ListNode resultHead){
        if(head != null){
            resultHead = new ListNode(head.val);
            resultHead.next = result;
            result = resultHead;
            head = head.next;
            return helper(head, result, resultHead);
        }
        return resultHead;
    }
}