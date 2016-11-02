// Ref: http://answers.unity3d.com/questions/43415/finding-the-polygonface-youre-currently-looking-at.html
//
// Calculation of triangle and vertex index is added by Yunkyu Choi
// Draw Triangle outline is added by Yunkyu Choi

using UnityEngine;
using System.Collections;

public class UTFindTriangleInfo : MonoBehaviour
{
    void Update()
    {
        //This generates our ray. We input the positions x, and y, as screen height and width divided by two to send a ray towards whatever the
        //screen center is viewing.
        //Camera.main is a static var, capable of being accessed from any code without references.
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));

        //This defines a RaycastHit object. Its information is filled out if Physics.Raycasthit actually hits.
        RaycastHit hit = new RaycastHit();

        //This uses the ray's parameters to call physics.raycast. Mathf.Infinity is the distance the raycast will go before giving up. [Don't worry, distances of this size cause no lag].
        //We specify 'out' as that is just how c# rolls. [It goes into variable references, ETC. All of this is automagic in JS]
        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
        {
            //This is not necissarry. All it does is visualize in 3D what the camera is looking at. hit.Distance is how far the raycast got before
            //Hittign soemthing. It functions as how far away we will draw the ray.
            Debug.DrawLine(ray.origin, hit.point, Color.red);

            //This is the index of the tri the camera is looking at:
            int ind = hit.triangleIndex;
            
         
            // Added by YK ---------------------------------------------------------------------
            // Mark the hit position
            Debug.DrawRay(hit.point, Vector3.up * 0.2f, Color.cyan);
         
            Debug.Log("Hit " + ind + " th Triangle");
         
            int triIdx = ind * 3;
            Debug.Log("Hit tri index is " + triIdx);
         
            Mesh mesh = hit.transform.GetComponent<MeshFilter>().mesh;

            // Draw triangle outline
            int v0 = mesh.triangles[triIdx];
            int v1 = mesh.triangles[triIdx + 1];
            int v2 = mesh.triangles[triIdx + 2];
            
            Debug.Log("Hit vert index is [" + v0 + ", " + v1 + ", " + v2 + "]" );

           
            Vector3 v0PosL =mesh.vertices[v0];
            Vector3 v1PosL =mesh.vertices[v1];
            Vector3 v2PosL =mesh.vertices[v2];

            Vector3 v0PosW = hit.transform.TransformPoint(v0PosL);
            Vector3 v1PosW = hit.transform.TransformPoint(v1PosL);
            Vector3 v2PosW = hit.transform.TransformPoint(v2PosL);

            Debug.DrawLine(v0PosW, v1PosW);
            Debug.DrawLine(v1PosW, v2PosW);
            Debug.DrawLine(v2PosW, v0PosW);
        }
    }
}