using System;
using Interface;
using UnityEngine;

namespace TDObject
{
    public class WaterTower : MonoBehaviour, I_Tower
    {
        public Case Position
        {
            get
            {
                if (Grid.Instance == null)
                {
                    ErrorManager.DebugLog("Grid reference is missing!");
                    return null;
                }
                return Grid.Instance.CaseFromWorldPoint(transform.position);
            }
        }

        public void OnPlace(Vector3 position)
        {
            transform.position = position;
        }
        
        private void Start()
        {
            throw new NotImplementedException();
        }

        private void Update()
        {
            throw new NotImplementedException();
        }
    }
}
