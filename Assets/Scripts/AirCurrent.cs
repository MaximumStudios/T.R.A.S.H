using UnityEngine;

public class AirCurrent : MonoBehaviour
{
    [SerializeField] private float force=10f;
    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.gameObject.TryGetComponent<Floatables>(out Floatables floaties);
        if (floaties)
        {
            floaties.rb.AddForce(-transform.right*force);
        }
    }
}
