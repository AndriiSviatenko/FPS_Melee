using System;
namespace _Project.Scripts._Infrastructure_.Patterns.StateMachine.Core
{
    public interface ITransition
    {
        Type To { get; }
        int Priority { get; }
        bool CanTransition(IState from);
    }
}
