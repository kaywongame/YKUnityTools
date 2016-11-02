/// <summary>
/// Mathematics Helpers
/// 
/// by Yunkyu Choi
/// Last Update: 2011/09/05
/// </summary>

using UnityEngine;
using System.Collections;


public class UTGlobalMath
{

   /// <summary>
   /// Dot Product between two 3D Vectors 
   /// </summary> 
   public static float DotProduct (float a_V1_x, float a_V1_y, float a_V1_z, float a_V2_x, float a_V2_y, float a_V2_z)
   {
      
      return a_V1_x * a_V2_x + a_V1_y * a_V2_y + a_V1_z * a_V2_z;
      
   }


   public static float DotProductUsingThreePoints (Vector3 a_Pos1, Vector3 a_PosMiddle, Vector3 a_Pos2)
   {
      float dotResultVal = Vector3.Dot (a_Pos1 - a_PosMiddle, a_Pos2 - a_PosMiddle);
      
      return dotResultVal;
   }


   public static Quaternion QuaternionFromMatrix (Matrix4x4 a_M4)
   {
      // Adapted from: 
      // http://www.euclideanspace.com/maths/geometry/rotations/conversions/matrixToQuaternion/index.htm
      Quaternion quat = new Quaternion ();
      
      quat.w = Mathf.Sqrt (Mathf.Max (0, 1 + a_M4[0, 0] + a_M4[1, 1] + a_M4[2, 2])) / 2;
      quat.x = Mathf.Sqrt (Mathf.Max (0, 1 + a_M4[0, 0] - a_M4[1, 1] - a_M4[2, 2])) / 2;
      quat.y = Mathf.Sqrt (Mathf.Max (0, 1 - a_M4[0, 0] + a_M4[1, 1] - a_M4[2, 2])) / 2;
      quat.z = Mathf.Sqrt (Mathf.Max (0, 1 - a_M4[0, 0] - a_M4[1, 1] + a_M4[2, 2])) / 2;
      
      quat.x *= Mathf.Sign (quat.x * (a_M4[2, 1] - a_M4[1, 2]));
      quat.y *= Mathf.Sign (quat.y * (a_M4[0, 2] - a_M4[2, 0]));
      quat.z *= Mathf.Sign (quat.z * (a_M4[1, 0] - a_M4[0, 1]));
      
      return quat;
   }

   /// <summary>
   /// Multiply Z axis with -1 
   /// </summary>
   /// <param name="a_M4">
   /// A <see cref="Matrix4x4"/>
   /// </param>
   /// <returns>
   /// A <see cref="Quaternion"/>
   /// </returns>
   public static Quaternion QuaternionFromMatrixForCam (Matrix4x4 a_M4)
   {
      // Adapted from: 
      // http://www.euclideanspace.com/maths/geometry/rotations/conversions/matrixToQuaternion/index.htm
      Quaternion quat = new Quaternion ();
      
      quat.w = Mathf.Sqrt (Mathf.Max (0, 1 + a_M4[0, 0] + a_M4[1, 1] - a_M4[2, 2])) / 2;
      quat.x = Mathf.Sqrt (Mathf.Max (0, 1 + a_M4[0, 0] - a_M4[1, 1] + a_M4[2, 2])) / 2;
      quat.y = Mathf.Sqrt (Mathf.Max (0, 1 - a_M4[0, 0] + a_M4[1, 1] + a_M4[2, 2])) / 2;
      quat.z = Mathf.Sqrt (Mathf.Max (0, 1 - a_M4[0, 0] - a_M4[1, 1] - a_M4[2, 2])) / 2;
      
      quat.x *= Mathf.Sign (quat.x * (a_M4[2, 1] + a_M4[1, 2]));
      quat.y *= Mathf.Sign (quat.y * (-a_M4[0, 2] - a_M4[2, 0]));
      quat.z *= Mathf.Sign (quat.z * (a_M4[1, 0] - a_M4[0, 1]));
      
      return quat;
   }

   public static Quaternion ZFTQuaternionFromMatrix (Matrix4x4 a_M4)
   {
      Quaternion quat = new Quaternion ();
      
      // Begin : Rotation matrix 3*3 to Quaternion
      float trace = a_M4[0] + a_M4[5] + a_M4[10];
      
      if (trace > 0) {
         float s = 0.5f / Mathf.Sqrt (trace + 1.0f);
         quat.w = 0.25f / s;
         quat.x = (a_M4[6] - a_M4[9]) * s;
         quat.y = (a_M4[8] - a_M4[2]) * s;
         quat.z = (a_M4[1] - a_M4[4]) * s;
      } else {
         if (a_M4[0] > a_M4[5] && a_M4[0] > a_M4[10]) {
            float s = 2.0f * Mathf.Sqrt (1.0f + a_M4[0] - a_M4[5] - a_M4[10]);
            quat.w = (a_M4[6] - a_M4[9]) / s;
            quat.x = 0.25f * s;
            quat.y = (a_M4[4] + a_M4[1]) / s;
            quat.z = (a_M4[8] + a_M4[2]) / s;
         } else if (a_M4[5] > a_M4[10]) {
            float s = 2.0f * Mathf.Sqrt (1.0f + a_M4[5] - a_M4[0] - a_M4[10]);
            quat.w = (a_M4[8] - a_M4[2]) / s;
            quat.x = (a_M4[4] + a_M4[1]) / s;
            quat.y = 0.25f * s;
            quat.z = (a_M4[9] + a_M4[6]) / s;
         } else {
            float s = 2.0f * Mathf.Sqrt (1.0f + a_M4[10] - a_M4[0] - a_M4[5]);
            quat.w = (a_M4[1] - a_M4[4]) / s;
            quat.x = (a_M4[8] + a_M4[2]) / s;
            quat.y = (a_M4[9] + a_M4[6]) / s;
            quat.z = 0.25f * s;
         }
      }
      
      return quat;
   }
   
   
   public static Matrix4x4 ZFTMatrixFromQuaternionPosLH (Quaternion a_Quat, Vector3 a_Pos)
   {
      Matrix4x4 a_M4 = Matrix4x4.identity;
      
      float ww = a_Quat.w * a_Quat.w;
      float xx = a_Quat.x * a_Quat.x;    
      float yy = a_Quat.y * a_Quat.y;    
      float zz = a_Quat.z * a_Quat.z;
      
      float xy = a_Quat.x * a_Quat.y;
      float zw = a_Quat.z * a_Quat.w;
            
      float xz = a_Quat.x * a_Quat.z;
      float yw = a_Quat.y * a_Quat.w;
            
      float yz = a_Quat.y * a_Quat.z;
      float xw = a_Quat.x * a_Quat.w;
      
      float oneOverSum = 1.0f / (xx + yy + zz + ww);
      
      a_M4[0]  = ( xx - yy - zz + ww) * oneOverSum ; 
      a_M4[5]  = (-xx + yy - zz + ww) * oneOverSum ;    
      a_M4[10] = (-xx - yy + zz + ww) * oneOverSum ;        

      a_M4[1] = 2.0f * (xy + zw) * oneOverSum ;
      a_M4[4] = 2.0f * (xy - zw) * oneOverSum ;
      
      a_M4[2] = 2.0f * (xz - yw) * oneOverSum ;
      a_M4[8] = 2.0f * (xz + yw) * oneOverSum ;
      
      a_M4[6] = 2.0f * (yz + xw) * oneOverSum ;
      a_M4[9] = 2.0f * (yz - xw) * oneOverSum ;
      
      
      // Set position
      a_M4.SetColumn(3, a_Pos);
      a_M4.m33 = 1f;
      
      return a_M4;
   }
 
   
   public static Matrix4x4 ZFTMatrixFromQuaternionPosRH (Quaternion a_Quat, Vector3 a_Pos)
   {
      Matrix4x4 a_M4 = Matrix4x4.identity;
      
      float sqw = a_Quat.w * a_Quat.w;
      float sqx = a_Quat.x * a_Quat.x;    
      float sqy = a_Quat.y * a_Quat.y;    
      float sqz = a_Quat.z * a_Quat.z;
      float tmp1,tmp2;        

      float oneOverSum = 1.0f / (sqx + sqy + sqz + sqw);
      
      a_M4[0]  = ( sqx - sqy - sqz + sqw) * oneOverSum ; 
      a_M4[5]  = (-sqx + sqy - sqz + sqw) * oneOverSum ;    
      a_M4[10] = (-sqx - sqy + sqz + sqw) * oneOverSum ;        

      tmp1 = a_Quat.x * a_Quat.y;  
      tmp2 = -a_Quat.z * a_Quat.w;  
      
      a_M4[1] = 2.0f * (tmp1 + tmp2) * oneOverSum ;
      a_M4[4] = 2.0f * (tmp1 - tmp2) * oneOverSum ;
      
      tmp1 = a_Quat.x * a_Quat.z;    
      tmp2 = -a_Quat.y * a_Quat.w;
      
      a_M4[2] = 2.0f * (tmp1 - tmp2) * oneOverSum ;
      a_M4[8] = 2.0f * (tmp1 + tmp2) * oneOverSum ;
      
      tmp1 = a_Quat.y * a_Quat.z;
      tmp2 = -a_Quat.x * a_Quat.w;
      
      a_M4[6] = 2.0f * (tmp1 + tmp2) * oneOverSum ;
      a_M4[9] = 2.0f * (tmp1 - tmp2) * oneOverSum ;
      
      
      // Set position
      a_M4.SetColumn(3, a_Pos);
      a_M4.m33 = 1f;
      
      return a_M4;
   }
   
   
   /// Left hand coordinate version of matrix from quaternion 
   public static Matrix4x4 MatrixFromQuaternionPosLH (Quaternion a_Quat, Vector3 a_Pos)
   {
      Matrix4x4 mat = new Matrix4x4();
      
      float xx = a_Quat.x * a_Quat.x;
      float xy = a_Quat.x * a_Quat.y;
      float xz = a_Quat.x * a_Quat.z;
      float xw = -a_Quat.x * a_Quat.w;
      
      float yy = a_Quat.y * a_Quat.y;
      float yz = a_Quat.y * a_Quat.z;
      float yw = -a_Quat.y * a_Quat.w;
      
      float zz = a_Quat.z * a_Quat.z;
      float zw = -a_Quat.z * a_Quat.w;
      
      mat.m00 = 1-2 * (yy + zz); mat.m01 =     2 * ( xy + zw ); mat.m02 =     2 * ( xz - yw ); mat.m03 = a_Pos.x;
      mat.m10 =   2 * (xy - zw); mat.m11 = 1 - 2 * ( xx + zz ); mat.m12 =     2 * ( yz + xw ); mat.m13 = a_Pos.y;
      mat.m20 =   2 * (xz + yw); mat.m21 =     2 * ( yz - xw ); mat.m22 = 1 - 2 * ( xx + yy ); mat.m23 = a_Pos.z;
      mat.m30 =              0f; mat.m31 =                  0f; mat.m32 =                  0f; mat.m33 =      1f;
      
      return mat;
   }
      
   /// Right hand coordinate version of matrix from quaternion 
   public static Matrix4x4 MatrixFromQuaternionPosRH (Quaternion a_Quat, Vector3 a_Pos)
   {
      Matrix4x4 mat = new Matrix4x4();
      
      float xx = a_Quat.x * a_Quat.x;
      float xy = a_Quat.x * a_Quat.y;
      float xz = a_Quat.x * a_Quat.z;
      float xw = a_Quat.x * a_Quat.w;
      
      float yy = a_Quat.y * a_Quat.y;
      float yz = a_Quat.y * a_Quat.z;
      float yw = a_Quat.y * a_Quat.w;
      
      float zz = a_Quat.z * a_Quat.z;
      float zw = a_Quat.z * a_Quat.w;
      
      mat.m00 = 1-2 * (yy + zz); mat.m01 =     2 * ( xy + zw ); mat.m02 =     2 * ( xz - yw ); mat.m03 = a_Pos.x;
      mat.m10 =   2 * (xy - zw); mat.m11 = 1 - 2 * ( xx + zz ); mat.m12 =     2 * ( yz + xw ); mat.m13 = a_Pos.y;
      mat.m20 =   2 * (xz + yw); mat.m21 =     2 * ( yz - xw ); mat.m22 = 1 - 2 * ( xx + yy ); mat.m23 = a_Pos.z;
      mat.m30 =              0f; mat.m31 =                  0f; mat.m32 =                  0f; mat.m33 =      1f;
      
      return mat;
   }
   
   /// Inverse of Quaternion
   public static Quaternion QuaternionConjugate(Quaternion a_Quat)
   {
      Quaternion quat = new Quaternion(-a_Quat.x, -a_Quat.y, -a_Quat.z, a_Quat.w);
      
      return quat;
   }
   
   
   /// Magnitude of Quaternion
   public static float QuaternionMagnitude(Quaternion a_Quat)
   {
      Quaternion quatConj = QuaternionConjugate(a_Quat);
      
      return Mathf.Sqrt ( QuaternionDistance(a_Quat, quatConj) );
   }
   
   
   public static Quaternion QuaternionMult(Quaternion a_QuatA, Quaternion a_QuatB)
   {
      Vector3 VecA = new Vector3(a_QuatA.x, a_QuatA.y, a_QuatA.z);
      
      Vector3 VecB = new Vector3(a_QuatB.x, a_QuatB.y, a_QuatB.z);
      
      Vector3 VecC = a_QuatA.w * VecB + 
                     a_QuatB.w * VecA +
                     Vector3.Cross(VecA, VecB);
      
      Quaternion resultQuat = new Quaternion(VecC.x, VecC.y, VecC.z, 
                                             a_QuatA.w * a_QuatB.w); 
      
      return resultQuat;
   }
   
   
   /// <summary>
   /// Only for test
   /// </summary>
   public static float QuaternionDistance (Quaternion a_QuatA, Quaternion a_QuatB)
   {
      return Vector4.Dot (new Vector4 (a_QuatA.x, a_QuatA.y, a_QuatA.z, a_QuatA.w), 
                          new Vector4 (a_QuatB.x, a_QuatB.y, a_QuatB.z, a_QuatB.w));
   }

   /// <summary>
   /// Only for test
   /// </summary>
   public static float QuaternionDistanceAngle (Quaternion a_QuatA, Quaternion a_QuatB)
   {
      float halfRot = Vector4.Dot (new Vector4 (a_QuatA.x, a_QuatA.y, a_QuatA.z, a_QuatA.w), 
                                   new Vector4 (a_QuatB.x, a_QuatB.y, a_QuatB.z, a_QuatB.w));
      
      return Mathf.Rad2Deg * Mathf.Acos(halfRot) * 2.0f;
      
   }

   

   /// <summary>
   /// Return Angle in Degree 
   /// </summary>
   /// <param name="a_D">
   /// A <see cref="System.Single"/>
   /// </param>
   /// <returns>
   /// A <see cref="System.Single"/>
   /// </returns>
   public static float AngleDegreeFromProjM_D (float a_D)
   {
      
      return Mathf.Atan (1f / a_D) * 2f * Mathf.Rad2Deg;
      
   }

   /// <summary>
   /// Return d from Angle in Degree 
   /// </summary>
   /// <param name="a_AngleDegree">
   /// A <see cref="System.Single"/>
   /// </param>
   /// <returns>
   /// A <see cref="System.Single"/>
   /// </returns>
   public static float ProjM_D_FromAngle (float a_AngleDegree)
   {
      return 1f / Mathf.Tan (a_AngleDegree * Mathf.Deg2Rad / 2f);
   }
   
   
}
