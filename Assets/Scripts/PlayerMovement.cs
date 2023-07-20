using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // displaying coin count
    public TextMeshProUGUI coinCountText;

    // displaying player health points
    public TextMeshProUGUI healthPointsText;

    // Player speed
    public float moveSpeed;

    // Rigid Body access
    public Rigidbody2D rigidBody;

    // Player movement
    private Vector2 movementInput;

    // Player animations
    public Animator anim;

    // Coin collecting
    public int CoinCount;

    // Private field for HealthPoints
    private int healthPoints = 100;

    // Property for HealthPoints
    public int HealthPoints
    {
        get { return healthPoints; }
        set
        {
            // Clamp the value between 0 and 100
            healthPoints = Mathf.Clamp(value, 0, 100);
            // Update the UI text
            UpdateHealthPointsText();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get references to the Rigidbody2D component and Animator component
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        coinCountText = GameObject.Find("CoinCountText").GetComponent<TextMeshProUGUI>();
        healthPointsText = GameObject.Find("HealthPointsText").GetComponent<TextMeshProUGUI>();

        // Initialize the UI text with the starting values
        UpdateCoinCountText();
        UpdateHealthPointsText();
    }

    // PLAY/LAUNCH
    void Update()
    {
        anim.SetFloat("Horizontal", movementInput.x);
        anim.SetFloat("Vertical", movementInput.y);
        anim.SetFloat("Speed", movementInput.sqrMagnitude);
    }

    // Fixed for physics update
    private void FixedUpdate()
    {
        // Player movement
        rigidBody.velocity = movementInput * moveSpeed;
    }

    // Input keybinds
    private void OnMove(InputValue inputValue)
    {
        // Get the movement input
        movementInput = inputValue.Get<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Speed"))
        {
            // Move the collided object off-screen
            collision.transform.position = new Vector2(999, 999);
        }
        else if (collision.CompareTag("COIN_PREFAB"))
        {
            CoinCount++;
            Destroy(collision.gameObject);
            UpdateCoinCountText();

            if (CoinCount == 36) 
            {
                StartCoroutine(Win());
            }
        }
        else if (collision.CompareTag("Health"))
        {
            Destroy(collision.gameObject);
            HealthPoints += 10;
        }

        }

        // Update the Coin Count UI text
        private void UpdateCoinCountText()
        {
            coinCountText.text = "Coins Collected: " + "[" + CoinCount.ToString() + "/36]";
        }

        // Update the Player Health Points UI text
        private void UpdateHealthPointsText()
        {
        healthPointsText.text = "HP: " + HealthPoints.ToString();
        if (HealthPoints < 1)
        {
            StartCoroutine(DeathCoroutine());
        }
        }   

        private IEnumerator DeathCoroutine()
        {
            rigidBody.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("death");
            yield return new WaitForSeconds(3.5f); 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        private IEnumerator Win()
        {
            rigidBody.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("Win");
            yield return new WaitForSeconds(3.5f);
            SceneManager.LoadScene("WinScreen");
        }
}
