using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPUInstancing : MonoBehaviour {

	//public GameObject[] objects;

	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		MaterialPropertyBlock props = new MaterialPropertyBlock();
		MeshRenderer renderer;
		
		foreach (Transform obj in transform)
		{
		   float r = Random.Range(0.0f, 1.0f);
		   float g = Random.Range(0.0f, 1.0f);
		   float b = Random.Range(0.0f, 1.0f);
		   props.SetColor("_Color", new Color(r, g, b));
		   
		   renderer = obj.GetComponent<MeshRenderer>();
		   renderer.SetPropertyBlock(props);
		}	
	}

}
