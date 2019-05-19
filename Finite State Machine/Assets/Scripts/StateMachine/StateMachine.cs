using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateMachine : MonoBehaviour {

	/// <summary>
	/// Deze finite state machine kan makkelijk hergebruikt worden in verschillende projecten
	/// Aangezien hij niet gekoppeld is aan specifieke details (namen van Classes, etc.) van dit project
	/// Enige minpunt is dat hij MonoBehaviour extend
	/// </summary>

	/** We maken een dictionary aan om de states in bij te houden */
	private Dictionary<StateId, State> _states = new Dictionary<StateId, State> ();

	/** een verwijzing naar de huidige staat waarin we verkeren */
	private State _currentState;
	
	void Update () {
		// als we een state hebben: uitvoeren die hap
		if (_currentState == null) 
			return;
		
		_currentState.Reason();
		_currentState.Act();

	}

	/// <summary>
	/// Method om de state te wijzigen
	/// </summary>
	public void SetState(StateId stateId) {

		/** als we de stateID niet kennen als state: stop deze functie dan */
		if(!_states.ContainsKey(stateId))
			return;

		/** als we ons al in een state bevinden: geef de state de mogelijkheid zich op te ruimen */
		if(_currentState != null)
			_currentState.Leave();

		/** we stellen de nieuwe _currentState in */
		_currentState = _states[stateId];

		/** we geven de nieuwe state de mogelijkheid om zich zelf in te stellen */
		_currentState.Enter();
	}

	/// <summary>
	/// Voeg een state toe aan de state machine
	/// LET OP! Alle components die de Class State.cs extenden (inheritance) die mogen in de Dictionary
	/// Daarom mogen AlertState.cs, AlertState.cs en FleeState.cs in de dictionary, aangezien zij State.CS extenden
	/// </summary>
	/// <param name="stateId">Een integer die komt uit de ENUM StateID (zie StateID in Guard.cs)</param>
	/// <param name="state">Een component die State.cs extend (inheritance)</param>
	public void AddState(StateId stateId, State state) {
		_states.Add( stateId, state );
	}

}
