/*
A linked list is given such that each node contains an additional random pointer which could point to any node in the list or null.
Return a deep copy of the list.


Definition for a Node.
class Node {
    public int val;
    public Node next;
    public Node random;

    public Node() {}

    public Node(int _val,Node _next,Node _random) {
        val = _val;
        next = _next;
        random = _random;
    }
};
*/

//solution one using HashMap
    public Node copyRandomList(Node head) {
        //base case
        if(head == null)
            return null;
        //use a map to map original node to new node
        HashMap<Node, Node> oriToNew = new HashMap();
       
        Node ori = head;
        Node newNodeHead = new Node(ori.val, null, null);
        Node newNodeTemp = newNodeHead;
        oriToNew.put(ori, newNodeHead);
        ori = ori.next;
        
        //loop to copy the list of node without setting random pointer, and set up map
        while(ori != null){
            Node tempNode = new Node(ori.val, null, null);
            newNodeTemp.next = tempNode;
            oriToNew.put(ori,tempNode);
            newNodeTemp = newNodeTemp.next;
            ori = ori.next;
        }
        
        newNodeTemp = newNodeHead;
        ori = head;
        //use map to set up random pointer
        while(newNodeTemp != null){
            if(ori.random != null)
                newNodeTemp.random = oriToNew.get(ori.random);
            else
                newNodeTemp.random = null;
            newNodeTemp = newNodeTemp.next;
            ori = ori.next;
        }
        
        return newNodeHead;
    }

//solution 2 without Hashmap, even less memory require, time complexity is same
    public Node copyRandomList(Node head) {
        //base case
        if(head == null)
            return null;
               
        Node ori = head, oriTemp = ori, newNodeHead = new Node(ori.val, null, ori), newNodeTemp = newNodeHead;
        Node oriFixHead = new Node(0, null, head), oriFixTemp = oriFixHead, tempFix = null;
        ori = ori.next;
        oriTemp.next = newNodeHead;
        
        //loop to copy the list of node, set new node random to respective ori node, and set ori.next to new node
        while(ori != null){
            Node tempNode = new Node(ori.val, null, ori);
            oriTemp = ori;
            ori = ori.next;
            oriTemp.next = tempNode;
            newNodeTemp.next = tempNode;
            newNodeTemp = newNodeTemp.next;
        }
        
        newNodeTemp = newNodeHead;

        //update random node of new list, save the next pointer of original list
        while(newNodeTemp != null){
            ori = newNodeTemp.random;
            if(ori.random != null)
                newNodeTemp.random = ori.random.next;
            else
                newNodeTemp.random = null;
            if(newNodeTemp.next != null){
                tempFix = new Node(0, null, newNodeTemp.next.random);
                oriFixTemp.next = tempFix;
            }
            newNodeTemp = newNodeTemp.next;
        }
        
        //fix original list
        oriFixTemp = oriFixHead;
        ori = head;
        while(oriFixTemp != null){
            if(oriFixTemp.next != null)
                ori.next = oriFixTemp.next.random;
            else
                ori.next = null;
            ori = ori.next;
            oriFixTemp = oriFixTemp.next;
        }
        
        return newNodeHead;
    }