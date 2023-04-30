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
        
    }

    public SceneName sceneName;
    [SerializeField]
    private string Path_Scene = "Game/Scenes/";
    
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
}
