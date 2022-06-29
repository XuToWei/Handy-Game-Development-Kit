using UnityEngine;

namespace Hotfix.Logic
{
    public static partial class Constant
    {
        /// <summary>
        /// 层。
        /// </summary>
        public static class Layer
        {
            public static readonly string DefaultLayerName = "Default";
            public static readonly int DefaultLayerId = LayerMask.NameToLayer(DefaultLayerName);

            public static readonly string UILayerName = "UI";
            public static readonly int UILayerId = LayerMask.NameToLayer(UILayerName);

            public static readonly string TargetableObjectLayerName = "Targetable Object";
            public static readonly int TargetableObjectLayerId = LayerMask.NameToLayer(TargetableObjectLayerName);

            public static readonly string CarLayerName = "Car";
            public static readonly int CarLayerId = LayerMask.NameToLayer(CarLayerName);
        }
    }
}