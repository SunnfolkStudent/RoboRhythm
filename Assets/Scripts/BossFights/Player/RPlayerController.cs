using UnityEngine;

[RequireComponent(typeof(RPlayerAnimator))]
public class RPlayerController : MonoBehaviour
{
    public delegate void AttackEvent();

    public static event AttackEvent AttackHasOccured;
    
    [Header("Must Be 5!")]
    [SerializeField] private Vector2[] positionStates = new Vector2[5];
    
    private RPlayerAnimator _animation;
    private Controls _bossFightControls;
    private void Awake()
    {
        _bossFightControls = new Controls();
        _animation = GetComponent<RPlayerAnimator>();
    }
    
    private int currentState;

    private void Start()
    {
        currentState = 2;
        MoveToState();
    }

    private void OnLeft()
    {
        if (currentState > 0)
        {
            currentState -= 1;
            MoveToState();
            _animation.PlayAnimation("jump_left");
        }
    }

    private void OnRight()
    {
        if (currentState < 4)
        {
            currentState += 1;
            MoveToState();
            _animation.PlayAnimation("jump_right");
        }
    }

    private void OnAttack()
    {
        if (AttackHasOccured != null) AttackHasOccured();
        _animation.PlayAnimation("attack");
    }

    private void MoveToState()
    {
        var o = gameObject;
        o.transform.position = new Vector3(positionStates[currentState].x,positionStates[currentState].y,o.transform.position.z);
    }
}
