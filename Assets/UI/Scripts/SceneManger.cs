using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManger : MonoBehaviour
{
    public string[] sceneName;

    public void OnStartLoad()
    {
        SceneManager.LoadScene(sceneName[0], LoadSceneMode.Single);
        Debug.Log("Button Pressed");
    }

    public void OnCustomScene()
    {
        SceneManager.LoadScene(sceneName[1], LoadSceneMode.Single);
    }

    public void OnGameWonLoad()
    {
        SceneManager.LoadScene(sceneName[2], LoadSceneMode.Single);
    }

    public void OnGameLostLoad()
    {
        SceneManager.LoadScene(sceneName[3], LoadSceneMode.Single);
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level");
    }
}
