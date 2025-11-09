using UnityEngine;

namespace _Project.Scripts._Infrastructure_.Patterns.StateMachine.Core
{
    public class StateMachineUpdate : MonoBehaviour
    {
        private readonly StateMachineRepository _stateMachineRepository;

        public StateMachineUpdate(StateMachineRepository stateMachineRepository) => 
            _stateMachineRepository = stateMachineRepository;

        private void Update()
        {
            foreach (var actor in _stateMachineRepository.All)
                actor.Update();
        }
    }
}