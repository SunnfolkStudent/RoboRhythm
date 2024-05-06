using FMODUnity;
using UnityEngine;

public class StatueManager : MonoBehaviour, IDataPersistence
{
    [SerializeField] private GameObject visualCue;
    [SerializeField] private GameObject fixedStatue;
    [SerializeField] private GameObject brokenStatue;
    [SerializeField] private SpriteRenderer statueHead, statueArm, statueLeg;
    [SerializeField] private bool isFixed;
    [SerializeField] private TaskManager _taskManager;
    private bool playerInRange;
    private string npcTaskId = "Cornet";
    private Collider2D _collider2D;

    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (isFixed)
        {
            fixedStatue.SetActive(true);
            brokenStatue.SetActive(false);
            _collider2D.enabled = false;
        }
        else
        {
            fixedStatue.SetActive(false);
            brokenStatue.SetActive(true);
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
        AudioManager.instance.PlayOneShot(FmodEvents.instance.stonesFalling, gameObject.transform.position);
        isFixed = true;
        _taskManager.TaskComplete(npcTaskId);
        Debug.Log("update task manager from finishing statue");
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
}
