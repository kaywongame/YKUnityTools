using UnityEngine;
using System.Collections;

public class UTGlobalUtility
{
   public static bool IsBehindOfMainCamera(Camera a_Camera, Vector3 a_WorldPos)
   {
      // Cull the object if it is back side of camera
      Plane cameraFrontPlane = new Plane( 
         a_Camera.transform.TransformDirection(Vector3.forward), a_Camera.transform.position);

      float distFromCamPlane = cameraFrontPlane.GetDistanceToPoint(a_WorldPos);
      
      if(distFromCamPlane < 0)		
         return true;
      else
         return false;
   }

   
   /// <summary>
   /// Return true if a_WorldPos is back side of Z plane of a_Transform
   /// </summary>
   /// <param name="a_Transform"> Pivot transform </param>
   /// <param name="a_WorldPos"> Target point </param>
   /// <returns></returns>
   public static bool IsBehindOfZPlane(Transform a_Transform, Vector3 a_WorldPos)
   {
      float distFromZPlane = a_Transform.TransformPoint(a_WorldPos).z;

      if (distFromZPlane < 0)
         return true;
      else
         return false;
   }
}

