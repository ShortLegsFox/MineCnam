using Abstract;
using Interface;
using UnityEngine;

namespace TDObject
{
    public class FireTowerFactory : BaseTowerFactory
    {
        protected override Element ElementType => Element.Fire;
    }
}
