using UnityEngine;
using System.Collections;

/// <summary>
/// Simple Singleton for MonoBehaviour.
/// Don't override Awake() for apprpriate behaviour
/// </summary>
/// 
/// <description>
/// YunKyu Choi
/// 2013.01.16
/// http://answers.unity3d.com/questions/17916/singletons-with-coroutines.html
/// </description>
public class SingletonMonoBehaviour : MonoBehaviour {
	
	private static SingletonMonoBehaviour ms_PInstance = null;
	public static SingletonMonoBehaviour ms_Instance {
		get {
			return ms_PInstance;
		}
	}
	
	void Awake()
	{
		ms_PInstance = this;
	}
	
	
	void OnDestroy()
	{
		// Make this garbage collected
		ms_PInstance = null;
	}
}
