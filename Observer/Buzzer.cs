using UnityEngine;
using UnityEngine.UI;

public class Buzzer : MonoBehaviour
{
    public Text AnnouceBuzzer;
    void OnEnable()
    {
        ObserverTimer.OnTimerStarted += PlayStartBuzzer; ObserverTimer.OnTimerEnded += PlayEndBuzzer;
    }
    void OnDisable()
    {
        ObserverTimer.OnTimerStarted -= PlayStartBuzzer; ObserverTimer.OnTimerEnded -= PlayEndBuzzer;
    }
    void PlayStartBuzzer()
    {
        Debug.Log("[BUZZER] : Play start buzzer!");
        AnnouceBuzzer.text = "Start!";
    }
    void PlayEndBuzzer()
    {
        Debug.Log("[BUZZER] : Play end buzzer!");
        AnnouceBuzzer.text = "End!";
    }
}