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

