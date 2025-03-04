using Abstract;
using UnityEngine;

namespace Interface
{

    public interface I_TowerElement
    {
        void Shoot(GameObject projectilePrefab, Tower origin, Transform target);
    }

}