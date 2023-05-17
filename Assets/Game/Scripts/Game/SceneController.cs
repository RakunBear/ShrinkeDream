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
        LobbyScene

    }

    public SceneName sceneName;
    [SerializeField]
    private string Path_Scene = "Game/Scenes/";

    public int ActiveCount = 1;
    public int previousScene;
    
    /* Scene Load */
    /// <summary>
    /// �� �ҷ�����, SceneController Ŭ������ SceneName�� �ùٸ� Scene �̸��� ��������.
    /// </summary>
    /// <param name="scene"></param>
    public void LoadScene(SceneName scene)
    {
        previousScene = SceneManager.GetActiveScene().buildIndex;
        if (ActiveCount > 1)
            UnloadScene();
        else
            SceneManager.LoadScene(Path_Scene + scene.ToString());
    }
    public void LoadScene(string scene)
    {
        previousScene = SceneManager.GetActiveScene().buildIndex;
        if (ActiveCount > 1)
            UnloadScene();
        else
            SceneManager.LoadScene(Path_Scene + scene);
    }
    public void LoadScene(int scene)
    {
        previousScene = SceneManager.GetActiveScene().buildIndex;
        if (ActiveCount > 1)
            UnloadScene();
        else
            SceneManager.LoadScene(scene);
    }
    public void LoadScene()
    {
        previousScene = SceneManager.GetActiveScene().buildIndex;
        if (ActiveCount > 1)
            UnloadScene();
        else
            SceneManager.LoadScene(Path_Scene + sceneName.ToString());
    }

    /* Scene Additve */
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
}
