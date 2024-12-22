using UnityEngine;

namespace Interface
{
    public interface I_TowerFactory
    {
        public abstract GameObject CreateTower(Vector3 position);
    
    }
}
