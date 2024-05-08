using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Scripts")]
    private PlayerAnimation _playerAnimation;
    private PlayerMovement _playerMovement;
    private Input_Controller _inputController;
    private PlayerSound _playerSound;
    
    private void Start()
    {
        PlayerEvents.returnPlayer?.Invoke(gameObject);
        
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerSound = GetComponent<PlayerSound>();
    }

    private void Update()
    {
        _playerAnimation.UpdateAnimation(_playerMovement.moveVector, _playerMovement.isRunning);
        
        if (_playerMovement.moveVector != Vector2.zero)
        {
            if (!_playerSound.StepsArePlaying())
            {
                _playerSound.PlayFootsteps();
            }

            if (_playerMovement.isRunning)
            {
                if (_playerSound.GetFootstepsParameter() != Footsteps.Run)
                {
                    _playerSound.SetFootstepsParameter(Footsteps.Run);
                }
            }
            else
            {
                if (_playerSound.GetFootstepsParameter() != Footsteps.Walk)
                {
                    _playerSound.SetFootstepsParameter(Footsteps.Walk);
                }
            }
        }
        else
        {
            _playerSound.StopFootsteps();
        }
    }
}