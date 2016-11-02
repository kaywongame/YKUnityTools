using UnityEngine;
using System.Collections;


public class UTGizmoWorldAxis : MonoBehaviour
{
   public bool m_Draw = true;
   
   // Draw Scale
   public float m_Scale = 1.0f;
   
   public string m_ZeroLabel = "World O";

   private string m_XAxisLabel = "X";
   private string m_YAxisLabel = "Y";
   private string m_ZAxisLabel = "Z";
   
   // Use this for initialization
   void Start ()
   {
      
   }

   // Update is called once per frame
   void Update ()
   {
      
   }
      
   void OnGUI()
   {
      if (!m_Draw)	return;
      
      Camera cam = Camera.main;
      
      // Cull the object if it is back side of camera
      if(UTGlobalUtility.IsBehindOfMainCamera(cam, transform.position))		return;
      
      // Draw labels
      Vector3 zeroScrPos = cam.WorldToScreenPoint(Vector3.zero);
      Vector3 xScrPos = cam.WorldToScreenPoint(Vector3.right);
      Vector3 yScrPos = cam.WorldToScreenPoint(Vector3.up);
       Vector3 zPScros = cam.WorldToScreenPoint(Vector3.forward);
      
      GUI.Label( new Rect( zeroScrPos.x , Screen.height -zeroScrPos.y, m_ZeroLabel.Length * 10,20), m_ZeroLabel);
      GUI.Label( new Rect( xScrPos.x , Screen.height -xScrPos.y, m_XAxisLabel.Length * 10,20), m_XAxisLabel);
      GUI.Label( new Rect( yScrPos.x , Screen.height -yScrPos.y, m_YAxisLabel.Length * 10,20), m_YAxisLabel);
      GUI.Label( new Rect( zPScros.x , Screen.height -zPScros.y, m_ZAxisLabel.Length * 10,20), m_ZAxisLabel);	
   }
   
   
   void OnDrawGizmos()
   {
      if (!m_Draw)	return;
      
      Gizmos.color = Color.gray;
      Gizmos.DrawSphere(Vector3.zero, 0.2f);

      // X Axis
      UTGlobalGizmosUtility.DrawArrow(Vector3.zero, Vector3.right, Color.red, m_Scale);
      // Y Axis
      UTGlobalGizmosUtility.DrawArrow(Vector3.zero, Vector3.up, Color.green, m_Scale);
      // Z Axis
      UTGlobalGizmosUtility.DrawArrow(Vector3.zero, Vector3.forward, Color.blue, m_Scale);
   }
}

