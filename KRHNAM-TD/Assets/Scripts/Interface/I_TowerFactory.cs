using UnityEngine;

namespace Interface
{
    public abstract class I_TowerFactory : MonoBehaviour
    {
        public virtual I_Tower CreateTower()
        {
            return null;
        }

    }
}
