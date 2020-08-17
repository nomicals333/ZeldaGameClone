using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    // How fast player is moving
    public float speed;

    // Reference to PLayers rigid body
    private Rigidbody2D myRigidbody;

    // Reference to Vector3 - how much the players position will change
    private Vector3 change;

    // Reference to the animator componant
    private Animator animator;

    #endregion

    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        // Complete refernce to animator
        animator = GetComponent<Animator>();

        // Complete reference to players rigidbody.
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Every frame reset how much the player has moved.
        change = Vector3.zero;

        // Access if any of the input buttons are pressed
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        UpdateAnimationAndMove();
    }

    void UpdateAnimationAndMove()
    {
        // check to see if player is actually moving
        if (change != Vector3.zero)
        {
            MoveCharacter();
            // set animator on x & y axis equal to change x & y
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);

            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        // Move player each frame
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    #endregion
}
