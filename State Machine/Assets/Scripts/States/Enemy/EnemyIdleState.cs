using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : State
{
    private float _maxX = 8f;
    private float _minX = 2f;
    private float _moveSpeed = 1;
    private bool _moveLeft = false;

    public override void Run(Transform _transform)
    {
        
        if (_transform.position.x < _minX)
        {
            _moveLeft = false;
        }
        else if (_transform.position.x > _maxX)
        {
            _moveLeft = true;
        }

        if (_moveLeft)
        {
            _transform.position -= new Vector3(_moveSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            _transform.position += new Vector3(_moveSpeed * Time.deltaTime, 0, 0);
        }

    }
}
