using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOT
{
    class BinarySearchTree<T,K> : IEnumerable<T> where K : IComparable
    {
        public enum IterativeMethod
        {
            InOrder, PreOrder, PostOrder
        }
        class Branch
        {
            public T content;
            public K key;
            public Branch left;
            public Branch right;
        }
        private Branch root;
        private IterativeMethod iterate;
        public IterativeMethod Iterate { set { iterate = value; } }
        private IEnumerable<T> content
        {
            get
            {
                List<T> tmp = new List<T>();
                switch (iterate)
                {
                    case IterativeMethod.InOrder:
                    default:
                        _InOrder(tmp, root);
                        break;
                    case IterativeMethod.PreOrder:
                        _PreOrder(tmp, root);
                        break;
                    case IterativeMethod.PostOrder:
                        _PostOrder(tmp, root);
                        break;
                }
                return tmp;
            }
            
        }
        public void InsertIntoTree(T content, K key)
        {
            _InsertIntoTree(ref root, content, key);
        }
        private void _InsertIntoTree(ref Branch p, T content, K key)
        {
            if(p == null)
            {
                p = new Branch();
                p.content = content;
                p.key = key;
            }
            else
            {
                if(p.key.CompareTo(key) < 0)
                {
                    _InsertIntoTree(ref p.right, content, key);
                }
                else if(p.key.CompareTo(key) > 0)
                {
                    _InsertIntoTree(ref p.left, content, key);
                }
                else
                {
                    throw new ArgumentException("There already is a similar element in the tree");
                }
            }
        }
        private void _InOrder(List<T> list, Branch p)
        {
            if(p != null)
            {
                _InOrder(list,p.left);
                list.Add(p.content);
                _InOrder(list,p.right);
            }
        }
        
        private void _PreOrder(List<T> list, Branch p)
        {
            if (p != null)
            {
                list.Add(p.content);
                _PreOrder(list, p.left);
                _PreOrder(list, p.right);
            }
        }
        
        private void _PostOrder(List<T> list, Branch p)
        {
            if (p != null)
            {
                _PostOrder(list,p.left);
                _PostOrder(list,p.right);
                list.Add(p.content);
            }
        }
        

        public IEnumerator<T> GetEnumerator()
        {
            return content.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return content.GetEnumerator();
        }
    }
}
