
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Player speed
    public float moveSpeed;

    //Rigid Body access
    public Rigidbody2D rigidBody;

    //Player movement
    private Vector2 movementInput;

    //player animations
    public Animator anim;

    //coin collecting
    public int CoinCount;

    // Start is called before the first frame update
    void Start()
    {
        //para sa player to pre kimi lang
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // PLAY/LAUNCH
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) //move up
        //{
        //    anim.enabled = true;//
        //    anim.SetTrigger("moveup");
        //}
        //if (Input.GetKeyUp(KeyCode.W))
        //{
        //    anim.SetTrigger("Upause");
        //}
        //if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))//move down
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("movedown");
        //}
        //if (Input.GetKeyUp(KeyCode.S))
        //{
        //    anim.SetTrigger("Dpause");
        //}
        //if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))//move to the right
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("moveright");
        //}
        //if (Input.GetKeyUp(KeyCode.D))
        //{
        //    anim.SetTrigger("Rpause");
        //}
        //if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))//move to the right
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("moveleft");
        //}
        //if (Input.GetKeyUp(KeyCode.A))
        //{
        //    anim.SetTrigger("Lpause");
        //}
        //if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        //{
        //    anim.enabled = false;
        //}

        anim.SetFloat("Horizontal", movementInput.x);
        anim.SetFloat("Vertical", movementInput.y);
        anim.SetFloat("Speed", movementInput.sqrMagnitude);
        

    }
    //Fixed for physx kimi lang pre
    private void FixedUpdate()
    {
        //player  movement
        rigidBody.velocity = movementInput * moveSpeed;
    }

    //input keybinds
    private void OnMove(InputValue inputValue)
    {
        // When A is pressed
        movementInput = inputValue.Get<Vector2>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("COIN_PREFAB"))
        {
            Destroy(collision.gameObject);
            CoinCount++;
        }
    }
}