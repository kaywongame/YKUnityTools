using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnterTest : MonoBehaviour {

	void OnTriggerEnter(Collider a_Other)
	{
		Debug.Log(a_Other.name);
	}
}
