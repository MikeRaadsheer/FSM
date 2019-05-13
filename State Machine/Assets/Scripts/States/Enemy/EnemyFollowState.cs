using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowState : State
{
    private bool moveLeft = false;
    private float _speed = 1.2f;


    public override void Run(Transform _transform)
    {
        Vector3 _playerPos = GameObject.Find("Player").transform.position;

        moveLeft = _transform.position.x > _playerPos.x;
        

        if (moveLeft)
        {
            _transform.position -= new Vector3(_speed * Time.deltaTime, 0, 0);
        }
        else
        {
            _transform.position += new Vector3(_speed * Time.deltaTime, 0, 0);
        }

    }
}
