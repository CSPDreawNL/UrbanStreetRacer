using UnityEngine;
using UnityEditor;

public class PrefabTool : EditorWindow
{
    [MenuItem("Tools/Prefab Making Tool")]
    public static void ShowWindow()
    {
        GetWindow(typeof(PrefabTool));
    }

    private void OnGUI()
    {
        GUILayout.Label("Make a Prefabs in the Prefab folder of the selected object.", EditorStyles.boldLabel);
        if (GUILayout.Button("Make Prefabs"))
        {
            MakePrefab();
        }
    }

    private void MakePrefab()
    {
        GameObject[] objectArray = Selection.gameObjects;
        foreach (GameObject gameObject in objectArray)
        {
            string localPath = "Assets/Prefabs/" + gameObject.name + ".prefab";
            localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
            PrefabUtility.SaveAsPrefabAssetAndConnect(gameObject, localPath, InteractionMode.UserAction);
        }
    }
}
