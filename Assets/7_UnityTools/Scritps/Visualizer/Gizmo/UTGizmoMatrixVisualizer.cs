using UnityEngine;
using System.Collections;
using UnityTools.Math;


public class UTGizmoMatrixVisualizer : MonoBehaviour
{
   public bool m_Draw = true;
   public UTMatrix m_DisplayMatrix = UTMatrix.LocalToWorld;
 
   public Vector3 m_Offset = Vector3.zero;
   public Color[] m_RowColors = new Color[3]; 
   public Color[] m_ColumnColors = new Color[3]; 
      
   public Matrix4x4 m_MatrixToShow;
 
   void Reset()
   {
      m_RowColors = new Color[3] {Color.red, Color.green, Color.blue};
      
      m_ColumnColors = new Color[3] {Color.cyan, Color.magenta, Color.yellow};
      
   }
   
   private void GetMatrix ()
   {
      switch (m_DisplayMatrix) {
      case UTMatrix.CamToWorld:
         m_MatrixToShow = transform.GetComponent<Camera>().cameraToWorldMatrix;
         break;
      
      case UTMatrix.WorldToCam:
         m_MatrixToShow = transform.GetComponent<Camera>().worldToCameraMatrix;
         break;
      
      case UTMatrix.Projection:
         m_MatrixToShow = transform.GetComponent<Camera>().projectionMatrix;
         break;
      
      case UTMatrix.LocalToWorld:
         m_MatrixToShow = transform.localToWorldMatrix;
         break;
      
      case UTMatrix.WorldToLocal:
         m_MatrixToShow = transform.worldToLocalMatrix;
         break;
         
      case UTMatrix.Custom:
         /*
         m_MatrixToShow = transform.camera.cameraToWorldMatrix;
         m_MatrixToShow.SetColumn(2, -m_MatrixToShow.GetColumn(2));
         */
         break;
         
      default:
         
         m_MatrixToShow = Matrix4x4.identity;
         break;
      }
   }

   private void DrawGizmos ()
   {
      
      // x
      UTGlobalGizmosUtility.DrawArrow (transform.position + m_Offset, 
         m_MatrixToShow.GetRow (0), 1f, m_RowColors[0]);
      // y
      UTGlobalGizmosUtility.DrawArrow (transform.position + m_Offset, 
         m_MatrixToShow.GetRow (1), 1f, m_RowColors[1]);
      // z
      UTGlobalGizmosUtility.DrawArrow (transform.position + m_Offset,
         m_MatrixToShow.GetRow (2), 1f, m_RowColors[2]);
      
      /*
      // Column
      // x
      UTGlobalGizmosUtility.DrawArrow (transform.position + m_Offset,
         m_MatrixToShow.GetColumn (0), 0.5f, m_ColumnColors[0]);
      // y
      UTGlobalGizmosUtility.DrawArrow (transform.position + m_Offset,
         m_MatrixToShow.GetColumn (1), 0.5f, m_ColumnColors[1]);
      // z
      UTGlobalGizmosUtility.DrawArrow (transform.position + m_Offset,
         m_MatrixToShow.GetColumn (2), 0.5f, m_ColumnColors[2]);
      */
   }

   void OnDrawGizmos ()
   {
      if (m_Draw) {

         GetMatrix ();
         DrawGizmos ();

      }
   }
   
   
   
   
   
   
}
