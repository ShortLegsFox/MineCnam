using Interface;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Abstract
{
    public abstract class Tower : Entity
    {
        protected List<Enemy> targetList = new();
        protected Enemy currentTarget;
        private List<I_Observer> subscribersChangeStrategy = new List<I_Observer>();
        private I_TowerUpgradeState currentState;
        public TowerData TowerData;
        public float shootHeat { get; private set; } = 1f;

        public int Hp { get; set; }

        public abstract void Attack(Collider co);

        private void Start()
        {
            SphereCollider sphereCollider = GetComponent<SphereCollider>();
            sphereCollider.radius = TowerData.Range;
            if (TowerData.targetingStrategy == null)
                TowerData.targetingStrategy = ScriptableObject.CreateInstance<FirstEnemyStrategySO>();

            InitState();
        }

        private void Update()
        {
            if (shootHeat > 0)
                shootHeat -= Time.deltaTime;

            targetList = targetList.Where(e => e != null).ToList();

            if (targetList.Count > 0)
                currentTarget = TowerData.targetingStrategy.SelectTarget(targetList, transform);
            else
                currentTarget = null;

            if (currentTarget != null && shootHeat <= 0f)
            {
                Attack(currentTarget.GetComponent<Collider>());
                shootHeat = TowerData.AttackSpeed;
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
            TowerData.targetingStrategy = strategy;
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

        public void Upgrade()
        {
            currentState.Upgrade(this);
        }

        private void InitState()
        {
            switch (TowerData.Level)
            {
                case TowerLevel.Basic:
                    currentState = new BasicTowerState();
                    break;
                case TowerLevel.Advanced:
                    currentState = new AdvancedTowerState();
                    break;
                case TowerLevel.Ultimate:
                    currentState = new UltimateTowerState();
                    break;
            }
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

    }
}
