using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]

public class PlayerData : ScriptableObject
{
    [Header("Main Variables")]
    public Vector2 StartingDirection = new Vector2(0, -1);

    [Header("Move State")]
    public float movementVelocity = 7f;
    public float movementDelayTime = 20f;
    public float sleepTime = 10f;
    public float attackVelocity = 3f;

    [Header("Dash State")]
    public float dashVelocity = 85f;
    public float dashDuration = .03f;
    public float dashCooldown = 1f;
    public int dashAmount = 2;
}


