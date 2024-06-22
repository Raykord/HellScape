using UnityEngine;


public class PlayerRunState : PlayerBaseState
{
	PlayerController controller;
	IPlayerInput _input;

	

	public override void EnterState(PlayerStateManager state)
	{
		Debug.Log("Run state in Town!");
		controller = state.Controller;
		_input = state.Input;
	}
	public override void UpdateState(PlayerStateManager state)
	{
		if (UnityEngine.Input.GetMouseButton(0))
		{
			state.SwitchState(state.attackEntryState);
		}
		else if (!_input.isInput())
		{
			state.SwitchState(state.idleState);
		}
		else if(_input.GetSpaceButton())
		{
			state.SwitchState(state.evadeState);
		}
		
		
		controller.GetDirection();
		
		
	}

	public override void FixedUpdateState(PlayerStateManager state)
	{
		controller.Move();
	}
	public override void OnTriggerEnter(PlayerStateManager state)
	{

	}
}
