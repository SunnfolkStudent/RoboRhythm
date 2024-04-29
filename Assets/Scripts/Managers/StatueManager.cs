using Unity.VisualScripting;
using UnityEngine;

public class StatueManager : MonoBehaviour, IDataPersistence
{
    [SerializeField] private GameObject visualCue;
    [SerializeField] private GameObject backgroundBlock;
    [SerializeField] private GameObject fixedStatue;
    [SerializeField] private SpriteRenderer statueSpriteRenderer;
    [SerializeField] private SpriteRenderer statueHead, statueArm, statueLeg;
    [SerializeField] private bool isFixed;
    private bool playerInRange;
    private Collider2D _collider2D;

    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (isFixed)
        {
            statueSpriteRenderer.enabled = false;
            _collider2D.enabled = false;
            backgroundBlock.SetActive(false);
            fixedStatue.SetActive(true);
        }
        else
        {
            statueSpriteRenderer.enabled = true;
            backgroundBlock.SetActive(true);
            fixedStatue.SetActive(false);
        }
        if (playerInRange)
        {
            if (IsStatueFound())
            {
                visualCue.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    FixStatue();
                }
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }
    
    private bool IsStatueFound()
    {
        if (statueHead.enabled) return false;
        if (statueArm.enabled) return false;
        if (statueLeg.enabled) return false;
        return true;
    }

    private void FixStatue()
    {
        isFixed = true;
        TaskManager.GetInstance().TaskComplete("Cornet"); 
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
        isFixed = data.statueFixed;
    }

    public void SaveData(GameData data)
    {
        data.statueFixed = isFixed;
    }
    
    public void SaveTaskData(GameData data) { }
    public void LoadTaskData(GameData data) { }
    
    public void LoadKeyData(GameData data){}

    public void SaveKeyData(GameData data) { }
}
