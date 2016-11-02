using UnityEngine;
using System.Collections;

/// <summary>
/// 유니티 3D Text를 간단히 빌보드로 만들어 주는 스크립트이다.
/// 씬 뷰가 여러 개 띄워져 있으면 정상 작동하지 않을 수 있으므로 주의.
/// </summary>
public class BillboardLookAt3DText_1 : MonoBehaviour {
   
    // 씬 뷰용 빌보드 갱신.
    void OnDrawGizmos()
    {
        // 현재 물체의 Z 축이 현재 씬 뷰를 그리는 카메라를 향하게 한다.
        transform.LookAt(Camera.current.transform.position);

        // 유니티의 3D Text는 Z축이 글자가 향하는 반대 방향이므로 Y축에 대하여 180도 회전해 준다.
        transform.Rotate(0, 180, 0);

        // 얼마나 자주 실행되는지 점검
        //print("Time " + Time.deltaTime);
    }
}
