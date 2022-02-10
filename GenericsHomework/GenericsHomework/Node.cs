namespace GenericsHomework
{
    public class Node<T> where T : notnull
    {
        private int[] _Size = { 0 }; //should be converted to a shared int using pointers
        private Node<T> _Next;
        private T _Value;
        public T Value => _Value;
        public int Size => _Size[0];
        public Node<T> Next => _Next;

        public Node(T value)
            {
            if(value is null)
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
            if (Exists(value))
            {
                throw new ArgumentException(message: "Value already exists in these nodes", nameof(value));
            }
            _Next = new Node<T>(value, _Next, _Size);
        }

        public bool Exists(T value)
        {
            Node<T> cursor = this;
            for (int i = 0 ; i < Size; i++)
            {
                if (cursor.Value.Equals(value))
                {
                    return true;
                }
                cursor = cursor.Next;
            }
            return false;
        }
        public override string ToString()
        {
            Node<T> cursor = this;
            string result = $"{this.Value}";
            for (int i = 1; i < Size; i++)
            {
                cursor = cursor.Next;
                result = $"{result}, {cursor.Value}";
            }
            return result;
        }

        public void Clear()
        {
            if (Next.Equals(this))
            {
                return;
            }

            Node<T> last = this;
            while(last.Next != this)
            {
                last = last.Next;
            }
            last._Next = Next;
            _Next = this;

            int[] size = { 1 };
            this._Size = size;

            last._Size[0]--;
        }
    }
}