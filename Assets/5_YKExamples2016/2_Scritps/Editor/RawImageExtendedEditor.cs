using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Collections;


[CustomEditor(typeof(RawImageExtended))]
public class RawImageExtendedEditor :  UnityEditor.UI.RawImageEditor {

	public override void OnInspectorGUI() {

    RawImageExtended component = (RawImageExtended)target;

    base.OnInspectorGUI();

//    component.onSprite = (Sprite)EditorGUILayout.ObjectField("On Sprite", component.onSprite, typeof(Sprite), true);
//    component.onTextColor = EditorGUILayout.ColorField("On text colour", component.onTextColor);
//    component.offSprite = (Sprite)EditorGUILayout.ObjectField("Off Sprite", component.offSprite, typeof(Sprite), true);
//    component.offTextColor = EditorGUILayout.ColorField("Off text colour", component.offTextColor);

}

}

