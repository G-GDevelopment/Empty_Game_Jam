using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement : CoreComponents
{
    public bool IsWalkingBackwards { get => _isWalkingBackwards; set => _isWalkingBackwards = value; }
    public Rigidbody2D Rigidbody;

    [SerializeField] private Tilemap _groundTiles;
    [SerializeField] private Tilemap _collisionTiles;
    [SerializeField] private Tilemap _trapsTiles;
    [SerializeField] private Tilemap _spikesTiles;
    [SerializeField] private Tilemap _exit;
    [SerializeField] Transform _movePoint;
    public AudioManager audioManager { get; private set; }

    private bool _isMoving;
    private bool _isWalkingBackwards;
    public bool IsMoving { get => _isMoving; set => _isMoving = value; }

    protected override void Awake()
    {
        base.Awake();

        Rigidbody = GetComponentInParent<Rigidbody2D>();
        audioManager = FindObjectOfType<AudioManager>();


        _movePoint.parent = null;

    }

    public void LogicUpdate()
    {
        
    }


    public void SetMovement(Vector2 p_direction, int p_inputX, int p_inputY, float p_movementSpeed)
    {
        _isMoving = true;

        Rigidbody.transform.position = Vector3.MoveTowards(Rigidbody.transform.position, _movePoint.position, p_movementSpeed * Time.deltaTime);


        if (CanMove(p_direction))
        {
            if (Vector3.Distance(Rigidbody.transform.position, _movePoint.position) <= 0.05f)
            {
                if(p_inputX != 0)
                {
                    _movePoint.position += new Vector3(p_inputX, 0, 0);
                }

                if(p_inputY != 0)
                {
                    _movePoint.position += new Vector3(0, p_inputY, 0);
                }

            }
        }

        if(Rigidbody.transform.position == _movePoint.position)
        {
            _isMoving = false;
        }
    }
    public void SetMovement(Vector2 p_direction, int p_inputX, int p_inputY, float p_movementSpeed, bool p_bool)
    {
        if (!p_bool)
        {
            _isMoving = true;

            Rigidbody.transform.position = Vector3.MoveTowards(Rigidbody.transform.position, _movePoint.position, p_movementSpeed * Time.deltaTime);


            if (CanMove(p_direction))
            {
                if (Vector3.Distance(Rigidbody.transform.position, _movePoint.position) <= 0.05f)
                {
                    if (p_inputX != 0)
                    {
                        _movePoint.position += new Vector3(p_inputX, 0, 0);
                    }

                    if (p_inputY != 0)
                    {
                        _movePoint.position += new Vector3(0, p_inputY, 0);
                    }

                }
            }

            if (Rigidbody.transform.position == _movePoint.position)
            {
                _isMoving = false;
            }
        }
        else
        {
            _movePoint.position = Rigidbody.transform.position;
        }
    }

    public void SetMovementZero()
    {
        Rigidbody.transform.position = Rigidbody.transform.position;
        _movePoint.position = Rigidbody.transform.position;
    }

    private bool CanMove(Vector2 p_direction)
    {
        Vector3Int gridPosition = _groundTiles.WorldToCell(transform.position + (Vector3)p_direction);

        if(!_groundTiles.HasTile(gridPosition) && !_trapsTiles.HasTile(gridPosition) && !_spikesTiles.HasTile(gridPosition) && !_exit.HasTile(gridPosition) || _collisionTiles.HasTile(gridPosition))
        {
            return false;
        }
        else
        {
            return true;

        }


    }

    public void SetMovingBackWardsToTrue() => _isWalkingBackwards = true;
    public void SetMovingBackWardsToFalse() => _isWalkingBackwards = false;
}
