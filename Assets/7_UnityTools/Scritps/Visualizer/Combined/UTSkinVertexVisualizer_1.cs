using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class UTSkinVertexVisualizer_1 : MonoBehaviour {
   
   public bool m_Show = true;
   public bool m_ShowVertexPos = true;
   
   public bool m_ShowVertexNo = true;
   public bool m_ShowUVValues = true;
   public bool m_ShowNormal = true;
   public bool m_ShowTangent = true;
   public bool m_ShowBinormal = true;
   public bool m_ShowTriangleNo = true;
   public bool m_ShowBoneWeight = true;
   
   
   public Mesh m_Mesh;
   
   public int m_VertRange = 0;
   public int m_TriRange = 0;
   
   public int m_StartVertIdx = 0;
   private int m_EndVertIdx = 0;
   
   public int m_StartTriIdx = 0;
   private int m_EndTriIdx = 0;
   
      
   // Use this for initialization
   void Start () {
      
      SkinnedMeshRenderer skinMeshRender = (SkinnedMeshRenderer)GetComponent<SkinnedMeshRenderer>();
      
      if(skinMeshRender == null)
      {
         Debug.Log("Set Mesh Mesh", gameObject);
         m_Mesh = ((MeshFilter)GetComponent<MeshFilter>()).sharedMesh;
      }
      else
      {
         m_Mesh = skinMeshRender.sharedMesh;
         Debug.Log("Set Skinned Mesh", gameObject);
      }
      
      
      if(m_Mesh == null)
      {
         Debug.Log("No Mesh Found", gameObject);
         
         m_Show = false;
      }
      else
      {
         m_VertRange = Mathf.Min (m_Mesh.vertices.Length, m_VertRange);
         m_EndVertIdx = m_StartVertIdx + m_VertRange;
         
         m_TriRange = Mathf.Min (m_Mesh.triangles.Length, m_TriRange);
         m_EndTriIdx = m_StartTriIdx + m_VertRange;
      }
   }
   
   
   // Update is called once per frame
   void Update () {
      
      if(m_Show == false)		return;
      
      // Adjust start and end index for vertex visualization
      if(Input.GetKeyUp(KeyCode.C))
      {
         m_StartVertIdx -= m_VertRange;
         m_EndVertIdx -= m_VertRange;
      }
      
      if(Input.GetKeyUp(KeyCode.V))
      {
         m_StartVertIdx += m_VertRange;
         m_EndVertIdx += m_VertRange;
      }
      
      
      // Adjust how many vertex will be shown at once
      if(Input.GetKeyUp(KeyCode.B))
      {
         m_VertRange--;
         m_EndVertIdx = m_StartVertIdx + m_VertRange;
      }
      
      if(Input.GetKeyUp(KeyCode.N))
      {
         m_VertRange++;
         m_EndVertIdx = m_StartVertIdx + m_VertRange;
      }
   }
   
   
   void OnGUI()
   {	
      if(m_Mesh == null)		return;
      if(m_Show == false)		return;
      
      // Get camera
      Camera cam = Camera.main;
      
      // Adjust min and max index to fit in actual vertex array size
      int max = m_Mesh.vertices.Length < m_EndVertIdx ? m_Mesh.vertices.Length : m_EndVertIdx;
      int min = 0 > m_StartVertIdx ? 0 : m_StartVertIdx;
      
      // Cull if GO is behind of Camera
      if(UTGlobalUtility.IsBehindOfMainCamera(Camera.main, transform.position))		return;
      
      
      // Show Vertices info
      for (int i = min; i < max; i++) 
      {
         // Get World Position
         Vector3 vertWorldPos = transform.TransformPoint(m_Mesh.vertices[i]);
         //Vector3 vertPos = transform.rotation * m_Mesh.vertices[i] + transform.position;	// The same as above
         
         // WorldToScreenPoint to GUI coordinate
         Vector3 screenPosTemp = cam.WorldToScreenPoint(vertWorldPos);
         Vector3 screenPos = new Vector3(screenPosTemp.x, Screen.height - screenPosTemp.y);
         
         // Show Vertex No.
         if(m_ShowVertexNo){
            string vertNum = i.ToString();
            GUI.Label( new Rect( screenPos.x , screenPos.y, vertNum.Length * 10,20), vertNum);
         }

         // Show VUs
         if (m_ShowUVValues)
         {
            string uv = m_Mesh.uv[i].ToString();
            GUI.Label(new Rect(screenPos.x, screenPos.y, uv.Length * 10, 20), uv);
         }
      }
      
      // Show Triangle No
      if(m_ShowTriangleNo) {
         
         int triIdxNum = m_Mesh.triangles.Length;
         int triNum = triIdxNum / 3;
         print("triangle Index Count: " + triIdxNum);
         print("triangle Count: " + triNum);
         
         
         for (int j = 0; j < triNum; j++) {
            /*
            print("tri " + j + " V idx : [ " + 
                  m_Mesh.triangles[ j * 3] + " , " +
                  m_Mesh.triangles[ j * 3 + 1] + " , " +
                  m_Mesh.triangles[ j * 3 + 2] + " ]" );
            */
            int v0 = m_Mesh.triangles[ j * 3];
            int v1 = m_Mesh.triangles[ j * 3 + 1];
            int v2 = m_Mesh.triangles[ j * 3 + 2];
            
            Vector3 v0PosL = m_Mesh.vertices[v0];
            Vector3 v1PosL = m_Mesh.vertices[v1];
            Vector3 v2PosL = m_Mesh.vertices[v2];
            
            Vector3 cntPosL = (v0PosL + v1PosL + v2PosL) / 3f;
            
            Vector3 cntPosW = transform.TransformPoint(cntPosL);
            
            Vector3 screenPosTemp2 = cam.WorldToScreenPoint(cntPosW);
            Vector3 screenPos2 = new Vector3(screenPosTemp2.x, Screen.height - screenPosTemp2.y);
            
            string triNumStr = j.ToString();
            GUI.Label( new Rect( screenPos2.x , screenPos2.y, triNumStr.Length * 10,20), triNumStr);
         }
      }
   }
   
   
   void OnDrawGizmos()
   {
      if (m_Mesh == null) 	return;
      
      // Adjust min and max index to fit in actual vertex array size
      int max = m_Mesh.vertices.Length < m_EndVertIdx ? m_Mesh.vertices.Length : m_EndVertIdx;
      int min = 0 > m_StartVertIdx ? 0 : m_StartVertIdx;
      
      // Show Vertices info
      for (int i = min; i < max; i++) 
      {
         // Get World Position
         Vector3 vertWorldPos = transform.TransformPoint(m_Mesh.vertices[i]);
         
         
         // Show Vertex Position
         if(m_ShowVertexPos){
            Gizmos.DrawSphere(vertWorldPos, 0.02f);
         }
         
         // Show Normal
         if(m_ShowNormal){
            Gizmos.DrawLine(vertWorldPos, vertWorldPos + transform.TransformDirection(m_Mesh.normals[i] * 0.5f)); 
         }
         
      }
   }
   
}


