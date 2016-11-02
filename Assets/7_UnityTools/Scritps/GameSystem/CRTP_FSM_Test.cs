using UnityEngine;
using System.Collections;

public class CRTP_FSM_Test : TemplateFSM<CRTP_FSM_Test>
{

	// Use this for initialization
	//void Start () {} // call parent's
	
	// Update is called once per frame
	//void Update () {}


	protected void someFun()
	{
		print("bb");
	}

	IEnumerator State_First()
	{
		Debug.Break();
		// Start Action Here
		Debug.Log("= Start in Child ==" + m_StateDelegator.Method.Name +
				" State in GameObject " + gameObject.ToString() + "] ID : " + m_ID);

		m_CurEvent = YK_STD_FSM_EVENT.NONE;

		// 

		yield return new WaitForSeconds(1f);


		// Transition to next state
		SetNextState(State_Guide);
		//			m_PrevState = m_State;
		//			m_StateDelegator = State_Guide;

		// End Action Here
		Debug.Log("=== Move to ==" + m_StateDelegator.Method.Name +
			" From [" + m_PrevState +
				"] in [" + gameObject.ToString() + "] ID : " + m_ID);
	}


	IEnumerator State_Guide()
	{
		/// Enter Action --------
		// Start Action Here
		Debug.Log("= Start in Child ==" + m_StateDelegator.Method.Name +
				" State in GameObject " + gameObject.ToString() + "] ID : " + m_ID);


		// Repetitive Action Here
		Debug.Log("== In == " + m_StateDelegator.Method.Name +
				" State in GameObject " + gameObject.ToString() + "] ID : " + m_ID);

		/// Repeat Action --------
		while (!m_DoEvent)
		{

			yield return new WaitForSeconds(0.3f);
		}


		/// End Action --------

		//SetNextState(State_Game);

		Debug.Log("=== Move to ==" + m_StateDelegator.Method.Name +
			" From [" + m_PrevState +
				"] in [" + gameObject.ToString() + "] ID : " + m_ID);


		yield return null;
	}
	

}
