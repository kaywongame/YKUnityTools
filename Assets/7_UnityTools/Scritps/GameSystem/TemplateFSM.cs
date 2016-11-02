/// By Yunkyu Choi (C) 
/// Ver 2.
/// 2013. 11. 07
/// Add CRTP(Curiously Recurring Template Pattern) pattern
/// 


using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

// Standard Events
public enum YK_STD_FSM_EVENT
{
	NONE,
	FIRST,
	LOOP_START,
	LOOP,
	LOOP_END,
	LAST,
}


public class TemplateFSM<T> : MonoBehaviour where T : TemplateFSM<T>
{
	// State
	public string m_ID = "";	// ID for distinguish state machine

	protected delegate IEnumerator StateDelegator();
	protected StateDelegator m_StateDelegator = null;
	protected string m_PrevState = "";
	protected string m_State = "State_First";

	/// Events
	protected bool m_DoEvent = false;
	
	#region Help Functions ---------------------------------------------------------------
	
	protected void SetNextState(StateDelegator a_State)
	{
		m_PrevState = m_State;
		m_StateDelegator = a_State;
	}

	
	#endregion Help Functions -----------------------------------------------------------

	#region Monobehaviour ---------------------------------------------------------------

	// Use this for initialization
	void Start()
	{
        m_CurEvent = YK_STD_FSM_EVENT.NONE;
		
		// Set the first state
//		if ((m_StateDelegator = GetDelegatorByName(m_State)) == null)
		{
			//Debug.LogError("Unknown State, Set StateFirst as the first state.");
			m_StateDelegator = ((T)(this)).State_First;
			((T)this).someFun();
		}
		
		InitEvents();
		
		StartCoroutine(MainLoop());
	}

	#endregion Monobehaviour -------------------------------------------------------------

	#region State Machine ----------------------------------------------------------------
	
	// No name event
	public void OutsideEvent()
	{
		Debug.Log("oe");
		m_DoEvent = true;
	}

	protected IEnumerator MainLoop()
	{
		m_ID = GetInstanceID() + " : " + Time.realtimeSinceStartup;

		while (true)
		{
			m_State = m_StateDelegator.Method.Name;
			Debug.Log("- Game Object : " + name +
				" \t -- Coroutine ID " + m_ID +
				" \t -- Next State Name " + m_State);
		
			//Debug.Break();

			yield return StartCoroutine(m_StateDelegator());
			InitEvents();
			
			//Debug.Break();

		}
	}

	#endregion State Machine -------------------------------------------------------------


	#region Specific Events -----------------------------------------------------
	
	// Additional
	private Vector3 m_DestPos;

    protected YK_STD_FSM_EVENT m_CurEvent;


    public void OutsideEvent(YK_STD_FSM_EVENT a_Event)
	{
		//Debug.Log("oe enum");
		//Debug.Break();
		m_CurEvent = a_Event;
		m_DoEvent = true;
	}


	public void OutsideEventString(string a_Event)
	{
		Debug.Log("oe string");
		//Debug.Break();
		m_CurEvent = (YK_STD_FSM_EVENT)Enum.Parse(typeof(YK_STD_FSM_EVENT), a_Event);
		//Debug.Break();
		m_DoEvent = true;
	}


	private void InitEvents()
	{
		Debug.Log("Init");

		m_CurEvent = YK_STD_FSM_EVENT.NONE;
		m_DoEvent = false;
	}
	
	#endregion Events --------------------------------------------------


	#region Objects for Actions ----------------------------------------


	
	#endregion Objects for Actions -------------------------------------


	protected IEnumerator State_First() {return null;}

	protected void someFun()
	{ 
		print("aa");
	}

}
