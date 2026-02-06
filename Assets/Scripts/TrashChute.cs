using UnityEngine;

public class TrashChute : MonoBehaviour
{
    private GameObject bag;
    private SpringJoint2D  spring;
    [SerializeField] private float grabRange=0.2f;
    [SerializeField] private float force=10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spring = GetComponent<SpringJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Collect();
    }

    private void Collect()
    {
        if (!bag)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.right, grabRange);
            foreach (Collider2D col in colliders)
            {
                col.gameObject.TryGetComponent<BagBehaviour>(out BagBehaviour bag);
                if (bag)
                {
                    spring.connectedBody = bag.rb;
                    bag.Die();
                    this.bag=bag.gameObject;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.gameObject.TryGetComponent<Trash>(out Trash trash);
        if (trash)
        {
            trash.rb.AddForce(-transform.right*force);
        }
    }
}
