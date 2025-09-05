using UnityEngine;

public class PlayerAnimator : BaseCustomComponent
{
    private const float FIXED_TRANSITION_DURATION = 0.2f;

    public const string IDLE = "Idle";
    public const string WALK = "Walk";
    public const string ATTACK1 = "Attack 1";
    public const string ATTACK2 = "Attack 2";
    private string _currentAnimationState;
    private Animator _animator;

    public void Init(Animator animator)
    {
        _animator = animator;
    }

    public void ChangeAnimationState(string newState)
    {
        if (_currentAnimationState == newState) return;

        _currentAnimationState = newState;
        _animator.CrossFadeInFixedTime(_currentAnimationState, FIXED_TRANSITION_DURATION);
    }

    public void SetAnimations(bool attacking, Vector3 playerVelocity)
    {
        if (!attacking)
        {
            if (playerVelocity.x < 0.001f && playerVelocity.z < 0.001f)
            {
                ChangeAnimationState(IDLE);
            }
            else
            {
                ChangeAnimationState(WALK); 
            }
        }
    }
}
