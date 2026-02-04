using System.Collections;
using UnityEngine;

public class BagBehaviour : Floatables
{
    private float DeathTime = 2f;
    private float FloatTime = 10f;
    public bool Connected;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
        Connected = true;
    }


    public void Die()
    {
        StartCoroutine(Death(DeathTime));
    }

    public void Connect(bool connected)
    {
        Connected = connected;
        if (!Connected)
        {
            if (AtmosDensity < 1)
            {
                StartCoroutine(Float(FloatTime + 350 * Mathf.Pow(AtmosDensity, 2)));
            }
        }
        else
        {
            StopCoroutine("Float");
        }
    }

    IEnumerator Death(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
    IEnumerator Float(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
