using Abstract;
using Interface;
using UnityEngine;

namespace TDObject
{
    public class EarthTowerFactory : BaseTowerFactory
    {
        protected override Element ElementType => Element.Earth;
        
    }
}