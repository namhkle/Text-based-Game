using System;

namespace CombineGame
{
    public interface Lockable
    {
        void Lock();
        void UnLock();
        bool isLocked();
        bool isUnLocked();
        bool MayOpen();
        bool MayClose();
    }
}
