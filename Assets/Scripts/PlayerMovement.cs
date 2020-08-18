using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// enum for different states of player
public enum PlayerState
{
    walk,
    attack,
    interact
}
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

    // Refernce to the enum
    public PlayerState currentState;

    #endregion

    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;

        // Complete refernce to animator
        animator = GetComponent<Animator>();

        // Complete reference to players rigidbody.
        myRigidbody = GetComponent<Rigidbody2D>();

        // give animtor intial 
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        // Every frame reset how much the player has moved.
        change = Vector3.zero;

        // Access if any of the input buttons are pressed
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }
       else if (currentState == PlayerState.walk)
        {
            UpdateAnimationAndMove();
        }
    }

    // coroutine method that runs in parralel to the main process and allows you to build in specific delays.
    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null; // wait 1 frame
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
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
        // Normalise the position
        change.Normalize();
        // Move player each frame
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    #endregion
}
