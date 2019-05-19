using UnityEngine;
using System.Collections;

public class SuppokuState : State
{

    [SerializeField]
    private ParticleSystem _bloodSplash;

    public override void Enter()
    {
        Debug.Log("You'll never catch me alive!!");
        ParticleSystem blood = Instantiate(_bloodSplash, transform.position, Quaternion.identity);
        Destroy(blood, 1f);
        Destroy(gameObject);
    }

    public override void Act()
    {

    }

    public override void Reason()
    {

    }
}
