using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.Map
{
    public class GTree<T> : INameItem
    {
        public string Name { get; set; }
        public GList<GTreeNode<T>> Children { get; set; } = new GList<GTreeNode<T>>();
    }

    public class GTreeNode<T> : INameItem
    {
        public GTreeNode()
        {
            Children.OnListChanging += Children_OnListChanging;
        }

        private void Children_OnListChanging(GList<GTreeNode<T>> container, ListChangedEventArgs<GTreeNode<T>> args)
        {
            switch (args.ChangedType)
            {
                case ListChangedType.Add:
                    if (args.Item.Parent != null)
                    {
                        Children.AllowChange = false;
                        throw new ItemParentExistsException();
                    }
                    args.Item.Parent = this;
                    break;
                case ListChangedType.Remove:
                    args.Item.Parent = null;
                    break;
            }
        }

        public string Name { get; set; }

        public GTreeNode<T> Parent { get; set; }

        public GList<GTreeNode<T>> Children { get; set; } = new GList<GTreeNode<T>>();

        public T Value { get; set; }
    }
}
