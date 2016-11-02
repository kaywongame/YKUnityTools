using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ExecuteInEditorModeTest : MonoBehaviour {
 
   public GameObject m_Instantiate;
   
   
   void Reset()
   {
      //Instantiate(m_Instantiate);
      GameObject go = new GameObject("Test");
   }
   
   
	// Use this for initialization
	void Start () {
	   GameObject go = new GameObject("Test");
      Instantiate(m_Instantiate);
      
	}
	
   
   
	// Update is called once per frame
	void Update () {
	   print(Time.time);
      
	}
   
   
   void OnGUI()
   {
      if (GUILayout.Button("Instantiate") )
      {
         
         GameObject go = new GameObject("Test");
         
      }
      
   }
}
