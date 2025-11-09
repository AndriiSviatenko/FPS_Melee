using System.Collections.Generic;

namespace _Project.Scripts._Infrastructure_.Patterns.StateMachine
{
    public class StateMachineRepository
    {
        public List<Core.StateMachine> All => _units;

        private readonly List<Core.StateMachine> _units = new();

        public void Register(Core.StateMachine aiActor) =>
            _units.Add(aiActor);

        public void Unregister(Core.StateMachine aiActor) =>
            _units.Remove(aiActor);
    }
}
