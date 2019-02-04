/*
You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Example:

Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
Output: 7 -> 0 -> 8
Explanation: 342 + 465 = 807.
*/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode addTwoNumbers(ListNode l1, ListNode l2) {
        if(l2 == null)
            return l1;
        if(l1 == null)
            return l2;
        ListNode result = l1;
        int carryOver = 0;
        
        while(l2 != null){
        int currentL1Val = l1.val;
        l1.val = (l1.val + l2.val + carryOver) % 10;
        carryOver = (currentL1Val + l2.val + carryOver) >= 10 ? 1 : 0;

        if(l1.next == null && (carryOver == 1 || l2.next != null))
            l1.next = new ListNode(0);
            
        l1 = l1.next;
        l2 = l2.next;
        }
        while(carryOver != 0){
            int currentVal = l1.val;
            l1.val = (l1.val + carryOver) % 10;
            carryOver =  (currentVal + carryOver) >= 10 ? 1 : 0;
            if(l1.next == null && carryOver == 1){
                l1.next = new ListNode(1);
                break;
                }
            l1 = l1.next;
        }         
        return result;
    }
}