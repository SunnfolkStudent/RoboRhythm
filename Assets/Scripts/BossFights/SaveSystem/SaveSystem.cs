using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static int currentSave;
    [SerializeField] private float[] savePoints;
    [SerializeField] private GameObject playerHitbox;
    [SerializeField] private GameObject platformHitbox;
    [SerializeField] private GameObject chatSystem;

    private float _secondsToSaveTo;
    
    private RSongPosition _songPosition;
    private AudioSource _songSource;
    

    private void Start()
    {
        _songPosition = FindObjectOfType<RSongPosition>();
        _songSource = _songPosition.GetComponent<AudioSource>();
        _secondsToSaveTo = savePoints[currentSave] * _songPosition.secPerBeat;
        _songSource.time = _secondsToSaveTo;
        _songPosition.skipTime = _secondsToSaveTo;
        Invoke("ActivateHitBoxes",.5f);
    }

    //Updates Save If SavePoint Hit
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            currentSave += 1;
            Debug.Log("Delete Later XD");
        }
        ;
        if(currentSave == savePoints.Length - 1) return;
        if (_songPosition.songPosInBeats >= savePoints[currentSave + 1])
        {
            Debug.Log("Checkpoint Hit" + (currentSave + 1) + "Delete Later");
            currentSave += 1;
        }
    }

    private void ActivateHitBoxes()
    {
        playerHitbox.SetActive(true);
        platformHitbox.SetActive(true);
        chatSystem.SetActive(true);
    }
}
