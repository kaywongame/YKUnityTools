using UnityEngine;
using System.Collections;

public class FixBoundMulti : MonoBehaviour {
   
   public SkinnedMeshRenderer[] m_SkinMeshes;
   
	void Start () {
      
      foreach (SkinnedMeshRenderer skinMesh in m_SkinMeshes) {
         skinMesh.updateWhenOffscreen = true;         
      }

	}


}
