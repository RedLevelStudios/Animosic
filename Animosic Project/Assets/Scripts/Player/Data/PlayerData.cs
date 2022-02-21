using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]

public class PlayerData : ScriptableObject
{
    [Header("Main Variables")]
    public Vector2 StartingDirection = new Vector2(0, -1);

    [Header("Move State")]
    public float movementVelocity = 9;
    public float movementDelayTime = 20;
    public float sleepTime = 20;
    public float attackVelocity = 3;

    [Header("Dash State")]
    public float dashVelocity = 40;
    public float dashDuration = .03f;
    public float dashCooldown = 1;
    public int dashAmount = 2;

    [Header("Attack State")]
    public float attackDuration = .4f;
}


