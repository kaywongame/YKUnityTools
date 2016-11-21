using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Collections;


[CustomEditor(typeof(RawImageExtended))]
public class RawImageExtendedEditor :  UnityEditor.UI.RawImageEditor {

	SerializedProperty m_TestCurve;
	SerializedProperty m_Verts;
	
	protected override void OnEnable()
	{
	   base.OnEnable();
	   m_TestCurve           = serializedObject.FindProperty("m_TestCurve");
	   m_Verts            = serializedObject.FindProperty("m_Verts");
	
	}

	public override void OnInspectorGUI() {
		base.OnInspectorGUI();

		serializedObject.Update();

		EditorGUILayout.PropertyField(m_TestCurve);
		EditorGUILayout.PropertyField(m_Verts, true);

		serializedObject.ApplyModifiedProperties();
//		RawImageExtended component = (RawImageExtended)target;
//		
//		EditorGUILayout.ColorField("Test Color", Color.red);
//		EditorGUILayout.CurveField("Test Curve", m_TestCurve);
//		EditorGUILayout.Vector3Field("Test Vector3", component.m_Verts[0]);

	}

}

