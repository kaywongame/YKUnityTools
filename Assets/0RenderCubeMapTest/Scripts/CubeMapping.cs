using UnityEngine;
using System.Collections;

public class CubeMapping : MonoBehaviour {

   // Use this for initialization
   void Start () {
   
   }
   
   // Update is called once per frame
   void Update () {
   
   }

   /// <summary>
   /// 반사 벡터를 반환 한다.
   /// </summary>
   /// <param name="a_Normal"> 노멀 벡터 </param>
   /// <param name="a_InVec"> 뷰 벡터 </param>
   /// <returns> 반사 벡터 </returns>
   Vector3 Reflection(Vector3 a_Normal, Vector3 a_InVec)
   {
      //Quaternion approachRotation = Quaternion.FromToRotation(currentDirection, contact.normal);
      //Vector3 reflectDirection = (approachRotation * contact.normal) * -1;

      Vector3 outVec = -Vector3.Dot(a_Normal, a_InVec) * a_Normal * 2f;
      Vector3 reflectionVec = outVec + a_InVec;

      Debug.DrawRay(transform.position, a_InVec, Color.red, 2f);
      Debug.DrawRay(transform.position, a_Normal, Color.green, 2f);
      Debug.DrawRay(transform.position, reflectionVec, Color.blue, 2f);

      //print("Hit" + Time.time);

      return reflectionVec;
   }

}
