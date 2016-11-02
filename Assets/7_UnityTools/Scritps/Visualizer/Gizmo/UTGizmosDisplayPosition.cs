/// <summary>
/// Position Display
/// Show position of an Object by Gizmo Sphere.
/// Show position in Text if GUI Text member is set.
/// 
/// by Yunkyu Choi
/// Last Update: 2011/09/21
/// </summary>
using UnityEngine;
using System.Collections;

public class UTGizmosDisplayPosition : MonoBehaviour
{

   public Color m_PointColor = Color.red;
   public float m_PointSize = 0.2f;
   public GUIText m_guiText;
   
   void DrawPosition()
   {
      Gizmos.color = m_PointColor;
      Gizmos.DrawWireSphere(transform.position, m_PointSize);

      if (m_guiText != null)
      {
         m_guiText.text = transform.position.ToString();
      }
   }
   
   
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      //DrawPosition();
   }

   void OnDrawGizmos()
   {
      DrawPosition();
   }
}
