using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour, IInteractable
{
    [SerializeField] private string sceneName;
    public void Interact()
    {
        var collider = GetComponent<Collider>();
        if (!collider.isTrigger)
        {
            LoadScene();
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Debug.Log("Scene loaded: " + arg0.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            LoadScene();
        }
    }
}
