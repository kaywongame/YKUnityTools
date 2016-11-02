using UnityEngine;
using System.Collections;

public class MatrixSwizzlingTest : MonoBehaviour
{

   public Matrix4x4 m_SourceMatrix = Matrix4x4.identity;
   public Matrix4x4 m_ResultMatrix = Matrix4x4.identity;
   public Matrix4x4 m_MultiplyMatrix = Matrix4x4.identity;

   public UTGizmoMatrixVisualizer m_MatrixVis;

   void Reset ()
   {
      m_ResultMatrix = m_MatrixVis.m_MatrixToShow;
      m_SourceMatrix = m_MatrixVis.transform.worldToLocalMatrix;
      
   }
   // Use this for initialization
   void Start ()
   {
      
   }

   // Update is called once per frame
   void OnDrawGizmos ()
   {
      m_ResultMatrix = m_MatrixVis.m_MatrixToShow;
      m_SourceMatrix = m_MatrixVis.transform.worldToLocalMatrix;
      
      m_ResultMatrix = m_MatrixVis.m_MatrixToShow = m_MultiplyMatrix * m_SourceMatrix;
   }
   
   
}
