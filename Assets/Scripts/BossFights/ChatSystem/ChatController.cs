using TMPro;
using UnityEngine;

public class ChatController : MonoBehaviour
{
    [SerializeField] private TMP_Text tmpText;

    private int _currentMessageIndex;
    private bool _currentlyInChat;

    private ChatData _chatData;
    private RSongPosition _songPosition;
    private Animator _animator;
    private void Start()
    {
        _chatData = GetComponent<ChatData>();
        _songPosition = FindObjectOfType<RSongPosition>();
        _animator = tmpText.GetComponent<Animator>();
    }

    private void Update()
    {
        if (!_currentlyInChat)
        {
            if(_chatData.chatInfoHolders[_currentMessageIndex].beatNumber - 1.2 > _songPosition.songPosInBeats) return;
            _currentlyInChat = true;
            NewMessage();
        }
        else if(_songPosition.songPosInBeats >= (_chatData.chatInfoHolders[_currentMessageIndex].stayTimeBeats + _chatData.chatInfoHolders[_currentMessageIndex].beatNumber))
        {
            EndMessage();
        }
    }

    private void NewMessage()
    {
        tmpText.text = _chatData.chatInfoHolders[_currentMessageIndex].chatText;
        _animator.Play("FadeIn");
    }

    private void EndMessage()
    {
        _animator.Play("FadeOut");
        if (_currentMessageIndex != _chatData.chatInfoHolders.Length - 1)
        {
            _currentMessageIndex += 1;
            _currentlyInChat = false; 
        }
    }
}
