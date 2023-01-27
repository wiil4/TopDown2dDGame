using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : GlobalCharacterController
{
    protected enum EnemyState
    {
        Chase, Attack, Die
    };

    protected float playerDamage { get; set; }
    protected float minAttackDistance { get; set; }
    protected float receivedDamage { get; set; }

    protected GameObject _player;

    protected EnemyState state { get; set; }
    protected Vector2 _moveTowards { get; set; }
    private float _pushForce;

    protected float _distance { get; set; }

    [SerializeField] private EnemyData enData;

    protected EnemyData EnData {get{ return enData; }}
    protected override void Awake()
    {
        base.Awake();
        maxlife = enData.MaxLife;
        receivedDamage = enData.ReceivedDamage;
        playerDamage = enData.PlayerDamage;
        speedMovement = enData.SpeedMovement;
        minAttackDistance = enData.MinAttackDistance;
        
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        state = EnemyState.Chase;
        _pushForce = enData.PushForce;
    }

    // Update is called once per frame
    void Update()
    {
        CharacterDirectionCheck(Mathf.Sign(-CalculateDirection().x));
        switch (state)
        {
            case EnemyState.Chase:
                _distance = Vector2.Distance(this.transform.position, _player.transform.position);

                if (_distance > minAttackDistance)
                {
                    _moveTowards = CalculateDirection();
                }
                else
                {
                    state = EnemyState.Attack;
                }
                break;

            case EnemyState.Attack:
                Attack();
                break;
            default:
                break;
        }

    }

    protected Vector3 CalculateDirection()
    {
        return transform.position - _player.transform.position;
    }

    private void FixedUpdate()
    {
        _rb.velocity = -_moveTowards.normalized * speedMovement;
    }
    
    protected virtual void Attack()
    {
        Debug.Log("Attack");
    }

    protected override void OnLifeZero()
    {
        Debug.Log(gameObject.name+" Dead");
        Destroy(gameObject);
    }

    protected void Push()
    {
        speedMovement = 0;
        _rb.AddForce(CalculateDirection() * _pushForce,ForceMode2D.Force);
        speedMovement = enData.SpeedMovement;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.CompareTag("Weapon"))
        {
            GetDamage(receivedDamage);
            Push();
        }        
    }
}
