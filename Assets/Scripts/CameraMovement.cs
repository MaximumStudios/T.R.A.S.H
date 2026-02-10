using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Camera cam;
    private Collider2D Boundary;
    private BoxCollider2D camBounds;
    private Vector2 WindowSize;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam=GetComponent<Camera>();
        camBounds = new BoxCollider2D();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CamSize()
    {
        float size=cam.orthographicSize;
        WindowSize= new Vector2(size*cam.aspect,size);
        camBounds.size = WindowSize;
    }
}
