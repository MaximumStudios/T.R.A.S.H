using UnityEngine;

public class Incinerator : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.gameObject.TryGetComponent<Floatables>(out Floatables floaties);
        if (floaties)
        {
            floaties.Die();
        }
    }
}
