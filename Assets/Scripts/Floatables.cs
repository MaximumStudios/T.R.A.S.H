using UnityEngine;

public class Floatables : MonoBehaviour
{
    public Rigidbody2D rb;
    public float AtmosDensity=0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        rb.linearDamping = AtmosDensity;
    }
}
