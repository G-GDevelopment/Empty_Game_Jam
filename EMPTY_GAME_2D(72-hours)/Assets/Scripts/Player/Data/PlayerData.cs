using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Date/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Movement Parameter")]
    public float MovementSpeed = 7.0f;
    public float MovementSpeedBack = 4.0f;
}
