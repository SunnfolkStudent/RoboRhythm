using UnityEngine;

[RequireComponent(typeof(RProjectileMovement))]
[RequireComponent(typeof(Animator))]
public class RProjectileAnimation : MonoBehaviour
{
    [SerializeField] private RAnimationHolder[] animations;
    
    private int currentAnimationIndex;
    
    private RProjectileMovement projectileMovement;
    private Animator animator;
    
    private void Awake()
    {
        projectileMovement = GetComponent<RProjectileMovement>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var animationTime = projectileMovement.timeVariable + projectileMovement.timeVariable1;
        if(animations.Length <= currentAnimationIndex) {return;}
        if (animations[currentAnimationIndex].timeOfAnimation > animationTime) {return;}
        animator.Play(animations[currentAnimationIndex].animation);
        currentAnimationIndex++;
    }
}