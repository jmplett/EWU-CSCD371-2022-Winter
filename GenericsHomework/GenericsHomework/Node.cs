namespace GenericsHomework
{
    public class Node<T>
    {
        private int[] _Size = { 0 }; //should be converted to a shared int using pointers
        private Node<T> _Next;
        private T _Value;
        public T Value {
            get
            {
                return _Value;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                _Value = value;
            } }
        public int Size { get => _Size[0]; }

        public Node<T> Next {
            get
            {
                return _Next;
            }
            private set
            {
                if(value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                _Next = value;
            } 
        }

        public Node(T value)
            {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            Next = this;
            Value = value;
            _Size[0]++;
            }

        private Node(T value, Node<T> next, int[] size)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            Next = next;
            Value = value;
            _Size = size;
            _Size[0]++;
        }

        public void Append(T value)
        {
            if (Exists(value))
            {
                throw new Exception();
            }
            Next = new Node<T>(value, Next, _Size);
        }

        private bool Exists(T value)
        {
            for(int i = 0 ; i < Size; i++)
            {
                Node<T> cursor = Next;
                if (cursor.Value.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }
    }
}