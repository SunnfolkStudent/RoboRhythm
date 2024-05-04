using UnityEngine;
using TMPro;

public class RScoreManager : MonoBehaviour
{
    [SerializeField] private Animator feedBackImageAnimator;
    [SerializeField] private TMP_Text tmpScoreText;
    
    private int currentScore;
    private int currentBonus;
    
    public void NoteHit(int pointWorth, int scoreFeedback, bool perfectHit)
    {
        currentScore += pointWorth;
        tmpScoreText.text = currentScore.ToString();
        SetFeedBackImage(scoreFeedback);

        if (perfectHit)
        {
            if (currentBonus > 0)
            {
                currentScore += 2;
                tmpScoreText.text = currentScore.ToString();
            }
            currentBonus += 1;
        }
        else
        {
            currentBonus = 0;
        }
    }

    private void SetFeedBackImage(int scoreFeedbackNumber)
    {
        switch (scoreFeedbackNumber)
        {
            case 0:
                feedBackImageAnimator.Play("Null",-1,0f);
                break;
            case 1:
                feedBackImageAnimator.Play("Bad",-1,0f);
                break;
            case 2:
                feedBackImageAnimator.Play("Good",-1,0f);
                break;
            case 3:
                feedBackImageAnimator.Play("Great",-1,0f);
                break;
            default:
                Debug.Log("Something went wrong");
                break;
        }
    }

}