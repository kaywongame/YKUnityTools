// 정해진 시점에서 씬을 렌더링 하여 정적 큐브 맵을 생성한다.
// 이 스크립트를 Editor 폴더에 넣으셔서 큐브 맵을 생성하시고
// Reflective 쉐이더와 함께 생성된 큐브맵을 사용하세요~
// 본 스크립트는 유니티의 RenderCubemapWizard.js를 바탕으로 만들어졌습니다.

using UnityEngine;
using UnityEditor;

class RenderCubemapCS : ScriptableWizard
{
   // 우측 항의 이름이 GUI 항목 이름이 된다.
   public Transform renderFromPosition;
   public Cubemap cubemap;

   void OnWizardUpdate()
   {
      helpString = "큐브맵을 생성 할 위치 Transform과 생성 될 Cubemap을 설정하세요";
      isValid = (renderFromPosition != null) && (cubemap != null);
   }

   void OnWizardCreate()
   {
      // 큐브 맵 생성에 사용될 임시 카메라를 생성한다.
      GameObject go = new GameObject("CubemapCamera", typeof(Camera));

      // 생성한 카메라를 렌더링 할 위치에 놓는다.
      go.transform.position = renderFromPosition.position;
      go.transform.rotation = Quaternion.identity;

      // 큐브 맵을 특정 포멧으로 원하는 디렉토리에 생성하기
      //Cubemap cubemap2 = new Cubemap(64, TextureFormat.ARGB32, false);
      //AssetDatabase.CreateAsset(cubemap2, "Assets/cubemapTest.cubemap");
      
      // 큐브 맵을 생성한다.
      go.GetComponent<Camera>().RenderToCubemap(cubemap);

      // 임시 카메라를 삭제한다.
      DestroyImmediate(go);
   }

   [MenuItem("GameObject/Render into Cubemap CS")]
   public static void RenderCubemap()
   {
      ScriptableWizard.DisplayWizard<RenderCubemapCS>(
      "큐브 맵 생성", "렌더!");
   }
}
