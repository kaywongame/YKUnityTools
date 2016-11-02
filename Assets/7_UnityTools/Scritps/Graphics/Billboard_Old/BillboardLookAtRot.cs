using UnityEngine;
using System.Collections;

public class BillboardLookAtRot : MonoBehaviour
{
   
   void Update ()
   {
      transform.LookAt (Camera.main.transform.position);
   }
}
