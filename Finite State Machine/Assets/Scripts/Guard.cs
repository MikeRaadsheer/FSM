using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum StateId
{
	NullStateId = 0,
	Wandering = 1,
	Alerting = 2,
	Fleeing = 3,
    Suppoku = 4
}

public class Guard : MonoBehaviour {

	/** we declareren de statemachine */
	private StateMachine _stateMachine;

	// Use this for initialization
	void Start () {
		/** we halen een referentie op naar de state machine */
		_stateMachine = GetComponent<StateMachine>();

		/** we voegen de verschillende states toe aan de state machine */
		MakeStates();

		/** we geven de eerste state door (rondlopen) */
		_stateMachine.SetState( StateId.Wandering );
	}
	
	void MakeStates() {
		_stateMachine.AddState( StateId.Alerting, GetComponent<AlertState>() );
		_stateMachine.AddState( StateId.Wandering, GetComponent<WanderState>() );
		_stateMachine.AddState( StateId.Fleeing, GetComponent<FleeState>() );
		_stateMachine.AddState( StateId.Suppoku, GetComponent<SuppokuState>() );
    }

}