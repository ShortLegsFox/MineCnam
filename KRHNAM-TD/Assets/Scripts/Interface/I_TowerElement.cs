using UnityEngine;

namespace Interface
{

    public interface I_TowerElement
    {
        void Shoot(GameObject projectilePrefab, Transform origin, Transform target);
    }

}