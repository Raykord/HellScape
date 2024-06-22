﻿using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
	IPlayerInput input;
	PlayerController controller;
	public override void EnterState(PlayerStateManager state)
	{
		Debug.Log("Idle state active");
		//Логика на включение анимации
		//state.gameObject.GetComponent<PlayerAnimator>().Idle();
		input = state.Input;
		controller = state.Controller;
	}
	public override void UpdateState(PlayerStateManager state)
	{
		if (input.GetHorizontalInput() != 0 || input.GetVerticalInput() != 0)
		{
			state.SwitchState(state.runState);
		}
		else if (Input.GetMouseButton(0))
		{
			state.SwitchState(new PlayerMeleeAttackEntry());
		}
		else
		{
			controller.StopMove();
		}
	}

	public override void FixedUpdateState(PlayerStateManager state)
	{
		
	}
	public override void OnTriggerEnter(PlayerStateManager state)
	{

	}
}
