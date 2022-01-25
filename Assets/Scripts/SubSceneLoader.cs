using Unity.Entities;
using Unity.Scenes;
using UnityEngine;

public class SubSceneLoader : ComponentSystem
{
    private SceneSystem sceneSystem;

    protected override void OnCreate()
    {
        sceneSystem = World.GetExistingSystem<SceneSystem>();
    }

    protected override void OnUpdate()
    {
        if (SubSceneReference.Instance == null)
        {
            return;
        }

        SubScene subScene = SubSceneReference.Instance.subscene;

        double timeMod = Time.ElapsedTime % 2;
        if (timeMod < 0.01)
        {
            sceneSystem.LoadSceneAsync(subScene.SceneGUID);
        }

        if (timeMod > 1.00 && timeMod < 1.01)
        {
            sceneSystem.UnloadScene(subScene.SceneGUID);
        }
    }
}
