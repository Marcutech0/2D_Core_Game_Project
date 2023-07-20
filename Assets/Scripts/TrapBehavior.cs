using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrapBehavior : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update

    //trap damage to player
    public int TrapDamage;

    //new object calling the player script
    public PlayerMovement player;

    //for the animation fix (player damage)
    public bool isPlayerOnTop;
    public bool PlayerisDead;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayerOnTop = true;
        if (collision.gameObject.CompareTag("Player")) ;
        {
            anim.SetBool("isActive", true);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerOnTop = false;
        anim.SetBool("isActive", false);
    }

    public void playerdamage()
    {
        if (isPlayerOnTop)
        {
            player.HealthPoints = Mathf.Max(player.HealthPoints - TrapDamage, 0);
        }
    }

}