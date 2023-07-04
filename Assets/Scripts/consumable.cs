using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consumable : MonoBehaviour
{
    public bool Health, Speed;
    public int HealthRegen, SpeedBoost, Duration;
    private float basemovespeed;
    public PlayerMovement player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Speed)
        {
            player.moveSpeed += SpeedBoost;
            StartCoroutine(BackToBaseSpeed());
        }
        if(Health)
        {
            player.HealthPoints += HealthRegen;
        }
    }
    IEnumerator BackToBaseSpeed()
    {
        yield return new WaitForSeconds(Duration);
        player.moveSpeed = basemovespeed;

    }

    // Start is called before the first frame update
    void Start()
    {
        basemovespeed = player.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
