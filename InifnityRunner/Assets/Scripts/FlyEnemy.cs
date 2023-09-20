using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rigi;
    public int speed;

    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void FixedUpdate()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Move()
    {
        rigi.velocity = Vector2.left * speed;
    }
}
