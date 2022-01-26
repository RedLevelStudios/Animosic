using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]

public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 7f;
    public float movementDelayTime = 20f;

    [Header("Dash State")]
    public float dashVelocity = 15f;
    public float dashDuration = .5f;
}


