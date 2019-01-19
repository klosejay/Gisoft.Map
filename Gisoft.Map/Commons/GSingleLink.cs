using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.Map.Commons
{
    public class GDoubleLinkNode<T>
    {
        /// <summary>
        /// 节点对象
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 下一节点
        /// </summary>
        public GDoubleLinkNode<T> Next { get; set; }

        /// <summary>
        /// 前一节点
        /// </summary>
        public GDoubleLinkNode<T> Prev { get; set; }

        public GDoubleLinkNode()
        {

        }
        public GDoubleLinkNode(T data)
        {
            Data = data;
        }
    }
    /// <summary>
    /// 双向链表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GDoubleLink<T>
    {
        /// <summary>
        /// 获取或设置最大节点数
        /// </summary>
        public int MaxNode { get; set; } = int.MaxValue;

        /// <summary>
        /// 节点总数
        /// </summary>
        public int Count
        {
            get
            {
                var node = Head;
                if (Head == null)
                {
                    return 0;
                }
                int count = 1;
                while (node.Next != null)
                {
                    count += 1;
                    node = node.Next;
                }
                return count;
            }
        }

        /// <summary>
        /// 当前节点
        /// </summary>
        public GDoubleLinkNode<T> Current { get; set; }

        /// <summary>
        /// 当前节点数据
        /// </summary>
        public T CurrentData { get => Current.Data; }

        /// <summary>
        /// 首节点
        /// </summary>
        public GDoubleLinkNode<T> Head { get; set; }

        /// <summary>
        /// 获取下一节点，并将当前节点置于下一节点（除非下一节点为空）
        /// </summary>
        public GDoubleLinkNode<T> Next
        {
            get
            {
                if (Current != null)
                {
                    if (Current.Next != null)
                    {
                        Current = Current.Next;
                        return Current;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// 获取下一节点数据，并将当前节点置于下一节点（除非下一节点为空）
        /// </summary>
        public T NextData
        {
            get
            {
                var next = Next;
                if (next != null)
                {
                    return next.Data;
                }
                return default(T);
            }
        }

        /// <summary>
        /// 获取前一节点，并将当前节点置于前一节点（除非前一节点为空）
        /// </summary>
        public GDoubleLinkNode<T> Prev
        {
            get
            {
                if (Current != null)
                {
                    if (Current.Prev != null)
                    {
                        Current = Current.Prev;
                        return Current;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// 获取前一节点数据，并将当前节点置于前一节点（除非前一节点为空）
        /// </summary>
        public T PrevData
        {
            get
            {
                var prev = Prev;
                if (prev != null)
                {
                    return prev.Data;
                }
                return default(T);
            }
        }

        /// <summary>
        /// 尾节点
        /// </summary>
        public GDoubleLinkNode<T> Last { get; set; }

        /// <summary>
        /// 单链表构造函数
        /// </summary>
        public GDoubleLink()
        {

        }

        /// <summary>
        /// 单链表构造函数
        /// </summary>
        /// <param name="data"></param>
        public GDoubleLink(T data)
        {
            AddNode(data);
        }

        /// <summary>
        /// 在链表尾部添加节点
        /// </summary>
        /// <param name="data"></param>
        public void AddNode(T data)
        {

            var nextNode = new GDoubleLinkNode<T>(data);
            if (Count == 0)
            {
                Current = nextNode;
                Head = nextNode;
                Last = nextNode;
            }
            else
            {
                Last.Next = nextNode;
                nextNode.Prev = Last;
                Last = nextNode;
            }
            if (Count > MaxNode)
            {
                Head = Head.Next;
            }
        }
        /// <summary>
        /// 在当前节点后添加节点
        /// </summary>
        /// <param name="data"></param>
        public void AddNodeAfterCurrent(T data)
        {
            if (Count == 0)
            {
                AddNode(data);
                return;
            }
            var nextNode = new GDoubleLinkNode<T>(data);
            Current.Next = nextNode;
            nextNode.Prev = Current;
            Current = nextNode;
            Last = nextNode;
            if (Count > MaxNode)
            {
                Head = Head.Next;
            }
        }
    }
}
