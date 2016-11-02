using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UTFollowFromDistance : MonoBehaviour {

    public Transform m_Target;
    public Vector3 m_Offset;
    public float m_SmoothFactor = 0.01f;
	
	public bool m_FixX = false;
	public bool m_FixY = false;
	public bool m_FixZ = false;
	
    private Vector3 m_CurVelocity;
	private float m_PrevOffset = 0f;
	
    // Shake2
	public Transform m_ShakeGO;
	
	// GameManager
	//public GameObject m_GameManager;
	
	// Use this for initialization
	void Start () {
		//m_GameManager = (FindObjectOfType( typeof(TFGameSystem)) as TFGameSystem).gameObject;
		
		if(m_Target == null)
		{
			m_Target = GameObject.FindGameObjectWithTag("Player").transform;
		}
		
		//m_ShakeGO = transform.Find("Shake");
		//m_ShakeGO.parent = null;
		
		m_Offset = transform.position - m_Target.position;
    }
	
	public float m_HightMultplier = 1f;
	public float m_MaxDist = 70f;
	public float m_DefaultDist = 40f;
	
	private bool m_GameClear = false;
	
	// Update is called once per frame
	void Update () {
		if (m_Target == null) return; // || TimeManager.m_Pause) return;
		
        float nextOffset = Mathf.Min ( m_DefaultDist, m_MaxDist ) * m_HightMultplier;
        
		if (m_PrevOffset - nextOffset > 1f)
        {
            nextOffset = m_PrevOffset - 1f;
        }
        else if (nextOffset - m_PrevOffset > 1f)
        {
            nextOffset = m_PrevOffset + 1f;
        }
		
	    // Set the target position of the camera to point at the focus point
        Vector3 cameraTargetPosition = m_Target.position + m_Offset + new Vector3(Mathf.Lerp(0f, nextOffset, 0.05f ), 0f, 0f);
    	
	    // Apply some smoothing to the camera movement
	    
		
		//if(!m_Shaking)
		{
			transform.position = Vector3.SmoothDamp (transform.position, 
				new Vector3 ( 	m_FixX ? transform.position.x : cameraTargetPosition.x, 
								m_FixY ? transform.position.y : cameraTargetPosition.y,
								m_FixZ ? transform.position.z : cameraTargetPosition.z),
	            ref m_CurVelocity, m_SmoothFactor * Time.deltaTime);
		}
		/*
		else
		{
			transform.position = cameraTargetPosition + m_ShakeGO.localPosition;
		}
		*/	
			
        m_PrevOffset = nextOffset;
	}
	
	public float m_Shake = 0.3f;
	public float m_ShakeTime = 0.7f;
	private bool m_Shaking = false;
	
	public void Shake()
	{
		m_Shaking = true;
		/*
		iTween.ShakePosition(m_ShakeGO.gameObject, 
				iTween.Hash( 	
					//"amount", 0.3f,
					"x", m_Shake,
					"z", m_Shake,
					"isLocal", true,
					"time", m_ShakeTime,
					"oncomplete", "ShakeOff"
					)
		);
		*/
	}
	
	private void ShakeOff()
	{
		m_Shaking = false;
	}
	
	// Shake1
	/*
	public AnimationCurve m_ShakeMagnitude;
	public Vector3 m_ShakeVec = Vector3.right + Vector3.forward;
	private float m_ShakeTimer = 0f;
	public float m_ShakeTime = 0.7f;
	private Vector3 m_ShakeResult;
	
	void FixedUpdate()
	{
		if(m_ShakeTimer > 0f)
		{
			//m_ShakeVec *= -1;
			m_ShakeResult = m_ShakeVec * m_ShakeMagnitude.Evaluate ( m_ShakeTimer / m_ShakeTime );
			m_ShakeTimer -= Time.fixedDeltaTime;
		}
	}
	
	public void Shake()
	{
		m_ShakeTimer = m_ShakeTime;
	}
	*/
}
