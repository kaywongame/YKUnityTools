using UnityEngine;
using System.Collections;

public class CreateMesh : MonoBehaviour {

    public Vector3[] Vertex = new Vector3[]
    {
        new Vector3(0,0,0),new Vector3(1,0,0),new Vector3(0,1,0),new Vector3(1,1,0) // 4 VERTEXES! (Plane has 4 vertexes)
    };

    public Vector2[] UV_MaterialDisplay = new Vector2[]
    {
         new Vector2(0,0),new Vector2(1,0),new Vector2(0,1),new Vector2(1,1) // 4 UV with all directions! (Plane has 4 uvMaps)
    };

    public int[] Triangles = new int[]
    {
        0, 3, 1, 0, 2, 3
    }; 
    // 2 Triangle combinations (2*3=6 verticles/vertexes) + (Triangle has 3 edges & 3 vertexes & 1 face) In plane are 2 triangles for make cubed plane! (Plane has 2 triangles)

    public Renderer m_Renderer;
    public Material m_Material;

    void Update()
    {
        
        Mesh mesh = new Mesh();
        transform.GetComponent<MeshFilter>();

        if (!transform.GetComponent<MeshFilter>() || !transform.GetComponent<MeshRenderer>()) //If you will havent got any meshrenderer or filter
        {
            transform.gameObject.AddComponent<MeshFilter>();
            transform.gameObject.AddComponent<MeshRenderer>();
        }

        transform.GetComponent<MeshFilter>().mesh = mesh;

        mesh.name = "MyOwnObject";

        mesh.vertices = Vertex; //Just do this... Use Logic...
        mesh.triangles = Triangles;
        mesh.uv = UV_MaterialDisplay;

        mesh.RecalculateNormals();
        mesh.Optimize();
        m_Renderer.material = m_Material; //If you want a material.. you have it :)

    }
}
