using UnityEngine;
using System.Collections;

public class UTGizmoAxis : MonoBehaviour
{
   public bool m_Draw = true;

   // Draw Scale
   public float m_Scale = 1.0f;

   public string m_ZeroLabel = "O";
   public string m_XAxisLabel = "X";
   public string m_YAxisLabel = "Y";
   public string m_ZAxisLabel = "Z";

   private Vector3 m_ZeroWorldPos;
   private Vector3 m_XWorldPos;
   private Vector3 m_YWorldPos;
   private Vector3 m_ZWorldPos;

   void OnGUI()
   {
      if (!m_Draw) return;

      Camera cam = Camera.main;

      // Cull the object if it is back side of camera
      if (UTGlobalUtility.IsBehindOfMainCamera(cam, transform.position)) return;

      // Draw labels
      Vector3 zeroScrPos = cam.WorldToScreenPoint(m_ZeroWorldPos);
      Vector3 xScrPos = cam.WorldToScreenPoint(m_XWorldPos);
      Vector3 yScrPos = cam.WorldToScreenPoint(m_YWorldPos);
      Vector3 zPScros = cam.WorldToScreenPoint(m_ZWorldPos);

      GUI.Label(new Rect(zeroScrPos.x, Screen.height - zeroScrPos.y, m_ZeroLabel.Length * 10, 50), m_ZeroLabel);
      GUI.Label(new Rect(xScrPos.x, Screen.height - xScrPos.y, m_XAxisLabel.Length * 10, 50), m_XAxisLabel);
      GUI.Label(new Rect(yScrPos.x, Screen.height - yScrPos.y, m_YAxisLabel.Length * 10, 50), m_YAxisLabel);
      GUI.Label(new Rect(zPScros.x, Screen.height - zPScros.y, m_ZAxisLabel.Length * 10, 50), m_ZAxisLabel);
   }

   void OnDrawGizmos()
   {
      if (!m_Draw) return;

      m_ZeroWorldPos = transform.position;
      m_XWorldPos = m_ZeroWorldPos + transform.TransformDirection(Vector3.right * m_Scale);
      m_YWorldPos = m_ZeroWorldPos + transform.TransformDirection(Vector3.up * m_Scale);
      m_ZWorldPos = m_ZeroWorldPos + transform.TransformDirection(Vector3.forward * m_Scale);

      // X Axis
      UTGlobalGizmosUtility.DrawArrow(m_ZeroWorldPos, m_XWorldPos, Color.red, m_Scale);
      // Y Axis
      UTGlobalGizmosUtility.DrawArrow(m_ZeroWorldPos, m_YWorldPos, Color.green, m_Scale);
      // Z Axis
      UTGlobalGizmosUtility.DrawArrow(m_ZeroWorldPos, m_ZWorldPos, Color.blue, m_Scale);
   }
}

