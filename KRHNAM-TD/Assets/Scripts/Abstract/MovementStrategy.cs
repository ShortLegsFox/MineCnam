using UnityEngine;

namespace Abstract
{
    public abstract class MovementStrategy : ScriptableObject
    {
        public abstract void Initialize(Enemy enemy);
        public abstract void Move();
    }
}
