using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private  Rigidbody2D playerBody;
    public float moveSpeed=1f;
    private Vector2 movement;


    //DASH
    
    private bool canDash=true;
    private bool isDashing;
    public float dashingPower=1f;
    private float dashingTime=0.2f;
    private float dashingCoolDown=1f;
   

    [SerializeField] private TrailRenderer tr;
    void Start()
    {
        playerBody=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x=Input.GetAxisRaw("Horizontal");
        movement.y=Input.GetAxisRaw("Vertical");

        if(isDashing){ return;}

        if(Input.GetKeyDown(KeyCode.LeftShift)&& canDash)
        {
            StartCoroutine(Dash());
        }
    }

    void FixedUpdate()
    {
        playerBody.velocity= moveSpeed*movement*Time.deltaTime;
    }


    private IEnumerator Dash()
    {
        canDash=false;
        isDashing=true;
        playerBody.velocity=new Vector2(transform.localScale.x*dashingPower,0f);
        tr.emitting=true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting=false;
        isDashing=false;
        yield return new WaitForSeconds(dashingCoolDown);
        canDash=true;
         
    }
}
