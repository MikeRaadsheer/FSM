using UnityEngine;
using System.Collections;

public class AlertState : State {

	[SerializeField]
	private float _alertDuration = 4f;

    [SerializeField]
    private GameObject _player;

    private float _currentAlarmTime;
    private float _suppokuRange = 0.4f;
	public override void Enter(){
		_currentAlarmTime = 0f;
	}

	public override void Act(){
		float size = Random.Range(0.5f, 1.5f);
		transform.localScale = new Vector3(size, size, size);
		_currentAlarmTime += Time.deltaTime;
	}

	public override void Reason(){
        float distanceToPlayer = Vector2.Distance(_player.transform.position, transform.position);

        if (_currentAlarmTime > _alertDuration)
            GetComponent<StateMachine>().SetState(StateId.Fleeing);

        if (distanceToPlayer < _suppokuRange)
            GetComponent<StateMachine>().SetState(StateId.Suppoku);
    }

}