using UnityEngine;

public class Trash : Floatables
{
    public override void Start()
    {
        base.Start();
        rb.angularVelocity = Random.Range(-90, 90);
        rb.linearVelocity = new Vector2(Random.Range(-1, 1),Random.Range(-1, 1));
    }
}
