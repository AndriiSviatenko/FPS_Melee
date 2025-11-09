using System.Linq;
using UnityEngine;

namespace _Project.Scripts._Infrastructure_.Patterns.StateMachine.Core
{
    public class StateMachine
    {
        private IState _current;
        private readonly IState[] _states;
        private readonly ITransition[] _transitions;

        public StateMachine(IState originState, IState[] states, ITransition[] transitions)
        {
            _current = originState;
            _states = states.Concat(new[] { originState }).ToArray();
            _transitions = transitions;

            if (_current is IEnterState enterState)
                enterState.Enter();
        }

        public void Update()
        {
            foreach (var transition in _transitions)
            {
                if (transition.CanTransition(_current))
                {
                    Translate(transition);
                }
            }

            if (_current is IUpdateState updateState)
            {
                updateState.Update();
            }
        }

        private void Translate(ITransition transition)
        {
            if (_current is IExitState exitState)
                exitState.Exit();

            _current = _states.First(x => x.GetType() == transition.To);

            if (_current is IEnterState enterState)
                enterState.Enter();
        }
    }
}