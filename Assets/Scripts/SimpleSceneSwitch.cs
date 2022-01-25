using Unity.Entities;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Scenes;

public class SimpleSceneSwitch : MonoBehaviour
{
    public float scale = 1f;

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void Start()
    {
        SceneManager.LoadScene(1);
        //NextScene();
    }

    void OnGUI()
    {
        GUI.skin.label.fontSize = Mathf.RoundToInt(16 * scale);
        GUI.color = new Color(1, 1, 1, 1);
        float w = 410 * scale;
        float h = 90 * scale;
        GUILayout.BeginArea(new Rect(Screen.width - w - 5, Screen.height - h - 5, w, h), GUI.skin.box);

        GUILayout.BeginHorizontal();
        GUIStyle customButton = new GUIStyle("button");
        customButton.fontSize = GUI.skin.label.fontSize;
        if (GUILayout.Button("\n Prev \n", customButton, GUILayout.Width(200 * scale), GUILayout.Height(50 * scale))) PrevScene();
        if (GUILayout.Button("\n Next \n", customButton, GUILayout.Width(200 * scale), GUILayout.Height(50 * scale))) NextScene();
        GUILayout.EndHorizontal();

        int currentpage = SceneManager.GetActiveScene().buildIndex;
        int totalpages = SceneManager.sceneCountInBuildSettings - 1;
        GUILayout.Label(currentpage + " / " + totalpages + " " + SceneManager.GetActiveScene().name);

        GUILayout.EndArea();
    }

    public void NextScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        CleanUp();

        if (sceneIndex < SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(sceneIndex + 1);
        else
            SceneManager.LoadScene(1);
    }

    public void PrevScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        CleanUp();

        if (sceneIndex > 1)
            SceneManager.LoadScene(sceneIndex - 1);
        else
            SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    public void CleanUp()
    {
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        entityManager.DestroyEntity(entityManager.GetAllEntities());
    }

    /*
    public void loadSubScene()
    {
        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        var sceneSystem = entityManager.World.GetExistingSystem<SceneSystem>();
        sceneSystem.LoadSceneAsync(sceneSystem.GetSceneGUID("Assets/Scenes/Scene-03/SubScenes/RoatingMultiCudeSubScene.unity"));
    }

    public void unloadSubScene()
    {
        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        var sceneSystem = entityManager.World.GetExistingSystem<SceneSystem>();
        sceneSystem.UnloadScene(sceneSystem.GetSceneGUID("Assets/Scenes/Scene-03/SubScenes/RoatingMultiCudeSubScene.unity"));
    }
    */
}
