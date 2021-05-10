using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string startSceneName;
    [Space(10)]
    [SerializeField] private Transform optionsTab;
    
    public void StartGame()
    {
        SceneManager.LoadScene(startSceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
