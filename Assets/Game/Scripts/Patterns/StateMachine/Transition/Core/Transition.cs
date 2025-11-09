using System;
namespace _Project.Scripts._Infrastructure_.Patterns.StateMachine.Core
{
    public class Transition<TFrom, TTo> : ITransition
        where TFrom : IState
        where TTo : IState
    {
        private readonly Func<bool> _condition;
        private readonly Func<IState, IState, bool> _checkStateEquals;
        public Type To { get; }

        public Transition(Func<bool> condition)
        {
            _condition = condition;
            To = typeof(TTo);
        }
        public Transition(Func<IState, IState, bool> checkStateEquals)
        {
            _checkStateEquals = checkStateEquals;
        }

        public bool CanTransition(IState from) =>
            from is TFrom && _condition();
    }
}

