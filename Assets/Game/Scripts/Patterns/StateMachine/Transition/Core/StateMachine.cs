using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

namespace _Project.Scripts._Infrastructure_.Patterns.StateMachine.Core
{
    public class StateMachine
    {
        private IState _current;
        private readonly Dictionary<Type, IState> _states = new();
        private readonly List<ITransition> _transitions = new();

        public void SetOrigin(IState originState)
        {
            _current = originState;
            AddState(originState);

            if (_current is IEnterState enterState)
                enterState.Enter();
        }

        public void AddState(IState state)
        {
            if (!_states.ContainsKey(state.GetType()))
                _states[state.GetType()] = state;
        }

        public void AddTransition(ITransition transition)
        {
            _transitions.Add(transition);
        }

        public void Update()
        {
            var availableTransition = _transitions
                .Where(t => t.CanTransition(_current))
                .OrderByDescending(t => t.Priority)
                .FirstOrDefault();

            if (availableTransition != null)
                Translate(availableTransition);

            if (_current is IUpdateState updateState)
                updateState.Update();
        }

        private void Translate(ITransition transition)
        {
            if (_current is IExitState exitState)
                exitState.Exit();

            if (!_states.TryGetValue(transition.To, out var nextState))
                throw new Exception($"State {transition.To.Name} not found in StateMachine.");

            _current = nextState;

            if (_current is IEnterState enterState)
                enterState.Enter();
        }
    }
}