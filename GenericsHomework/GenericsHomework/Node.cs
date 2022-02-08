namespace GenericsHomework
{
    public class Node<T>
    {
        private int[] size = { 0 };
        private Node<T> next = null!;
        private T? Value;
        public int Size { get => size[0]; }

        public Node<T> Next { 
            get; 
            private set; 
        }

        public Node (T value)
            {
            Value = value;
            }

            

    }
}