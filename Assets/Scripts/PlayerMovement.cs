using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private  Rigidbody2D playerBody;
    public float moveSpeed=1f;
    private Vector2 movement;
    void Start()
    {
        playerBody=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x=Input.GetAxisRaw("Horizontal");
        movement.y=Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        playerBody.velocity= moveSpeed*movement*Time.deltaTime;
    }
}
