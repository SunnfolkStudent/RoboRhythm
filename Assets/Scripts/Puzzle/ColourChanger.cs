using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ColourChanger
{
    private MonoBehaviour _monoBehaviour;

    public ColourChanger(MonoBehaviour monoBehaviour)
    { 
        _monoBehaviour = monoBehaviour;
    }

    public void ChangeColour(GameObject obj, Color color)
    {
        Image img = obj.GetComponent<Image>();
        if (img != null)
        {
            img.color = color;
            _monoBehaviour.StartCoroutine(FlashAlpha(img));
        }
        else
        {
            Debug.LogError("No Image component found on the GameObject.");
        }
    }

    private IEnumerator FlashAlpha(Image img)
    {
        Color color = img.color;
        float elapsedTime = 0f;

        // Increase alpha from 0 to 1
        while (elapsedTime < 0.15f)
        {
            color.a = Mathf.Lerp(0, 0.2f, elapsedTime / 0.15f);
            img.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        color.a = 0.2f;
        img.color = color;
        elapsedTime = 0f;

        // Decrease alpha from 1 to 0
        while (elapsedTime < 0.15f)
        {
            color.a = Mathf.Lerp(0.2f, 0, elapsedTime / 0.15f);
            img.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        color.a = 0;
        img.color = color;
    }
}