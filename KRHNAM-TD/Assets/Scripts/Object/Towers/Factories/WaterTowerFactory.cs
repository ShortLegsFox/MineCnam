using Abstract;
using Interface;
using UnityEngine;

namespace TDObject
{
    public class WaterTowerFactory : BaseTowerFactory
    {
        protected override Element ElementType => Element.Water;
    }
}