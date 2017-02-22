using UnityEngine;
using System.Collections;

public class FollowTransform : MonoBehaviour {

   public Transform m_TargetTransform;

   // Use this for initialization
   void Start () {
   
   }
   
   // Update is called once per frame
   void Update () {
      transform.position = m_TargetTransform.position;
   }
}
