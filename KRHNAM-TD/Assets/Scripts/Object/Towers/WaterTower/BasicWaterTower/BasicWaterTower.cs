using System;
using System.Collections.Generic;
using System.Linq;
using Abstract;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class BasicWaterTower : Tower
{
    [SerializeField] private List<EnemyWalk> targetList = new();
    [SerializeField] private EnemyWalk currentTarget;
    
    public override void Attack()
    {
        if (isPlaced)
        {
            Debug.Log("ATTACK !!");
        }
    }

    private void Start()
    {
        SphereCollider sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = towerData.Range;
    }

    private void Update()
    {
        if (targetList.Count > 0 && currentTarget != null)
        {
            Debug.DrawLine(transform.position, currentTarget.transform.position, Color.red);
            Debug.Log(towerData.Range);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<EnemyWalk>();
            if (enemy != null)
            {
                targetList.Add(enemy);
                GetCurrentTarget();
                Debug.Log("Enemy spotted");
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<EnemyWalk>();
            if (enemy != null)
            {
                targetList.Remove(enemy);
                GetCurrentTarget();
            }
        }
    }
}
