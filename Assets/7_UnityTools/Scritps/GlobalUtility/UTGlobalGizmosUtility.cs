using UnityEngine;
using System.Collections;

public class UTGlobalGizmosUtility
{
	
	private static void DrawArrow_(Vector3 a_StartPos, Vector3 a_EndPos, Color a_Color, float a_Scale)
	{
		Gizmos.color = a_Color;
		
		/// The main line
		Gizmos.DrawLine (a_StartPos, a_EndPos);
		
		
		/// The Arrow Head
		Vector3 arrowVec = a_EndPos - a_StartPos;
		float angle = Vector3.Angle (Vector3.right, arrowVec);
		Vector3 rotAxis = Vector3.Cross (Vector3.right, arrowVec);
		
		Quaternion quatRot = Quaternion.AngleAxis (angle, rotAxis);
		Matrix4x4 matRot = Matrix4x4.TRS (a_EndPos, quatRot, Vector3.one);
		
		Gizmos.matrix = Gizmos.matrix * matRot;
		Gizmos.DrawLine (Vector3.zero, new Vector3 (-0.2f, 0.1f) * a_Scale);
		Gizmos.DrawLine (Vector3.zero, new Vector3 (-0.2f, -0.1f) * a_Scale);
		Gizmos.DrawLine (Vector3.zero, new Vector3 (-0.2f, 0, 0.1f) * a_Scale);
		Gizmos.DrawLine (Vector3.zero, new Vector3 (-0.2f, 0, -0.1f) * a_Scale);
		
	}

	public static void DrawArrow (Vector3 a_StartPos, Vector3 a_EndPos, Color a_Color, float a_Scale)
	{
		Gizmos.matrix = Matrix4x4.identity;
		
		DrawArrow_(a_StartPos, a_EndPos, a_Color, a_Scale);
		
		Gizmos.matrix = Matrix4x4.identity;
	}

	public static void DrawArrowInLocal (Vector3 a_StartPos, Vector3 a_EndPos, Color a_Color, Transform a_Transform, float a_Scale)
	{
		Gizmos.matrix = a_Transform.localToWorldMatrix;
		
		DrawArrow_(a_StartPos, a_EndPos, a_Color, a_Scale);
		
		Gizmos.matrix = Matrix4x4.identity;
	}


	public static void DrawArrow (Vector3 a_StartPos, Vector3 a_Vector, float a_Scale, Color a_Color)
	{
		Gizmos.matrix = Matrix4x4.identity;
		Gizmos.color = a_Color;
		
		Vector3 endPos = a_StartPos + a_Vector;
		DrawArrow_(a_StartPos, endPos, a_Color, a_Scale);
		
		Gizmos.matrix = Matrix4x4.identity;
	}

	public static void DrawArrowInLocal (Vector3 a_StartPos, Vector3 a_Vector, Transform a_Transform, float a_Scale, Color a_Color)
	{
		Gizmos.matrix = a_Transform.localToWorldMatrix;
		
		Vector3 endPos = a_StartPos + a_Vector;
		DrawArrow_(a_StartPos, endPos, a_Color, a_Scale);
		
		Gizmos.matrix = Matrix4x4.identity;
	}





	/// <summary>
	/// Represent a scalar value by radius of a sphere
	/// </summary>
	/// <param name="a_Position"> A position for the sphere center </param> 
	/// <param name="a_Scalar"> A scalar value will be used for radius of a sphere</param> 
	/// <param name="a_Color"> </param>
	public static void DrawScalarAsSphere (Vector3 a_Position, float a_Scalar, Color a_Color)
	{
		Gizmos.color = a_Color;
		Gizmos.DrawWireSphere (a_Position, a_Scalar);
	}



	/// <summary>
	/// Draw a line representing a vector starting from a_StartPont
	/// </summary>
	/// <param name="a_StartPoint"></param>
	/// <param name="a_Vec3"></param>
	/// <param name="a_Size"></param>
	public static void DrawVectorAtPoint (Vector3 a_StartPoint, Vector3 a_Vec, float a_PointSize)
	{
		DrawVectorAtPoint (a_StartPoint, a_Vec, a_PointSize, Color.blue);
	}


	public static void DrawVectorAtPoint (Vector3 a_StartPoint, Vector3 a_Vec, float a_PointSize, Color a_Color)
	{
		Vector3 endPoint = a_StartPoint + a_Vec;
		DrawVectorBetweenTwoPoints (a_StartPoint, endPoint, a_PointSize, a_Color);
	}


	public static void DrawVectorBetweenTwoPoints (Vector3 a_StartPoint, Vector3 a_EndPoint, float a_PointSize, Color a_Color)
	{
		// From the start point
		Gizmos.color = Color.red;
		Gizmos.DrawSphere (a_StartPoint, a_PointSize);
		
		// to the end point by the given argument vector
		Gizmos.color = Color.blue;
		Gizmos.DrawCube (a_EndPoint, new Vector3 (a_PointSize, a_PointSize, a_PointSize));
		
		// draw a line from the start point to the end point.
		Gizmos.color = a_Color;
		Gizmos.DrawLine (a_StartPoint, a_EndPoint);
		
	}


	/// <summary>
	/// Draw dot product result as a sphere. The radius of sphere represent the result of the dot product. 
	/// </summary>
	/// <param name="a_Vec1Pos"></param>
	/// <param name="a_Vec2Pos"></param>
	/// <param name="a_Vec1"></param>
	/// <param name="a_Vec2"></param>
	/// <param name="a_Vec1Col"></param>
	/// <param name="a_Vec2Col"></param>
	/// <param name="a_dotResultCol"></param>
	/// <param name="a_PointSize"></param>
	/// <returns></returns>
	public static float DrawDotProduct (Vector3 a_Vec1Pos, Vector3 a_Vec2Pos, Vector3 a_Vec1, Vector3 a_Vec2, Color a_Vec1Col, Color a_Vec2Col, Color a_dotResultCol, float a_PointSize)
	{
		DrawVectorAtPoint (a_Vec1Pos, a_Vec1, a_PointSize, a_Vec1Col);
		DrawVectorAtPoint (a_Vec2Pos, a_Vec2, a_PointSize, a_Vec2Col);
		
		//float dotResultVal = Vector3.Dot(a_Vec1, a_Vec2);
		float dotResultVal = UTGlobalMath.DotProduct (a_Vec1.x, a_Vec1.y, a_Vec1.z, a_Vec2.x, a_Vec2.y, a_Vec2.z);
		
		DrawScalarAsSphere (a_Vec1Pos, dotResultVal, a_dotResultCol);
		
		return dotResultVal;
	}


	public static float DrawDotProductUsingThreePoints (Vector3 a_Pos1, Vector3 a_PosMiddle, Vector3 a_Pos2, Color a_Col1, Color a_Col2, Color a_dotResultCol, float a_PointSize)
	{
		// Not Completed
		
		UTGlobalGizmosUtility.DrawVectorBetweenTwoPoints (a_PosMiddle, a_Pos1, a_PointSize, a_Col1);
		UTGlobalGizmosUtility.DrawVectorBetweenTwoPoints (a_PosMiddle, a_Pos2, a_PointSize, a_Col2);
		
		float dotResultVal = Vector3.Dot (a_Pos1 - a_PosMiddle, a_Pos2 - a_PosMiddle);
		
		DrawScalarAsSphere (a_PosMiddle, dotResultVal, a_dotResultCol);
		
		return dotResultVal;
	}


	/// <summary>
	/// Draw cross product result as a line
	/// </summary>
	/// <param name="a_Vec1Pos"></param>
	/// <param name="a_Vec2Pos"></param>
	/// <param name="a_Vec1"></param>
	/// <param name="a_Vec2"></param>
	/// <param name="a_Vec1Col"></param>
	/// <param name="a_Vec2Col"></param>
	/// <param name="a_CrossResultCol"></param>
	/// <param name="a_PointSize"></param>
	/// <returns></returns>
	public static Vector3 DrawCorssProduct (Vector3 a_Vec1Pos, Vector3 a_Vec2Pos, Vector3 a_Vec1, Vector3 a_Vec2, Color a_Vec1Col, Color a_Vec2Col, Color a_CrossResultCol, float a_PointSize)
	{
		
		DrawVectorAtPoint (a_Vec1Pos, a_Vec1, a_PointSize, a_Vec1Col);
		
		DrawVectorAtPoint (a_Vec2Pos, a_Vec2, a_PointSize, a_Vec2Col);
		
		Vector3 crossResultVal = Vector3.Cross (a_Vec1, a_Vec2);
		
		DrawVectorAtPoint (a_Vec1Pos, crossResultVal, a_PointSize, a_CrossResultCol);
		
		
		return crossResultVal;
		
	}
	
}

