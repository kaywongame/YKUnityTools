using System;
using System.IO;            // 1. Include System.IO for Directory class
using UnityEditor;          //    Include UnityEditor 
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Editor tool that create Prefabs under specificed folder
/// * Create Prefabs from selected GameObjects in Hierarchy view
/// 
/// Created by: Yunkyu Choi 2011. 07. 17
/// Last Modified: 2014/6/10
/// </summary>
public class UTHierarchyControl: EditorWindow {
    
    // 2. Add a static window class
    static UTHierarchyControl ms_Window;

    static string ms_PrefabPath = "Assets/";

    // 3. Add Menu items
    [MenuItem("UnityTools/Create Prefabs %&o")]
    static void CreatePrefabs()
    {
        // Get Only GameObject type (GameObject or Prefab is GameObject type)
        foreach (GameObject go in Selection.GetFiltered(typeof(GameObject), SelectionMode.DeepAssets))
       {
         if(EditorPrefs.HasKey("UTCreatePrefabsPath"))
         {
            ms_PrefabPath = EditorPrefs.GetString("UTCreatePrefabsPath");
         }
         
            string path = ms_PrefabPath + go.name + ".prefab";

            if (AssetDatabase.LoadAssetAtPath(path, typeof(GameObject) )) 
            {
                if (EditorUtility.DisplayDialog("Replace Existing Prefab",
                "The prefab [" + path + "] already exists. Do you want to overwrite it?",
                "Yes",
                "No"))
                {   
                    CreatePrefabAtPath(go, path);
                }

            } else {
                CreatePrefabAtPath(go, path);
            }

       }
        
    }

    
    // 3. Add Menu items
    [MenuItem("UnityTools/Select folder for Prefab creation %&l")]
    static void SelectFolderForPrefabs()
    {
       
        // Show the GUI window
        if (ms_Window == null)
        {
            ms_Window = (UTHierarchyControl)GetWindow(typeof(UTHierarchyControl));
            ms_Window.autoRepaintOnSceneChange = true;
        }

        ms_Window.Show();
    }


    // 4. Add GUI for window
    void OnGUI()
    {
      if(EditorPrefs.HasKey("UTCreatePrefabsPath"))
      {
         ms_PrefabPath = EditorPrefs.GetString("UTCreatePrefabsPath");
      }
   
        GUILayout.Label("Select Folder for Prefabs creation");

        EditorGUILayout.LabelField("Save Path: ", ms_PrefabPath);

        // Set the selected folder as prefab save path
        if (GUILayout.Button("Select Path"))
        {

            UnityEngine.Object[] folders = Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets);

            if (folders == null) return;
            if (folders[0] == null) return;

            // Directory is UnityEngine.Object type
            if (folders[0].GetType() != typeof(UnityEngine.Object)){
                Debug.Log("Wrong Type Selected!");
                return;
            }

            string path = AssetDatabase.GetAssetPath(folders[0]) + "/";

            // if it is not a directory
            if (!Directory.Exists(path))
            {
                Debug.Log(path + "Folder Not exist");
            }
            else
            {
            // Save the path as EditorPref
            EditorPrefs.SetString("UTCreatePrefabsPath", path);
            
                ms_PrefabPath = path;

                AssetDatabase.Refresh();

                Debug.Log("Folder for saving Prefab: " + ms_PrefabPath);
            }
        }

        EditorGUILayout.Space();
        EditorGUILayout.Separator();
        EditorGUILayout.Space();


        if (GUILayout.Button("Create Prefabs at the Path"))
        {
            CreatePrefabs();
        }
      
      
      // Drag Test
        if ((Event.current.type == EventType.DragUpdated) || (Event.current.type == EventType.DragPerform))
        {
            
            foreach (UnityEngine.Object go in DragAndDrop.objectReferences)
            {
                Debug.Log("Drag : " + go.name + " : type : " + go.GetType());
            }
        }
        else
        {
            //foreach (UnityEngine.Object go in DragAndDrop.objectReferences)
            //{
            //    Debug.Log("-Drag : " + go.name + " : type : " + go.GetType());
            //}
        }


    }

    // 5. Add the real function which will do the work!
    static void CreatePrefabAtPath(GameObject go, string path)
    {
        // Create an empty prefab
        UnityEngine.Object prefab = EditorUtility.CreateEmptyPrefab(path);

        // Connect the GO and the empty prefab
        EditorUtility.ReplacePrefab(go, prefab);

        AssetDatabase.Refresh();

        // Delete previous GO because it is not linked to the created Prefab
        DestroyImmediate(go);
        // Instantiate a GO from the created Prefab
        GameObject linkedGO = EditorUtility.InstantiatePrefab(prefab) as GameObject;
    }

}
