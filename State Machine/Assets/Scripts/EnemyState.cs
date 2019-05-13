using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyState : MonoBehaviour
{

    private float _followRange = 3f;
    private float _attackRange = 1.2f;
    private float _moveSpeed = 1f;

    private Vector3 _playerPos;

    private EnemyIdleState _idle;
    private EnemyFollowState _follow;
    private EnemyAttackState _attack;

    public Dictionary<EnemyStates, State> states = new Dictionary<EnemyStates, State>();

    void Update()
    {
        float _range = GetRange();

        Debug.Log(_range);

        if (_range <= _followRange && _range > _attackRange)
        {
            states[EnemyStates.FOLLOW].Run(transform);
            return;
        }

        if (_range <= _attackRange)
        {
            states[EnemyStates.ATTACK].Run(transform);
            return;
        }

        states[EnemyStates.WALK].Run(transform);

    }

    float GetRange()
    {
        return Vector3.Distance(transform.position, GameObject.Find("Player").transform.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _followRange);
    }

    public void AddState(EnemyStates key, State value)
    {
        states.Add(key, value);
    }

}
