using System;
namespace CombineGame

{
    public class RegularLock : Lockable
    {
        private bool locked;
        public RegularLock()
        {
            locked = false;
        }

        public void Lock()
        {
            locked = true;
        }
        public void UnLock()
        {
            locked = false;
        }
        public bool isLocked()
        {
            return locked;
        }
        public bool isUnLocked()
        {
            return !locked;
        }
        public bool MayOpen()
        {
            return !locked;
        }
        public bool MayClose()
        {
            return locked;
        }
    }
}