using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Date/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Movement Parameter")]
    public float MovementSpeed = 7.0f;
    public float MovementSpeedBack = 4.0f;
    public float TimeBeforeMoving = 1.0f;

    [Header("Collision Parameter")]
    public Vector2 BoxColliderSizeRight = new Vector2(5, 3);
    public Vector2 BoxColliderSizeUp = new Vector2(3, 5);

    public Vector2 BoxColliderOffsetRight = new Vector2(3, 0);
    public Vector2 BoxColliderOffsetUp = new Vector2(0, 3);


}
