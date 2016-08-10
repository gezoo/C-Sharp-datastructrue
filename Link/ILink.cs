using System.Collections.Generic;

namespace Link
{
    public interface ILink<T> : IEnumerable<T>
    {
        /// <summary>
        /// 获取长度
        /// </summary>
        /// <returns></returns>
        int GetLength();

        /// <summary>
        /// 清空链表
        /// </summary>
        void Clear();

        /// <summary>
        /// 删除元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        T Delete(int index);

        /// <summary>
        /// 插入链表
        /// </summary>
        /// <param name="item"></param>
        /// <param name="i">位置</param>
        /// <returns></returns>
        void Insert(T item,int i);

        /// <summary>
        /// 追加元素
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        void Append(T item);

        /// <summary>
        /// 查找元素
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int Find(T t);

        void ShowLink();
    }
}