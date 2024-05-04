using UnityEngine;

public class VictoryText : MonoBehaviour
{
    [SerializeField] private float showUpBeat;

    private bool _activatedAnimation;
    private RSongPosition _songPosition;
    private Animator _animator;

    private void Start()
    {
        _songPosition = FindObjectOfType<RSongPosition>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(_activatedAnimation) return;
        if (showUpBeat < _songPosition.songPosInBeats)
        {
            _animator.Play("victory_animation_Clip");
        }
    }
}
