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
        currentScore += pointWorth;
        tmpScoreText.text = currentScore.ToString();
        tmpFeedbackText.text = scoreText;
        tmpFeedbackText.color = textColor;

        if (perfectHit)
        {
            if (currentBonus > 0)
            {
                currentScore += 2;
                tmpFeedbackText.text = scoreText + "x" + (currentBonus + 1);
                tmpScoreText.text = currentScore.ToString();
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