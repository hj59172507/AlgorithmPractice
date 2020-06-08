namespace LeetCodePractice.DataStructure.LinkedList
{
    public class DoubleLinkList<T>
    {
        public DoubleLinkNode<T> Head { get; set; }
        public DoubleLinkNode<T> Tail { get; set; }
        public DoubleLinkList() { }

        public void AddLast(DoubleLinkNode<T> node)
        {
            if(Tail == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.next = node;
                node.prev = Tail;
                Tail = node;
            }
        }
        public void AddAfterNode(DoubleLinkNode<T> node, DoubleLinkNode<T> nodeToAdd)
        {
            nodeToAdd.next = node.next;
            node.next = nodeToAdd;
            nodeToAdd.prev = node;
            if (node == Tail) Tail = nodeToAdd;
        }

        public void ClearAfter(DoubleLinkNode<T> node)
        {
            node.next = null;
            Tail = node;
        }
    }

    public class DoubleLinkNode<T>
    {
        public DoubleLinkNode<T> prev { get; set; }
        public DoubleLinkNode<T> next { get; set; }
        public T Val{ get; set; }      

        public DoubleLinkNode(T data)
        {
            Val = data;
        }
    }
}
