using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class RawImageExtended : RawImage {

	public Vector3 m_TestVec3 = Vector3.one;
	
	public Vector3[] m_Verts = { 	new Vector3 ( 	0f, 	50f), 
                         			new Vector3 ( -100f, -50f),
									new Vector3 (  100f, -50f)
								};

	protected override void OnPopulateMesh(VertexHelper vh)
        {
            Texture tex = mainTexture;
            vh.Clear();
            if (tex != null)
            {
                var r = GetPixelAdjustedRect();
                var v = new Vector4(r.x, r.y, r.x + r.width, r.y + r.height);
                var scaleX = tex.width * tex.texelSize.x;
                var scaleY = tex.height * tex.texelSize.y;
                {
                    var color32 = color;
                    vh.AddVert(m_Verts[0], color32, new Vector2(0.5f, 1f));
                    vh.AddVert(m_Verts[1], color32, new Vector2(0f, 0f));
                    vh.AddVert(m_Verts[2], color32, new Vector2(1f, 0f));

                    vh.AddTriangle(0, 1, 2);
                    //vh.AddTriangle(2, 3, 0);
                }
            }
        }
}
