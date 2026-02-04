using Unity.Mathematics.Geometry;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : Floatables
{
    private Collider2D coll;
    private Vector2 movement;
    [SerializeField] private float baseAccel=2f;
    [SerializeField] private float baseMaxSpeed=50f;
    [SerializeField] private float ConnectDistance=2f;
    private float OnConnectionDistance=2;
    private float CreationDistance=2;

    [SerializeField] private GameObject Bag;
    private GameObject ActiveBag;
    private BagBehaviour ActiveBagBehaviour;
    private Collider2D ActiveBagCollider;
    private SpringJoint2D  spring;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
        coll = GetComponent<Collider2D>();
        spring = GetComponent<SpringJoint2D>();
        spring.connectedBody = null;
        spring.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (AtmosDensity > 0 && rb.linearVelocity.magnitude < baseMaxSpeed)
        {
            rb.AddForce(movement * baseAccel);
        }
        Changes();
    }

    private void OnMove(InputValue move)
    {
        movement = move.Get<Vector2>();
    }

    private void OnCreateDetach(InputValue detach)
    {
        CreateDetach();
    }

    private void Changes()
    {
        if (ActiveBag)
        {
            spring.distance = ConnectDistance;
        }
    }

    private void CreateDetach()
    {
        if (spring.enabled)
        {
            spring.connectedBody = null;
            spring.enabled = false;
            ActiveBagBehaviour.Connect(false);
        }
        else if(ActiveBag != null&&Physics2D.Distance(coll, ActiveBagCollider).distance<ConnectDistance)
        {
            ActiveBagBehaviour.Connect(true);
            OnConnectionDistance = (transform.position-ActiveBag.transform.position).magnitude;
            spring.connectedBody = ActiveBag.GetComponent<Rigidbody2D>();
            spring.enabled = true;
        }
        else
        {
            if (ActiveBagBehaviour)
            {
                ActiveBagBehaviour.Die();
            }

            ActiveBag=Instantiate(Bag, transform.position, Quaternion.identity);
            ActiveBagBehaviour=ActiveBag.GetComponent<BagBehaviour>();
            ActiveBagBehaviour.Connect(true);
            OnConnectionDistance = CreationDistance;
            ActiveBagCollider = ActiveBag.GetComponent<Collider2D>();
            spring.connectedBody = ActiveBag.GetComponent<Rigidbody2D>();
            spring.enabled = true;
        }
    }
}
