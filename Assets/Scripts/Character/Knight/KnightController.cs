using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : GlobalCharacterController
{
    private enum PlayerState { Idle,Walk,Attack, Die}
    private Vector2 _input;
    private bool _canMove;
    private float _coolDownTimer;
    private float _nextFire;
    [SerializeField] private KnightData knightData;
    private PlayerState _playerState;
    private float _moveMargin = 0;

    public float Damage 
    {
        get { return 0; }
        set 
        {
            GetDamage(value);
        }
    }

    protected override void Awake()
    {
        base.Awake();
        maxlife = knightData.Maxlife;
        speedMovement = knightData.SpeedMovement;
        _coolDownTimer = knightData.CooldownTimer;
        _canMove = true;
    }

    private void Start()
    {
        _playerState = PlayerState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        switch (_playerState)
        {
            case PlayerState.Idle:
                _animator.SetFloat("Movement", _input.magnitude);
                _playerState = _input.magnitude != _moveMargin ? PlayerState.Walk : PlayerState.Idle;
                break;
            case PlayerState.Walk:                
                CharacterDirectionCheck(_input.x);
                _animator.SetFloat("Movement", _input.magnitude);
                _playerState = _input.magnitude == _moveMargin ? PlayerState.Idle : PlayerState.Walk;
                break;
            case PlayerState.Attack:
                CharacterDirectionCheck(_input.x);
                break;
            case PlayerState.Die:
                break;
            default:
                break;
        }
            
        /*if(_canMove)
        {
            
            
            if (Input.GetMouseButtonDown(0) && Time.time > _nextFire)
            {
                _animator.SetTrigger("Attack");                
                _nextFire = Time.time + _coolDownTimer;                
                //StartAttackCoolDown();
            }
        }
        else
        {
            _input = Vector2.zero;
        }*/
        
    }

    void FixedUpdate()
    {
        _rb.velocity = _input.normalized * speedMovement;
    }
    
    /*private void StartAttackCoolDown()
    {
        StartCoroutine(CoolDown());
    }

    private IEnumerator CoolDown()
    {
        speedMovement = 0;
        yield return new WaitForSeconds(_coolDownTimer);
        speedMovement = knightData.SpeedMovement;
    }*/
}    