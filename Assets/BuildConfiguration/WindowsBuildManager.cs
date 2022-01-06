using UnityEngine;
using UnityEditor;
using Unity.Build;

public class WindowsBuildManager
{
    [MenuItem("Builds/Build Windows Client")]
    public static void BuildClient()
    {
        Debug.Log("Building Windows Client");
        var buildSettings = (BuildConfiguration)AssetDatabase.LoadAssetAtPath("Assets/BuildConfiguration/SceneExampleWindowsBuildConfiguration.buildconfiguration",
            typeof(BuildConfiguration));

        buildSettings.Build();
    }
}
