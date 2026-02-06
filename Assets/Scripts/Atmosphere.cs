using Unity.VisualScripting;
using UnityEngine;

public class Atmosphere : MonoBehaviour
{
    public float Atmos = 0.5f;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.gameObject.TryGetComponent<Floatables>(out Floatables floaties);
        if (floaties)
        {
            floaties.AtmosDensity=Atmos;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.TryGetComponent<Floatables>(out Floatables floaties);
        if (floaties)
        {
            floaties.AtmosDensity=0;
        }
        
    }
}
