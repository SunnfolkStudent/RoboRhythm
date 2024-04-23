using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RPlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimation(string animationName)
    {
        _animator.Play(animationName);
    }
}
