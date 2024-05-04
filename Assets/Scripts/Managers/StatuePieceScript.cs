using UnityEngine;

public class StatuePieceScript : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string statuePieceId;
    [SerializeField] private bool isFound;
    [SerializeField] private GameObject visualCue;
    private bool playerInRange;
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider2D;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (isFound)
        {
            _spriteRenderer.enabled = false;
            _collider2D.enabled = false;
        }
        if (playerInRange)
        {
            visualCue.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                PickUpObject();
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }

    private void PickUpObject()
    {
        AudioManager.instance.PlayOneShot(FmodEvents.instance.pickingUpStone, gameObject.transform.position);
        _spriteRenderer.enabled = false;
        _collider2D.enabled = false;
        isFound = true;
        DataPersistenceManager.instance.SaveGame();
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
    
    public void LoadData(GameData data)
    {
        data.statuePiecesFound.TryGetValue(statuePieceId, out isFound);
    }

    public void SaveData(GameData data)
    {
        if (data.statuePiecesFound.ContainsKey(statuePieceId))
        {
            data.statuePiecesFound.Remove(statuePieceId);
        }
        data.statuePiecesFound.Add(statuePieceId, isFound);
    }
}
