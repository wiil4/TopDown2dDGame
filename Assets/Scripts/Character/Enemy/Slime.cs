using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : EnemyController
{ 
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if(collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<KnightController>().Damage = playerDamage;
        }
    }
}
