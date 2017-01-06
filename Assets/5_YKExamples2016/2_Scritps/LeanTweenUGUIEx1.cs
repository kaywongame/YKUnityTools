using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanTweenUGUIEx1 : MonoBehaviour {

    public RectTransform button;

    public AnimationCurve curve;

    public LeanTweenType m_EaseType;

    public int id = -1;
    public int id2 = -1;


    // Use this for initialization
    void Start () {
        //// Scale Example
        //LeanTween.scale(avatarScale, new Vector3(1.7f, 1.7f, 1.7f), 5f).setEase(LeanTweenType.easeOutBounce);
        //LeanTween.moveX(avatarScale, avatarScale.transform.position.x + 5f, 5f).setEase(LeanTweenType.easeOutBounce); // Simultaneously target many different tweens on the same object 

        LeanTween.scale(button, button.localScale * 5f, 2f).setEase(m_EaseType).setDelay(1f) ;

        id = LeanTween.scale(button, Vector3.one, 2f).
            setEase(curve).
            setDelay(3f).
            id;

        id2 = LeanTween.scale(button, button.localScale * 5f, 2f).
            setEase(LeanTweenType.easeOutElastic).
            setDelay(6f).
            id;


    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Time.timeSinceLevelLoad);

        if (Input.GetKeyDown(KeyCode.P))
        {
            // pause a specific tween
            LeanTween.pause(id);
            LeanTween.pause(id2);

            //Time.timeScale = 0f;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            // resume later
            LeanTween.resume(id);
            LeanTween.resume(id2);

            //Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            // resume later
            LeanTween.cancel(id);
            LeanTween.cancel(id2);
        }
    }
}
