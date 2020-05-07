/**
Least Recently Used (LRU) cache.
get(key) - Get the value (will always be positive) of the key if the key exists in the cache, otherwise return -1.
put(key, value) - Set or insert the value if the key is not already present. When the cache reached its capacity, it should invalidate the least recently used item before inserting a new item.

Both operations in O(1) 
**/
class Node{
    int key;
    int value;
    Node prev;
    Node next;
    Node(int k, int v){
        key = k;
        value = v;
    }
}

class LRUCache {
    int size;
    Node lru;
    Node mru;
    HashMap<Integer, Node> keyNode;
    public LRUCache(int capacity) {
        size = capacity;
        keyNode = new HashMap<Integer, Node>();
    }
    
    public int get(int key) {
        if(keyNode.containsKey(key)){
            int value = keyNode.get(key).value;
            updateNode(key, value);
            return value;
        }
        return -1;
    }
    
    public void put(int key, int value) {
        if(keyNode.containsKey(key))
            updateNode(key, value);
        else
            addNode(key, value);
    }
    
    private void addNode(int key, int value){
        Node tmp = new Node(key, value);
        //no more space
        if(keyNode.size() == size){
            keyNode.remove(lru.key);
            deleteNode(lru);             
        }
        keyNode.put(key, tmp);
        addToEnd(tmp);
    }
    
    private void addToEnd(Node node){
        //first element
        if(mru == null){
            mru = node;
            lru = node;
        }

        else{
            mru.next = node;
            node.prev = mru;
            mru = node;
        }
    }
    
    private void deleteNode(Node node){
        //head && tail
        if(node.prev == null && node.next == null){
            lru = null;
            mru = null;
        }
        //head not tail 
        else if(node.prev == null){
            node.next.prev = null;
            lru = node.next;
            node.next = null;
        }
        //tail not head
        else if(node.next == null){
            node.prev.next = null;
            mru = node.prev;
            node.prev = null;
        }
        //have both prev and next
        else{
            node.prev.next = node.next;
            node.next.prev = node.prev;
            node.prev = null;
            node.next = null;
        }
    }
    
    private void updateNode(int key, int value){
        Node tmp = keyNode.get(key);
        tmp.value = value;
        deleteNode(tmp);
        addToEnd(tmp);
    }
}


