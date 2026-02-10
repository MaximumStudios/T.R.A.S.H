using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    [SerializeField] private KnotSizeInfluence cam;
    [SerializeField] private float knot;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.TryGetComponent<PlayerMovement>(out PlayerMovement player);
        if (player)
        {
            cam.MoveTo(knot);
        }
    }
}
