using UnityEngine;
using Zenject;

public class PlayerStateManager : MonoBehaviour
{
    //Текущее состояние
    PlayerBaseState currentState;
    //Доступные состояния
    public PlayerIdleState idleState = new PlayerIdleState();
    public PlayerRunState runState = new PlayerRunState();
    public PlayerAttackState attackState = new PlayerAttackState();
	public PlayerMeleeAttackEntry attackEntryState = new PlayerMeleeAttackEntry();
	public PlayerEvadeState evadeState = new PlayerEvadeState();
    public PlayerTakeDamageState takeDamageState = new PlayerTakeDamageState();

    public IPlayerInput Input;
    public PlayerController Controller;

    [Inject]
    public void Construct(IPlayerInput input, PlayerController controller)
    {
        Input = input;
        Controller = controller;
        Debug.LogWarning("INJECT IS SUCCESFUL");
    }

    public bool canEvade = true;
	float timer = 0;

	[SerializeField] float evadeCooldown = 2;


	// Start is called before the first frame update
	void Start()
    {
        currentState = idleState;
        currentState.EnterState(this);
	}

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
        if (!canEvade)
        {
			timer += Time.deltaTime;
			if (timer > evadeCooldown)
			{
				canEvade = true;
				timer = 0;
			}
		}
    }

	void FixedUpdate()
	{
		currentState.FixedUpdateState(this);
	}

	public void SwitchState(PlayerBaseState state) 
    {
        currentState = state;
        state.EnterState(this);
    }
}
