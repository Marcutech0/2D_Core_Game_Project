using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrapBehavior : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) ;
        {
            Animation.SetBool("isActive", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Animation.SetBool("isActive", false);
    }
}
