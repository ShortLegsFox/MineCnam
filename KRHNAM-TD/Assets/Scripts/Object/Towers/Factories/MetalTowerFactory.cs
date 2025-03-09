using Abstract;
using Interface;
using UnityEngine;

namespace TDObject
{
    public class MetalTowerFactory : BaseTowerFactory
    {
        protected override Element ElementType => Element.Metal;
    }
}