﻿using UnityEngine;
using System.Collections;

public class WanderState : State {

	[SerializeField]
	private float _speed = 1f;

	[SerializeField]
	private float _arrivalDistance = 0f;

	[SerializeField]
	private float _sightDistance = 2.5f;

	[SerializeField]
	private GameObject _player;

	private Vector2 _targetPosition = new Vector2();
	
	public override void Enter(){
		// we switchen naar deze state: dus kies alvast een nieuwe target position
		ChooseTargetLocation();
	}

	void ChooseTargetLocation(){
		// kiest een locatie binnen het veld van de camera
		Vector3 world = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
		
		_targetPosition.x = Random.Range(-world.x, world.x);
		_targetPosition.y = Random.Range(-world.y, world.y);
	}

	public override void Act(){
		float step = _speed * Time.deltaTime;
		float distance;

		transform.position = Vector2.MoveTowards(transform.position, _targetPosition, step);
		distance = Vector2.Distance(transform.position, _targetPosition);

		if(distance < _arrivalDistance)
			ChooseTargetLocation();
	}

	public override void Reason(){
		float distanceToPlayer = Vector2.Distance(_player.transform.position, transform.position);

		if(distanceToPlayer < _sightDistance){
			// laten we switchen naar een nieuwe state
			GetComponent<StateMachine>().SetState(StateId.Alerting);
		}

	}


}
