using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float upForce;
    private float yInput, xInput;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        yInput = Input.GetAxisRaw("Vertical");
        xInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(0f, upForce * yInput));
        rb.AddTorque(xInput);
    }
}
