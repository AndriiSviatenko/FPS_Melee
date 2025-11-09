using System;

public class Attack : BaseCustomComponent
{
    public event Action AttackEvent;
    private int _damage;

    private bool _attacking;
    private bool _readyToAttack;
    public bool Attacking => _attacking;

    public void SetDamage(int value)
    {
        _damage = value;
    }
    public void Execute(Health health)
    {
        if (!_readyToAttack || _attacking) return;

        _readyToAttack = false;
        _attacking = true;

        if (health == null) 
            return;

        health.TakeDamage(_damage);
        AttackEvent?.Invoke();
    }

    public void ResetAttack()
    {
        _attacking = false;
        _readyToAttack = true;
    }
}
