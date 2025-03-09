using Abstract;
using Interface;
using UnityEngine;

namespace TDObject
{
    public class WoodTowerFactory : BaseTowerFactory
    {
        protected override Element ElementType => Element.Wood;
    }
}