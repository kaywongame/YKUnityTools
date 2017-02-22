using UnityEngine;
using System.Collections;

public class ToggleChildGameObjects : MonoBehaviour {

   float time = 0f;

   void Update () {
      time += Time.deltaTime;

      // 1초 마다 
      if (time > 1f)
      {
         // 시간 리셋
         time = 0;

         // 자식 게임오브젝트들을 토글 해준다.
         foreach (Transform child in transform)
         {
            // 자식들 토글
            child.gameObject.active ^= true;
         }
      }
   }
}
