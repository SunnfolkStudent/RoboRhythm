using UnityEngine;
using TMPro;

public class RScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text tmpFeedbackText;
    [SerializeField] private TMP_Text tmpScoreText;
    
    private int currentScore;
    private int currentBonus;
    
    public void NoteHit(int pointWorth, string scoreText, Color32 textColor, bool perfectHit)
    {
        currentScore += pointWorth + currentBonus;
        tmpScoreText.text = currentScore.ToString();
        tmpFeedbackText.text = scoreText;
        tmpFeedbackText.color = textColor;
        Debug.Log(textColor);

        if (perfectHit)
        {
            if (currentBonus > 0)
            {
                tmpFeedbackText.text = scoreText + "x" + (currentBonus + 1);
            }
            currentBonus += 1;
        }
        else
        {
            currentBonus = 0;
            tmpFeedbackText.text = scoreText;
        }
    }
    
}