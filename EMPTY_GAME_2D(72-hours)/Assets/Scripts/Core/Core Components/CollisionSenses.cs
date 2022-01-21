using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CollisionSenses : CoreComponents
{
    public Transform CheckPosition { get => _checkPosition; set => _checkPosition = value; }
    public Vector2 OverlapSize { get => _overlapSize; set => _overlapSize = value; }
    public Vector2 Offset1 { get => _offset1; set => _offset1 = value; }
    public Vector2 Offset2 { get => _offset2; set => _offset2 = value; }
    public Vector2 Offset3 { get => _offset3; set => _offset3 = value; }
    public Vector2 Offset4 { get => _offset4; set => _offset4 = value; }
    public LayerMask MonsterLayer { get => _monsterLayer; set => _monsterLayer = value; }
    public float CheckDistance { get => _checkDistance; set => _checkDistance = value; }

    [SerializeField] private Transform _checkPosition;
    [SerializeField] private Vector2 _overlapSize;
    [SerializeField] private Vector2 _offset1, _offset2, _offset3, _offset4;
    [SerializeField] private float _checkDistance = 50f;
    private int _trueOffsetValue;
    [SerializeField] private LayerMask _monsterLayer;
    [SerializeField] private LayerMask _playerLayer;
    private ContactFilter2D _contactFilter;

    public void LogicUpdate()
    {
        
    }


    public bool IsPlayerLeavingLookingZone(Vector2 p_direction)
    {
        return Physics2D.Raycast(_checkPosition.position, p_direction, 2.45f, _playerLayer);
    }

    public Vector2 trueOffset()
    {
        if(_trueOffsetValue == 1)
        {
            return _offset1; //Right
        }else if(_trueOffsetValue == 2)
        {
            return _offset2; //Left
        }else if(_trueOffsetValue == 3)
        {
            return _offset3; //Up
        }
        else
        {
            return _offset4; //Down
        }
    }

    public void SetTrueOffsetValue(int index) => _trueOffsetValue = index;


    #region Monster Region

    public bool RightRaycast
    {
        get => Physics2D.Raycast(_checkPosition.position, Vector2.right, _checkDistance, _playerLayer);
    }

    public bool LeftRaycast
    {
        get => Physics2D.Raycast(_checkPosition.position, Vector2.left, _checkDistance, _playerLayer);
    }

    public bool UpRaycast
    {
        get => Physics2D.Raycast(_checkPosition.position, Vector2.up, _checkDistance, _playerLayer);
    }

    public bool DownRaycast
    {
        get => Physics2D.Raycast(_checkPosition.position, Vector2.down, _checkDistance, _playerLayer);
    }

    #endregion
}
