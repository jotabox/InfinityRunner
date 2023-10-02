using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigi;
    private BoxCollider2D boxCollider;
    public int velocidadePlayer = 5;
    public int jumpForce;
    public int coins;

    [SerializeField] private LayerMask layerGround;

    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void FixedUpdate()
    {
        Move();
    }
    // Update is called once per frame
    void Update()
    {
        Jump();
    }


    public void Move()
    {
        rigi.velocity = new Vector2(velocidadePlayer, rigi.velocity.y);
    }

    public void Jump()
    { 
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
             rigi.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coins"))
        {
            coins++;
            Destroy(collision.gameObject);
        }
        
    }

    public bool IsGrounded()
    {
        // box retornando a posição que se encontra , o tamanho , angulo , altura é a layer
        RaycastHit2D ground = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down,0.1f, layerGround);

        return ground.collider != null;
    }
}
