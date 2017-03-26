using UnityEngine;
using System.Collections;

public class VirtualCubemapCreator : MonoBehaviour {

   // 가상 큐브 맵을 만드는데 사용 할 실제 큐브 맵
   public Cubemap m_SourceCubemap;

   // 한 스탭씩 실행을 보이기 위해서 코루틴으로 실행한다.
   IEnumerator Start () {
      
      // 가상 큐브 맵 각 면의 폭(높이) 픽셀 수
      int cubeWH = 16;

      // 가상 큐브 맵면의 중심 위치
      int cubeCnt = cubeWH /2;
      
      // 원본 큐브 맵의 폭
      int srcWH = m_SourceCubemap.width;
      
      // 몇 픽셀씩 건너면서 샘플링 할지 
      int step = srcWH / cubeWH;


      for (int x = 0; x < cubeWH; x++)
      {
         for (int y = 0; y < cubeWH; y++)
         {
            
            // X+ 평면
            CreateBlockPlan(CubemapFace.PositiveX, step, x, y,
               0, -y, -x, cubeCnt, cubeCnt, cubeCnt);
            // X- 평면
            CreateBlockPlan(CubemapFace.NegativeX, step, x, y,
               0, -y, x, -cubeCnt, cubeCnt, -cubeCnt);


            // Y+ 평면
            CreateBlockPlan(CubemapFace.PositiveY, step, x, y,
               -x, 0, y, cubeCnt, cubeCnt, -cubeCnt);
            // Y- 평면
            CreateBlockPlan(CubemapFace.NegativeY, step, x, y,
               x, 0, -y, -cubeCnt, -cubeCnt, cubeCnt);


            // Z+ 평면
            CreateBlockPlan(CubemapFace.PositiveZ, step, x, y,
               x, -y, 0, -cubeCnt, cubeCnt, cubeCnt);
            // Z- 평면
            CreateBlockPlan(CubemapFace.NegativeZ, step, x, y,
               -x, -y, 0, cubeCnt, cubeCnt, -cubeCnt);

            // 각 면의 큐브를 한개씩 생성한 후 0.05 초씩 쉰다
            yield return new WaitForSeconds(0.05f);
         }
      }
   }

   // 가상 큐브 맵의 각 면을 생성 해준다.
   void CreateBlockPlan(CubemapFace a_CubeFace, int a_Step, int a_i, int a_j,
      int a_X, int a_Y, int a_Z, int a_Xcnt, int a_Ycnt, int a_Zcnt)
   {

      // 가상 픽셀 생성
      GameObject cubePixel = GameObject.CreatePrimitive(PrimitiveType.Cube);

      // 위치 설정
      cubePixel.transform.position = new Vector3(
         a_X + a_Xcnt, a_Y + a_Ycnt, a_Z + a_Zcnt);

      // 색 설정
      Material mat = new Material(Shader.Find("Self-Illumin/Diffuse"));

      // 실제 큐브 맵으로 부터 색상 값을 가져온다.
      mat.color =
         m_SourceCubemap.GetPixel(a_CubeFace, a_Step * a_i, a_Step * a_j);
      
      // 매터리얼 설정
      cubePixel.transform.GetComponent<Renderer>().material = mat;

      // 부모 설정
      cubePixel.transform.parent = transform;
   }

}
