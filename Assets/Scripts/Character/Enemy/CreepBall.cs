using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepBall : MonoBehaviour
{
    private float _playerDamage;
    [SerializeField] private float _durationTime;
    public float PlayerDamage { set { _playerDamage = value; } }

    private void Start()
    {
        Destroy(gameObject, _durationTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            collision.GetComponent<KnightController>().Damage = _playerDamage;
        }
    }
}
