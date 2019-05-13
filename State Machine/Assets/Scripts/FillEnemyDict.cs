using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillEnemyDict : MonoBehaviour {

    private EnemyState _es;

    private void Start()
    {
        _es = GetComponent<EnemyState>();

        _es.AddState(EnemyStates.WALK, new EnemyIdleState());
        _es.AddState(EnemyStates.FOLLOW, new EnemyFollowState());
        _es.AddState(EnemyStates.ATTACK, new EnemyAttackState());
    }

}
