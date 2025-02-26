using Interface;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Abstract
{
    public abstract class Tower : Entity
    {
        [SerializeField] protected List<Enemy> targetList = new();
        [SerializeField] protected Enemy currentTarget;
        [SerializeField] public TargetingStrategySO targetingStrategy;
        private List<I_Observer> subscribersChangeStrategy = new List<I_Observer>();

        public float shootHeat = 1f;


        public TowerData towerData;

        public int Hp { get; set; }

        public abstract void Attack(Collider co);

        private void Start()
        {
            SphereCollider sphereCollider = GetComponent<SphereCollider>();
            sphereCollider.radius = towerData.Range;
            if (targetingStrategy == null)
                targetingStrategy = ScriptableObject.CreateInstance<FirstEnemyStrategySO>();
        }

        private void Update()
        {
            if (shootHeat > 0)
                shootHeat -= Time.deltaTime;

            targetList = targetList.Where(e => e != null).ToList();

            if (targetList.Count > 0)
                currentTarget = targetingStrategy.SelectTarget(targetList, transform);
            else
                currentTarget = null;

            if (currentTarget != null && shootHeat <= 0f)
            {
                Attack(currentTarget.GetComponent<Collider>());
                shootHeat = towerData.AttackSpeed;
            }
        }

        public void OnEnemyDead(Enemy enemy)
        {
            if (enemy != null)
            {
                targetList.Remove(enemy);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                //Debug.Log("Enemy spotted");
                var enemy = other.GetComponent<Enemy>();
                if (enemy != null)
                {
                    targetList.Add(enemy);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                //Debug.Log("Enemy left");
                var enemy = other.GetComponent<Enemy>();
                if (enemy != null)
                {
                    targetList.Remove(enemy);
                }
            }
        }

        public void SetStrategy(TargetingStrategySO strategy)
        {
            targetingStrategy = strategy;
            Notify();
        }

        private void Notify()
        {
            foreach (var observer in subscribersChangeStrategy)
            {
                observer.UpdateNotify();
            }
        }

        public void Subscribe(I_Observer observer)
        {
            subscribersChangeStrategy.Add(observer);
        }

        public void Unsubscribe(I_Observer observer)
        {
            subscribersChangeStrategy.Remove(observer);
        }

    }
}
