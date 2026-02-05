using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagBehaviour : Floatables
{
    private float DeathTime = 2f;
    private float FloatTime = 10f;
    [SerializeField] private int MaxHold = 5;
    private int hold = 0;
    public bool Connected;
    private List<GameObject> Trashes;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
        Connected = true;
        Trashes = new List<GameObject>();
    }

    public override void Update()
    {
        Collect();
        transform.localScale = new Vector2(2+hold*0.1f, 2+0.1f*hold);
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

    private void Collect()
    {
        Collider2D[] Colls=Physics2D.OverlapCircleAll(transform.position, 2.02f + hold * 0.1f);
        foreach (Collider2D Coll in Colls)
        {
            if (Coll.transform.GetComponent<Trash>()&&hold<MaxHold)
            {
                GameObject trash = Coll.gameObject;
                Trashes.Add(trash);
                trash.SetActive(false);
                hold++;
            }
        }
    }

    private void Expel()
    {
        foreach (GameObject Trash in Trashes)
        {
            Trash.SetActive(true);
            Trash.transform.position = transform.position;
            Trash.GetComponent<Trash>().rb.linearVelocity = new Vector2(rb.linearVelocityX+Random.Range(-1, 1),rb.linearVelocityY+Random.Range(-1, 1));
            Trash.GetComponent<Trash>().rb.angularVelocity = Random.Range(-90, 90);
        }
    }

    IEnumerator Death(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Expel();
        Destroy(gameObject);
    }
    IEnumerator Float(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Expel();
        Destroy(gameObject);
    }
}
