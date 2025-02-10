using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Abstract
{
    public abstract class Tower : Entity
    {
        [SerializeField] protected List<Enemy> targetList = new();
        [SerializeField] protected Enemy currentTarget;

        public float shootHeat = 1f;


        public TowerData towerData;

        public int Hp { get; set; }

        public abstract void Attack(Collider co);

        private void Start()
        {
            SphereCollider sphereCollider = GetComponent<SphereCollider>();
            sphereCollider.radius = towerData.Range;
        }

        private void Update()
        {
            if (shootHeat > 0)
            {
                shootHeat -= Time.deltaTime;
            }

            targetList = targetList.Where(enemy => enemy != null).ToList();

            if (targetList.Count > 0 && currentTarget != null && shootHeat <= 0f)
            {
                Debug.DrawLine(transform.position, currentTarget.transform.position, Color.red);
                Attack(currentTarget.GetComponent<Collider>());
                shootHeat = towerData.AttackSpeed;
            }
        }

        private void GetCurrentTarget()
        {
            if (targetList.Count <= 0)
            {
                currentTarget = null;
                return;
            }

            currentTarget = targetList.First();
        }

        public void OnEnemyDead(Enemy enemy)
        {
            if (enemy != null)
            {
                targetList.Remove(enemy);
                GetCurrentTarget();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                Debug.Log("Enemy spotted");
                var enemy = other.GetComponent<Enemy>();
                if (enemy != null)
                {
                    targetList.Add(enemy);
                    GetCurrentTarget();
                    //Debug.Log("Enemy spotted");
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                Debug.Log("Enemy left");
                var enemy = other.GetComponent<Enemy>();
                if (enemy != null)
                {
                    targetList.Remove(enemy);
                    GetCurrentTarget();
                }
            }
        }

    }
}
