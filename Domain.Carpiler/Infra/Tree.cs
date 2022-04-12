namespace Domain.Carpiler.Infra
{
    public class Tree<T>
    {
        public Node<T> Root { get; }

        public Tree(Node<T> root)
        {
            Root = root;
        }

        public void AddChild(T data)
        {
            Root.Children.AddFirst(new Node<T>(data));
        }

        public Node<T>? GetChild(int i)
        {
            if (i < 1)
                throw new ArgumentOutOfRangeException($"{i} cannot be less than 1");

            foreach (Node<T> n in Root.Children)
                if (--i == 0)
                    return n;

            return null;
        }


        public void Traverse(Action<T> action)
        {
            Traverse(Root, action);
        }
        public static void Traverse(Node<T> node, Action<T> action)
        {
            Node<T>.Traverse(node, action);
        }
    }

    public class Node<T>
    {
        public T Data { get; set; }
        public LinkedList<Node<T>> Children { get; }

        public Node(T data)
        {
            Data = data;
            Children = new LinkedList<Node<T>>();
        }

        public static void Traverse(Node<T> node, Action<T> action)
        {
            action(node.Data);
            foreach (Node<T> kid in node.Children)
                Traverse(kid, action);
        }
    }
}
