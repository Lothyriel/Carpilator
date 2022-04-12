
using Domain.Carpiler.Lexical;

namespace Domain.Carpiler
{
    public class SyntaticAnalyzer
    {
        private List<Token> Tokens { get; }
        private Dictionary<string, Token> SymbolTable { get; }
        public Node<Token> TokensTree { get; }

        public SyntaticAnalyzer(List<Token> tokens, Dictionary<string, Token> symbolTable)
        {
            Tokens = tokens;
            SymbolTable = symbolTable;
            throw new NotImplementedException();
            TokensTree = null;
        }

        public object Analyze()
        {
            foreach (var token in Tokens)
            {

            }

            throw new NotImplementedException();
        }
    }
    public class Node<T>
    {
        private T Data { get; set; }
        private LinkedList<Node<T>> Children { get; }

        public Node(T data)
        {
            Data = data;
            Children = new LinkedList<Node<T>>();
        }

        public void AddChild(T data)
        {
            Children.AddFirst(new Node<T>(data));
        }

        public Node<T>? GetChild(int i)
        {
            if (i < 1)
                throw new ArgumentOutOfRangeException($"{i} cannot be less than 1");

            foreach (Node<T> n in Children)
                if (--i == 0)
                    return n;

            return null;
        }

        public void Traverse(Node<T> node, Action<T> action)
        {
            action(node.Data);
            foreach (Node<T> kid in node.Children)
                Traverse(kid, action);
        }
    }
}