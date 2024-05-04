using UnityEngine;
using UnityEngine.UI;

public class KeyManager : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string keyId;
    [SerializeField] private bool keyObtained = false;
    [SerializeField] private Image image;

    private static KeyManager instance;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void LoadData(GameData data)
    {
        data.keysFound.TryGetValue(keyId, out keyObtained);
        if (keyObtained)
        {
            image.enabled = true;
        }
        else
        {
            image.enabled = false;
        }
    }

    public void SaveData(GameData data)
    {
        if (data.keysFound.ContainsKey(keyId))
        {
            data.keysFound.Remove(keyId, out keyObtained);
        }
        data.keysFound.Add(keyId, keyObtained);
    }
}
