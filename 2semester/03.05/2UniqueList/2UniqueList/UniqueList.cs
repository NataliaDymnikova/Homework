using System;
using NList;

namespace _2UniqueList
{
    public class UniqueList : List
    {
        public UniqueList()
        { }

        /// <summary>
        /// Add element.
        /// </summary>
        /// <param name="value"> Added value. </param>
        override public void AddElement(int value)
        {
            if (this.Exist(value))
                throw new ExceptionUniqueListToAdd("This element exist");
            else
                base.AddElement(value);
        }

        /// <summary>
        /// Add element to head. 
        /// </summary>
        /// <param name="value"> Added element. </param>
        override public void AddElementToHead(int value)
        {
            if (Exist(value))
                throw new ExceptionUniqueListToAdd("This element exist");
            else
                base.AddElementToHead(value);
        }

        /// <summary>
        /// Add element to position.
        /// </summary>
        /// <param name="value"> Added value. </param>
        /// <param name="pos"> Number position. </param>
        public override void AddElementToPosition(int value, int pos)
        {
            if (Exist(value))
                throw new ExceptionUniqueListToAdd("This element exist..");
            else
                base.AddElementToPosition(value, pos);
        }

        /// <summary>
        /// Delete element with value deleteNum.
        /// </summary>
        /// <param name="deleteNum"> Deleted element. </param>
        override public void DeleteElement(int deleteNum)
        {
            if (!Exist(deleteNum))
                throw new ExceptionUniqueListToDelete("Can't delete element.");
            else
                base.DeleteElement(deleteNum);
        }

    }
}
