using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameManager gameManager;
    public Transform player;
    public Text timerText;
    public Text timerFinalText;
    private float secondsCount;
    private int minuteCount;
    

    void Update()
    {
        secondsCount += Time.deltaTime;
        if (!gameManager.gameHasEnded)
        {
            if (secondsCount < 10)
            {
                timerText.text = minuteCount + ":" + "0" + (int)secondsCount;
                //timerFinalText.text = minuteCount + ":" + "0" + (int)secondsCount + "  sec";
            }
            else
            {
                    timerText.text = minuteCount + ":" + (int)secondsCount;
                    //timerFinalText.text = minuteCount + ":" + (int)secondsCount + "  sec";
            }
        }
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
    }
}


