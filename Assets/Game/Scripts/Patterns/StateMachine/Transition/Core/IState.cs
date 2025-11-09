namespace _Project.Scripts._Infrastructure_.Patterns.StateMachine.Core
{
    public interface IState
    {
        
    }
    public interface IEnterState : IState
    {
        void Enter();
    }
    public interface IUpdateState : IState
    {
        void Update();
    }
    public interface IExitState : IState
    {
        void Exit();
    }
}