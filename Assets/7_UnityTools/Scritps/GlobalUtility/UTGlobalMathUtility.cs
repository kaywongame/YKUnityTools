/// <summary>
/// Utilities for Mathematics Functions
/// 
/// by Yunkyu Choi
/// Last Update: 2011/09/05
/// </summary>


using UnityEngine;
using System.Collections;

namespace UnityTools.Math
{

public enum UTMatrix { 
   CamToWorld, WorldToCam, Projection,LocalToWorld, WorldToLocal, Custom };


public static class UTGlobalMathUtility
{
   

   /// <summary>
   /// Only Display [00.000] format
   /// </summary>
   /// <param name="a_m4Matrix">
   /// A <see cref="Matrix4x4"/>
   /// </param>
   /// <returns>
   /// A <see cref="System.String"/>
   /// </returns>
   public static string MatrixToString(Matrix4x4 a_m4Matrix)
   {
      Vector4 row1 = a_m4Matrix.GetRow(0);
      Vector4 row2 = a_m4Matrix.GetRow(1);
      Vector4 row3 = a_m4Matrix.GetRow(2);
      Vector4 row4 = a_m4Matrix.GetRow(3);

      //string matrixStr = a_m4Matrix.ToString();
      string matrixStr = "";

      /// m Rows and n Columns
      /// [m0 n0] .... [m0 n3]
      /// [m1 n0] .... [m1 n3]
      /// [m2 n0] .... [m2 n3]
      /// [m3 n0] .... [m3 n3]
      for (int row = 0; row < 4; row++)
      {

         for (int col = 0; col < 4; col++)
         {
            matrixStr += "[ ";
            matrixStr += string.Format("{0:00.00}", a_m4Matrix[row, col]);
            matrixStr += " ]  ";
         }

         matrixStr += "\n";
      }

      return matrixStr;
   }


}

}