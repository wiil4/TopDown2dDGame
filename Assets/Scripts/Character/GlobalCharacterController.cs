using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Date:Nov16
/// Comments: Archero Like Game, add range detection to enemies to follow player and attack player(flying creep behaviour) and bow to knight that
/// aims and shoots forward mouse position or shoots automatically to most near enemy
/// </summary>
public class GlobalCharacterController : MonoBehaviour
{
    protected float maxlife { get; set; }
    
    protected float speedMovement { get; set; }

    protected Animator _animator;
    protected Rigidbody2D _rb;


    private int direction = 1;

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    protected virtual void OnLifeZero()
    {
        Debug.Log("life0");
    }
    
    protected void GetDamage(float damage)
    {
        maxlife -= damage;
        Debug.Log("I " + this.gameObject.name + ", with life " + maxlife);
        if(maxlife<=0)
        {
            OnLifeZero();
        }
    }

    protected void CharacterDirectionCheck(float xReference)
    {
        if (xReference * direction < 0.0f)
        {
            direction *= -1;
            int rotation = (direction < 0.0f)
                ? 180
                : 0;
            transform.eulerAngles = new Vector3(0, rotation, 0);
        }
    }
}
