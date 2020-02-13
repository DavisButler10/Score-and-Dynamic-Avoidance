using UnityEngine;

public class Notifier : MonoBehaviour
{
    void OnEnable()
    {
        ObserverTimer.OnTimerEnded += ShowGameOverPopUp;
    }
    void OnDisable()
    {
        ObserverTimer.OnTimerEnded -= ShowGameOverPopUp;
    }
    void ShowGameOverPopUp()
    {
        Debug.Log("[NOTIFIER] : Show game over pop up!");
    }
}