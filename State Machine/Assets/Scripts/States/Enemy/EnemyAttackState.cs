using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : State
{
    public override void Run(Transform _transform)
    {
        Debug.Log("Attack");
    }
}
