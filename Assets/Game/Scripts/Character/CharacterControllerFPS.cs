using System;
using System.Collections;
using UnityEngine;

public class CharacterControllerFPS : MonoBehaviour, IService
{
    public const string IDLE = "Idle";
    public const string WALK = "Walk";
    public const string ATTACK1 = "Attack 1";
    public const string ATTACK2 = "Attack 2";


    [Header("Attacking")]
    [Space(20f)]
    public float attackDistance = 3f;
    public float attackDelay = 0.4f;
    public float attackSpeed = 1f;
    public int attackDamage = 1;
    public LayerMask attackLayer;

    public GameObject hitEffect;
    public AudioClip swordSwing;
    public AudioClip hitSound;

    [Header("Controller")]
    [Space(20f)]
    public float moveSpeed = 5;
    public float gravity = -9.8f;
    public float jumpHeight = 1.2f;


    [Header("Camera")]
    [Space(20f)]
    public Camera cam;
    public float sensitivity;


    [Header("Components")]
    [Space(20f)]
    [SerializeField] private Mover mover;
    [SerializeField] private Rotate rotate;
    [SerializeField] private Gravity gravityComponent;
    [SerializeField] private Attack attack;
    [SerializeField] private Raycastor raycastor;
    [SerializeField] private HitRenderer hitRenderer;
    [SerializeField] private PlayerAnimator playerAnimator;
    [SerializeField] private Jumper jumper;
    [SerializeField] private AudioSystem audioSystem;

    private PlayerInput playerInput;
    private PlayerInput.MainActions input;
    private UnityEngine.CharacterController controller;
    private Animator animator;
    private Vector3 _PlayerVelocity;
    private bool isGrounded;
    private int attackCount;
    private bool _attacking = false;

    private void OnDisable() =>
        input.Disable();

    private void Start()
    {
        //START GAME
        controller = GetComponent<UnityEngine.CharacterController>();
        animator = GetComponentInChildren<Animator>();

        playerInput = new PlayerInput();
        input = playerInput.Main;
        input.Enable();
        AssignInputs();

        mover.Init(controller);
        mover.SetSpeed(8);

        mover.StartComponent();

        rotate.Init(cam);
        rotate.SetSensitivity(15);
        rotate.SetMinAngle(-80);
        rotate.SetMaxAngle(80);

        rotate.StartComponent();

        gravityComponent.Init(controller);
        gravityComponent.SetGravity(gravity);
        gravityComponent.SetMinVelocityY(-2f);

        gravityComponent.StartComponent();

        attack.SetDamage(attackDamage);

        attack.StartComponent();

        raycastor.Init(cam, attackLayer);
        raycastor.SetDistance(attackDistance);

        raycastor.StartComponent();

        hitRenderer.Init(hitEffect);
        hitRenderer.StartComponent();

        playerAnimator.Init(animator);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        audioSystem = FindObjectOfType<AudioSystem>();
    }
    private void AssignInputs()
    {
        input.Jump.performed += ctx => Jump();
        input.Attack.started += ctx => Attack();
    }

    private void Update()
    {
        isGrounded = controller.isGrounded;
        playerAnimator.SetAnimations(_attacking, _PlayerVelocity);
    }

    private void FixedUpdate()
    {
        mover.Move(input.Movement.ReadValue<Vector2>());
        _PlayerVelocity = gravityComponent.Apply(_PlayerVelocity);
    }

    private void LateUpdate() =>
        rotate.Look(input.Look.ReadValue<Vector2>());

    private void Jump()
    {
        _PlayerVelocity = jumper.Jump(isGrounded, _PlayerVelocity, jumpHeight, gravity);
    }

    public void Attack()
    {
        if (_attacking)
            return;

        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        ChangeAnim();
        _attacking = true;
        yield return new WaitForSeconds(attackDelay);
        var health = raycastor.Raycast<Health>(out bool isHit, out Vector3 hitPoint);
        attack.Execute(health);
        audioSystem.Play(swordSwing);

        if (isHit)
        {
            audioSystem.Play(hitSound);
            hitRenderer.Render(hitPoint);
        }

        yield return new WaitForSeconds(attackSpeed);
        attack.ResetAttack();
        _attacking = false;
    }

    private void ChangeAnim()
    {
        if (attackCount == 0)
        {
            playerAnimator.ChangeAnimationState(ATTACK1);
            attackCount++;
        }
        else
        {
            playerAnimator.ChangeAnimationState(ATTACK2);
            attackCount = 0;
        }
    }
}
