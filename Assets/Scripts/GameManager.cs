using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool IsAtEnd = false;
    private SceneLoader sceneLoader;
    [SerializeField] private GameObject Door1;
    [SerializeField] private GameObject Door2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Door1)
        {
            Door1.SetActive(true);
        }
        else
        {
            Debug.Log("You forgot to set Door1");
        }
        if (Door2)
        {
            Door2.SetActive(true);
        }
        else
        {
            Debug.Log("You forgot to set Door2");
        }
        sceneLoader = gameObject.GetComponent<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsThereTrash())
        {
            Door1.SetActive(true);
        }
        else
        {
            Door1.SetActive(false);
        }
        if (IsAtEnd)
        {
            if (!IsThereTrash())
            {
                Debug.Log("Congrats you picked up trash");
                Door2.SetActive(false);
                if (sceneLoader)
                {
                    sceneLoader.LoadAScene();
                }
            }
            else
            {
                Debug.Log("You didn't pick up the trash. Also how did you get here?");
            }
            IsAtEnd = false;
        }
    }
    private bool IsThereTrash()
    {
        return FindAnyObjectByType<Trash>(FindObjectsInactive.Include);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement Player);
        if (Player)
        {
            IsAtEnd = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement Player);
        if (Player)
        {
            IsAtEnd = false;
        }
    }
}
