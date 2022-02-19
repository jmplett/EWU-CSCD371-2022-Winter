using System.Collections;

namespace GenericsHomework
{
    public class Node<T> : IEnumerable<Node<T>>
    {
        private Node<T> _Next;

        public T? Value { get; private set;}

        public Node<T> Next
        {
            get { return _Next; }
            private set
            {
                value._Next = _Next;
                _Next = value;
            }
        }
        private Node<T> Last
        {
            get
            {
                Node<T> last = this;
                while (last.Next != this)
                {
                    last = last.Next;
                }
                return last;
            }
        }

        public Node(T? value)
        {
            _Next = this;
            Value = value;
        }

        public void Append(T? value)
        {
            if (Exists(value))
            {
                throw new ArgumentException(message: "Value already exists in this NodeCollection", nameof(value));
            }
            Next = new Node<T>(value);
        } 

        public bool Exists(T? value)
        {
            foreach (var node in this)
            {
                if (node.Value is null)
                {
                    if (value is null)
                    {
                        return true;
                    }
                }
                else if (node.Value.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString() => $"{Value}";

        //closes the loop for both peices in case a reference to the peice being cleared is saved
        //making all nodes always valid and no Next fields null
        public void Clear() 
        {
            if (Next.Equals(this))
            {
                return;
            }
            Last._Next = Next;
            _Next = this;
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            Node<T> current = this;
            do
            {
                yield return current;
                current = current.Next;
            } while (current != this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return (IEnumerable)GetEnumerator();
        }

    }
}