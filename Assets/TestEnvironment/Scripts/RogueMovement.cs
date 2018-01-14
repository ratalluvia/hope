using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueMovement : MonoBehaviour {
    Animator anim;

    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixdedUpdate () {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", move);
	}
}