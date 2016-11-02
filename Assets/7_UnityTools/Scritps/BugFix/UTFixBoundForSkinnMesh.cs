using UnityEngine;
using System.Collections;

public class UTFixBoundForSkinnMesh : MonoBehaviour {
   
   // Use this for initialization
   void Start () {
      SkinnedMeshRenderer skinMeshR = 
         (SkinnedMeshRenderer)GetComponent<SkinnedMeshRenderer>();
      
      skinMeshR.updateWhenOffscreen = true;
   }


}
