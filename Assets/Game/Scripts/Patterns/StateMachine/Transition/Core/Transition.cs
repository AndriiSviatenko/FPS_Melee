using System;
namespace _Project.Scripts._Infrastructure_.Patterns.StateMachine.Core
{
    public class Transition<TFrom, TTo> : ITransition
        where TFrom : IState
        where TTo : IState
    {
        private Func<bool> _condition;
        public Type To { get; private set; }
        public int Priority { get; private set; }

        public Transition<TFrom, TTo> SetCondition(Func<bool> condition, int priority = 0)
        {
            _condition = condition;
            To = typeof(TTo);
            Priority = priority;
            return this;
        }

        public bool CanTransition(IState from)
        {
            if (from is not TFrom) return false;

            if (_condition != null)
                return _condition();

            return false;
        }
    }
}

