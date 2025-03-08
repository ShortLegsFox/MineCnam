using Abstract;
using UnityEngine;

namespace Interface
{ 
    public interface I_EnemyFactory
    {
        public Enemy CreateEnemy(EnemyType type, Transform spawnPoint);
    }
}
