using UnityEngine;
using Unity.Scenes;

public class SubSceneReference : MonoBehaviour
{
    public static SubSceneReference Instance { get; private set; }

    public SubScene subscene;

    private void Awake()
    {
        Instance = this;
    }
}
