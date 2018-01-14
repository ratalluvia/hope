using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueController : MonoBehaviour {

    [SerializeField] private float maxSpeed = 10f;
    bool facingRight = true;
    Animator anim;
    Rigidbody body;

    void Start () {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
    }

    void FixedUpdate () {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        anim.SetFloat("Speed", Mathf.Max(Mathf.Abs(moveH), Mathf.Abs(moveV)));

        body.velocity = new Vector3(moveH * maxSpeed, 0, moveV * maxSpeed);

        if (moveH > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveH < 0 && facingRight)
        {
            Flip();
        }
	}

    void Flip ()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
