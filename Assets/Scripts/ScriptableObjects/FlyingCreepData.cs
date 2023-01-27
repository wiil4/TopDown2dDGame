using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFlyingCreepData", menuName = "Scriptable Objects/Data/FlyingCreepData")]
public class FlyingCreepData : ScriptableObject
{
    [SerializeField] private float _shootForce;
    [SerializeField] private int _howManyAmo;
    [SerializeField] private float _timeBetweenShoot;
    [SerializeField] private GameObject _whatToShoot;

    public float ShootForce { get { return _shootForce; } }
    public int HowManyAmo { get { return _howManyAmo; } }
    public float TimeBetweenShoot { get { return _timeBetweenShoot; } }
    public GameObject WhatToShoot { get { return _whatToShoot; } }
}
