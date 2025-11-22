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

    [SerializeField] private Transform pointCam;
    public Transform PointCam => pointCam;
    private Camera _cam;

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
    [SerializeField] private StatController statsController;
    private AudioSystem _audioSystem;

    private PlayerInput playerInput;
    private PlayerInput.MainActions input;
    private CharacterController _controller;
    private Animator animator;
    private Vector3 _PlayerVelocity;
    private bool isGrounded;
    private int attackCount;
    private bool _attacking = false;
    private SliderContainer _slider;

    private void OnDisable() =>
        input.Disable();

    public void SetSlider(SliderContainer slider)
    {
        _slider = slider;
        statsController.Init(_slider.View);
        statsController.StartComponent();
    }
    public void SetCamera(Camera camera)
    {
        _cam = camera;
        _cam.transform.SetParent(pointCam);
        _cam.transform.localPosition = Vector3.zero;
        rotate.Init(_cam);
        rotate.SetSensitivity(15);
        rotate.SetMinAngle(-180);
        rotate.SetMaxAngle(180);

        rotate.StartComponent();
    }

    public void SetAudioSystem(AudioSystem audioSystem)
    {
        _audioSystem = audioSystem;
    }

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        playerInput = new PlayerInput();
        input = playerInput.Main;
        input.Enable();
        AssignInputs();

        mover.Init(_controller);
        mover.SetSpeed(8);

        mover.StartComponent();

        gravityComponent.Init(_controller);
        gravityComponent.SetGravity(gravity);
        gravityComponent.SetMinVelocityY(-2f);

        gravityComponent.StartComponent();

        attack.SetDamage(attackDamage);

        attack.StartComponent();

        raycastor.Init(_cam, attackLayer);
        raycastor.SetDistance(attackDistance);

        raycastor.StartComponent();

        hitRenderer.Init(hitEffect);
        hitRenderer.StartComponent();

        playerAnimator.Init(animator);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void AssignInputs()
    {
        input.Jump.performed += ctx => Jump();
        input.Attack.started += ctx => Attack();
    }

    private void Update()
    {
        isGrounded = _controller.isGrounded;
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
        _audioSystem.Play(swordSwing);

        if (isHit)
        {
            _audioSystem.Play(hitSound);
            hitRenderer.Render(hitPoint);
        }

        float temp = attackSpeed;
        statsController.SetValue(temp);

        while (temp > 0)
        {
            float start = temp;
            float end = temp - 1;
            float t = 0f;

            while (t < 1f)
            {
                t += Time.deltaTime;
                float value = Mathf.Lerp(start, end, t);
                statsController.SetValue(value);
                yield return null;
            }

            temp = end;
            Debug.Log($"Temp is {temp}");
        }

        attack.ResetAttack();
        _attacking = false;

        statsController.SetValue(attackSpeed);
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
