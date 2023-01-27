using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCreep : EnemyController
{
    [SerializeField] private FlyingCreepData _flyingCreepData;
    private GameObject _whatToShoot;
    private float _shootForce;
    private float _timebetweenShoot;
    private float _timer;
    private int _countAmo;
    private int _howManyAmo;

    protected override void Awake()
    {
        base.Awake();
        _whatToShoot = _flyingCreepData.WhatToShoot;
        _shootForce = _flyingCreepData.ShootForce;
        _timebetweenShoot = _flyingCreepData.TimeBetweenShoot;
        _howManyAmo = _flyingCreepData.HowManyAmo;
        _timer = 0;
    }
    protected override void Attack()
    {
        //Check attack distance and fix attack
        //base.Attack();
        speedMovement = 0;
        if(_countAmo < _howManyAmo)
        {
            _timer += Time.deltaTime;
            if (_timer > _timebetweenShoot)
            {
                Shoot();
                _countAmo++;
                _timer = 0;                
            }
        }
        else
        {
            state = EnemyState.Chase;
            speedMovement = EnData.SpeedMovement;
            _countAmo = 0;
        }        
    }

    private void Shoot()
    {
        GameObject ball = Instantiate(_whatToShoot, transform.position, Quaternion.identity);
        ball.GetComponent<Rigidbody2D>().AddForce(-CalculateDirection().normalized * _shootForce, ForceMode2D.Force);
        ball.GetComponent<CreepBall>().PlayerDamage = playerDamage;
    }
}
