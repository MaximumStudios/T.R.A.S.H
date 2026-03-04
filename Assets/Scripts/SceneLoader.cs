using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int SceneIndex = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneIndex);
    }
    public void LoadAScene()
    {
        if (!SceneManager.GetSceneByBuildIndex(SceneIndex).isLoaded)
        {
            SceneManager.LoadSceneAsync(SceneIndex, LoadSceneMode.Single);
        }
    }
}
