using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObserverTimer : MonoBehaviour
{
    private float m_Duration = 8.0f;
    private float m_HalfTime;
    public delegate void TimerStarted();
    public static event TimerStarted OnTimerStarted;
    public delegate void HalfTime();
    public static event HalfTime OnHalfTime;
    public delegate void TimerEnded();
    public static event TimerEnded OnTimerEnded;
    public WarningLight warningLight;
    private IEnumerator m_Coroutine;
    public Transform player;
    public Text scoreText;

    IEnumerator Start()
    {
        m_HalfTime = m_Duration / 2;
        OnTimerStarted?.Invoke();
        yield return StartCoroutine(WaitAndPrint(1.0F));
        OnTimerEnded?.Invoke();
    }
    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (Time.time < m_Duration)
        {
            yield return new WaitForSeconds(waitTime);
            Debug.Log("Seconds: " + Mathf.Round(Time.time));
            if (Mathf.Round(Time.time) == Mathf.Round(m_HalfTime))
            {
                if (OnHalfTime != null)
                {
                    OnHalfTime();
                    warningLight.OnEnable();
                    warningLight.OnDisable();
                }
            }
        }
    }
}