using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TextMesh))]
[RequireComponent(typeof(MeshRenderer))]
public class UTDisplayNameByTextMesh : MonoBehaviour {

   public bool m_ScreenAligned = true;
   TextMesh m_TextMesh;
   MeshRenderer m_MeshRenderer;  


   void Init() {
      m_TextMesh = GetComponent<TextMesh>();
      m_TextMesh.text = transform.parent.name;
      m_TextMesh.anchor = TextAnchor.UpperCenter;
      m_TextMesh.characterSize = 0.2f;
      //Font font = new Font();
      //m_TextMesh.font = font;

      m_MeshRenderer = GetComponent<MeshRenderer>();
      //m_MeshRenderer.material = new Material(Shader.Find("Hidden/font material"));

      transform.position = transform.parent.position;

      name = "3DText" + transform.parent.name;
   }

   void Reset()
   {
      Init();
   }

   // Use this for initialization
   void Start()
   {
      Init();
   }


   void Billboard(Camera a_Cam) {

      if (m_ScreenAligned)
      {
         transform.rotation = a_Cam.transform.rotation;
      }
      else
      {
         transform.LookAt(a_Cam.transform.position);

         transform.Rotate(Vector3.up, 180f, Space.Self);
         // 아래 처럼 하면 트리 빌보드 처럼 작동 함
         //transform.Rotate(Vector3.up, 180f, Space.World);
      }
      
   }

   void LateUpdate()
   {
      Billboard(Camera.main);
   }

   void OnDrawGizmos()
   {

      if (Application.isPlaying)
      {
         //Billboard(Camera.main);
      }
      else
      {
         Billboard(Camera.current);
      }
   }

}
