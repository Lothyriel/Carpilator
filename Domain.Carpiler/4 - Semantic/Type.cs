namespace Domain.Carpiler.Semantic
{
    public class Type
    {
        public Type(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }

    public class ArrayType : Type
    {
        public Type ElementsType { get; }
        public int Size { get; }

        public ArrayType(Type elementsType, int size) : base ("array")
        {
            ElementsType = elementsType;
            Size = size;
        }
    }
}