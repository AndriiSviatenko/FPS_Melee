using _project.Scripts.StateMachines.Any.Core;

public class StartGame : IState
{
    private readonly StateMachine _stateMachine;


    public StartGame(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }
}
