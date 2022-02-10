namespace GenericsHomework
{
    public class Node<T>
    {
        private int[] _Size = { 0 }; //should be converted to a shared int using pointers
        private Node<T> _Next;
        private T _Value;
        public T Value => _Value;
        public int Size => _Size[0];
        public Node<T> Next => _Next;

        public Node(T value)
            {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            _Next = this;
            _Value = value;
            _Size[0]++;
            }

        private Node(T value, Node<T> next, int[] size)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            _Next = next;
            _Value = value;
            _Size = size;
            _Size[0]++;
        }

        public void Append(T value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (Exists(value))
            {
                throw new Exception();
            }
            _Next = new Node<T>(value, _Next, _Size);
        }

        public bool Exists(T value)
        {
            for(int i = 0 ; i < Size; i++)
            {
                Node<T> cursor = _Next;
                if (cursor.Value is null)
                {
                    throw new Exception();
                }
                if (cursor.Value.Equals(value))
                {
                return true;
                }
                
            }
            return false;
        }
    }
}