using UnityEngine.UI;

namespace UGF
{
    public class RaycastGraphic : Graphic
    {
        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();
        }
    }
}