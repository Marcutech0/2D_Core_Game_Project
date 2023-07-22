using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehavior : MonoBehaviour
{
    public Animator anim;

    // Trap damage to player
    public int TrapDamage;

    // Reference to the player script
    public PlayerMovement player;

    // Check if player is on top of the trap
    public bool isPlayerOnTop;

    // Check if the trap has already been triggered
    private bool isTriggered = false;

    // Duration of the trap animation
    public float trapAnimationDuration = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnTop = true;

            if (!isTriggered)
            {
                isTriggered = true;
                StartCoroutine(TriggerTrap());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnTop = false;
        }
    }

    private IEnumerator TriggerTrap()
    {
        anim.SetBool("isActive", true);

        yield return new WaitForSeconds(trapAnimationDuration);

        anim.SetBool("isActive", false);
        isTriggered = false;

        // Damage the player when the trap animation finishes
        if (isPlayerOnTop)
        {
            player.HealthPoints = Mathf.Max(player.HealthPoints - TrapDamage, 0);
        }
    }
}