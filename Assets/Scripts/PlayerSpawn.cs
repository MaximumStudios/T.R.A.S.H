using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField]private GameObject playerPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!playerPrefab)
        {
            Debug.LogError("No player prefab assigned");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!FindAnyObjectByType<PlayerMovement>())
        {
            Instantiate(playerPrefab, transform.position, Quaternion.identity);
        }
    }
}
