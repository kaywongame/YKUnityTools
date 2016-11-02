using System;
using System.IO;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


/// <summary> 
/// Folder Creator
/// Created by: Yunkyu Choi
/// Last Modified: 2014/6/10 
/// </summary>
public class UTCreateBasicFolders: EditorWindow{

    static List<string> m_FolderNames = new List<string>();

    static UTCreateBasicFolders m_Window;

    /// <summary>
    /// Create basic folders under the selected folder in Hierarchy view
    /// </summary>
    /// <remarks>
    /// Only Static function can be a menu
    /// </remarks>
    [MenuItem("UnityTools/Create Basic Folders %&c")]
    static void CreateBasicFoldersMenu()
    {
        Debug.Log("Start Create Basic Folders");

        if (m_Window == null)
        {
        
            m_Window = (UTCreateBasicFolders)GetWindow(typeof(UTCreateBasicFolders));
        }
        
        // Set hardcoded folder name
      if(EditorPrefs.HasKey("UTCreateBasicFolders"))
      {
			// Read EditorPrefs value and add values as folder names
         // To Be Added	
      }
      else
      {
           m_FolderNames.Add("1_Scenes");
   
           m_FolderNames.Add("2_Scritps");
   
           m_FolderNames.Add("3_Models");
           m_FolderNames.Add("4_Materials");
           m_FolderNames.Add("5_Shaders");
           m_FolderNames.Add("6_Textures");
			  m_FolderNames.Add("7_Music");
			  m_FolderNames.Add("8_Sound");
   
         m_FolderNames.Add("9_Prefabs");
      }
      
        m_Window.Show();           
    }


    /// <summary>
    /// GUI on editor window
    /// </summary>
    void OnGUI()
    {
        GUILayout.Label("Create below directories under the selected folder(s)");

        for (int i = 0; i < m_FolderNames.Count; i++)
      {
            m_FolderNames[i] = EditorGUILayout.TextField(m_FolderNames[i]);
      }

        // Add more folders
        if (GUILayout.Button("Add a folder to list"))
        {
            m_FolderNames.Add("");
            m_FolderNames[m_FolderNames.Count - 1] = EditorGUILayout.TagField("");
        }

        // Remove folders
        if (GUILayout.Button("Remove a folder from list"))
        {
            m_FolderNames.RemoveAt(m_FolderNames.Count - 1);
        }

        EditorGUILayout.Space();
        EditorGUILayout.Separator();

        if (GUILayout.Button("Create Folders"))
        {
            CreateFolders();
        }

    }

    /// <summary>
    /// The real function which will create folders
    /// </summary>
    void CreateFolders()
    {
        Debug.Log("Create Basic Folders");

        // Create folder only on top level of selection
        foreach (UnityEngine.Object o in Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.TopLevel))
        {
            string root = AssetDatabase.GetAssetPath(o);
            // Create directory to store generated materials.


            foreach (string folderName in m_FolderNames)
            {
                string path = root + "/" + folderName + "/";

                if (!Directory.Exists(path))
                {
                    Debug.Log("Create folder: " + path);
                    Directory.CreateDirectory(path);
                }
                else
                {
                    Debug.Log("Create folder fail. Already Exist: " + path);
                }
            }
            
            // Refresh AssetDatabase. So we can see the change
            AssetDatabase.Refresh();
        }
    }
}
