using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class UTFrustumVisualizer : MonoBehaviour
{

   public bool m_bDraw = true;
   public Color m_Color;
   public Camera m_Camera;

   public Vector3 m_N_TL;
   public Vector3 m_N_TR;
   public Vector3 m_N_BL;
   public Vector3 m_N_BR;

   public Vector3 m_F_TL;
   public Vector3 m_F_TR;
   public Vector3 m_F_BL;
   public Vector3 m_F_BR;


   void Reset ()
   {
      if (m_Camera == null) {
         m_Camera = Camera.main;
      }
      
      if (m_Color == null)
      {
         m_Color = Color.white;
      }
   }
 
   
   void Update ()
   {
      
   }
   

   void OnDrawGizmos()
   {

      // Near Plane half Width
      float nearY = Mathf.Tan(Mathf.Deg2Rad * m_Camera.fov / 2f) * m_Camera.near;

      // Near Plane half Height
      float aspectWH;
      /*
      Debug.Log("cam aspect             " + m_Camera.aspect);
      
      aspectWH = 1f / m_Camera.projectionMatrix.m00 * m_Camera.projectionMatrix.m11;
      Debug.Log("cam aspect from Proj M " + aspectWH);
      
      aspectWH = (float)m_Camera.pixelWidth / (float)m_Camera.pixelHeight;
      Debug.Log("cam aspect from pixel W / H " + aspectWH);
      
      aspectWH = (float)Screen.width / (float)Screen.height;
      Debug.Log("cam aspect from screen W / H " + aspectWH);
      */
      aspectWH = (float)UnityEditor.PlayerSettings.defaultScreenWidth / (float)UnityEditor.PlayerSettings.defaultScreenHeight;
      Debug.Log("cam aspect from player setting W / H " + aspectWH);

      float nearX = aspectWH * nearY;


      // Near Plane Points
      m_N_TL = new Vector3(-nearX, nearY, m_Camera.near);
      m_N_TR = new Vector3(nearX, nearY, m_Camera.near);
      m_N_BL = new Vector3(-nearX, -nearY, m_Camera.near);
      m_N_BR = new Vector3(nearX, -nearY, m_Camera.near);


      // Far Plane X and Y factors
      float farY = Mathf.Tan(Mathf.Deg2Rad * m_Camera.fov / 2f) * m_Camera.far;
      float farX = aspectWH * farY;

      // Near Plane Points
      m_F_TL = new Vector3(-farX, farY, m_Camera.far);
      m_F_TR = new Vector3(farX, farY, m_Camera.far);
      m_F_BL = new Vector3(-farX, -farY, m_Camera.far);
      m_F_BR = new Vector3(farX, -farY, m_Camera.far);

      // Draw Gizmos
      Gizmos.color = m_Color;
      // using Local positions
      Gizmos.matrix = transform.localToWorldMatrix;

      // Near Plane
      Gizmos.DrawLine(m_N_TL, m_N_TR);
      Gizmos.DrawLine(m_N_TR, m_N_BR);
      Gizmos.DrawLine(m_N_BR, m_N_BL);
      Gizmos.DrawLine(m_N_BL, m_N_TL);

      // Far Plane
      Gizmos.DrawLine(m_F_TL, m_F_TR);
      Gizmos.DrawLine(m_F_TR, m_F_BR);
      Gizmos.DrawLine(m_F_BR, m_F_BL);
      Gizmos.DrawLine(m_F_BL, m_F_TL);

      // Connect Near and Far Planes
      Gizmos.DrawLine(m_N_TL, m_F_TL);
      Gizmos.DrawLine(m_N_TR, m_F_TR);
      Gizmos.DrawLine(m_N_BL, m_F_BL);
      Gizmos.DrawLine(m_N_BR, m_F_BR);
   }
   
}
