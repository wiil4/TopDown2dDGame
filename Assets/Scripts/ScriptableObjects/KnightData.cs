using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewPlayerData", menuName = "Scriptable Objects/Character/New Player Data")]
public class KnightData : ScriptableObject
{
    [SerializeField]private float _maxLife;
    [SerializeField]private float _speedMovement;
    [SerializeField]private float _cooldownTimer;
public float Maxlife { get { return _maxLife; } }
    public float SpeedMovement { get { return _speedMovement; } }
    public float CooldownTimer { get { return _cooldownTimer; } }
}
