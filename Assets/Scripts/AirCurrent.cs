using UnityEngine;

public class AirCurrent : MonoBehaviour
{
    [SerializeField] private Vector2 force=Vector2.right*10f;
    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.gameObject.TryGetComponent<Floatables>(out Floatables floaties);
        if (floaties)
        {
            floaties.rb.AddForce(force);
        }
    }
}
