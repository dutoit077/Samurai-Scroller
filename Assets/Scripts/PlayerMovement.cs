using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public PlayerState currentState;
    public float speed;
    public float walkSpeed = 15;


    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;


    public enum PlayerState
    {
        walk,
        attackL,
        attackR,
        interact
    }

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");


        if (currentState == PlayerState.walk)
        {
            UpdateAnimationAndMove();
        }

    }


    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();

        }



    }
    void MoveCharacter()
    {
        myRigidbody.MovePosition(
           transform.position + change.normalized * speed * Time.deltaTime
            );
    }
}
