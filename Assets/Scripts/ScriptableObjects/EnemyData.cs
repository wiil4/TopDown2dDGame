using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Scriptable Objects/Character/New Enemy Data")]
public class EnemyData : ScriptableObject
{
    [SerializeField]private float _maxlife;
    [SerializeField] private float _receivedDamage;
    [SerializeField] private float _playerDamage;
    [SerializeField] private float _speedMovement;
    [SerializeField] private float _minAttackDistance;
    [SerializeField] private int _pushForce;

    public float MaxLife { get { return _maxlife; } }
    public float ReceivedDamage { get { return _receivedDamage; } }
    public float PlayerDamage { get { return _playerDamage; } }
    public float SpeedMovement { get { return _speedMovement; } }
    public float MinAttackDistance { get { return _minAttackDistance; } }
    public int PushForce { get { return _pushForce; } }
}
