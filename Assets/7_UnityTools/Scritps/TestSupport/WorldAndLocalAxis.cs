using UnityEngine;
using System.Collections;

public class WorldAndLocalAxis : MonoBehaviour {

   public UTGizmoAxis m_UTAxis;

   // Use this for initialization
   void Start () {
   
   }
   
   // Update is called once per frame
   void Update () {
      print(name + "w pos : " + transform.position);
      print(name + "l pos : " + transform.localPosition);
           
      print(name + "w rot : " + transform.rotation);
      print(name + "l rot : " + transform.localRotation);
             
      print(name + "w e rot : " + transform.eulerAngles);
      print(name + "l e rot : " + transform.localEulerAngles);

      m_UTAxis.m_ZeroLabel = m_UTAxis.name + "\n" 
         + "Local Pos" + transform.localPosition + "\n"
         + "World Pos" + transform.position; ;
   }

}
