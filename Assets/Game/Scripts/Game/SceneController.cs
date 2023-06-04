using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public enum SceneName
    {
        Logo,
        Title,
        Cut,
        MainRoom,
        Dream,
        Dream2,
        EndGame

    }

    public static SceneName sceneName;
    [SerializeField]
    private string Path_Scene = "Game/Scenes/";

    public int ActiveCount = 1;
    public int previousScene;
    
    private AsyncOperation async;

    /* Scene Load */
    /// <summary>
    /// �� �ҷ�����, SceneController Ŭ������ SceneName�� �ùٸ� Scene �̸��� ��������.
    /// </summary>
    /// <param name="scene"></param>
    public void LoadScene(SceneName scene)
    {
        SceneManager.LoadScene(Path_Scene + scene.ToString());
    }
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(Path_Scene + scene);
    }
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(Path_Scene + sceneName.ToString());
    }

    public void AdditveScene(int scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(1));
        ActiveCount++;
    }

    public void UnloadScene()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(0));
        SceneManager.UnloadSceneAsync(previousScene);
        ActiveCount--;
    }


    public void PreloadScene(string sceneName)
    {
        async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;
    }

    public void PlayPreloadScene()
    {
        if (async == null) return;

        async.allowSceneActivation = true;
    }
}
