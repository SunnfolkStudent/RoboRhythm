using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Scripts")]
    private PlayerAnimation _playerAnimation;
    private PlayerMovement _playerMovement;
    private Input_Controller _inputController;


    private void Start()
    {
        PlayerEvents.returnPlayer?.Invoke(gameObject);
        
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        _playerAnimation.UpdateAnimation(_playerMovement.moveVector);
    }
}