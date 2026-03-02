using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public float timeRemaining = 300f; // 5 minutes 
    private bool timerIsRunning = false;

    private void Start()
    {
        timerIsRunning = true; 
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                Debug.Log("Time's up!");
            }
        }
    }
    private void UpdateTimerDisplay(float timeToDisplay)
    {
        // Clamp negative values to zero
        timeToDisplay = Mathf.Max(0, timeToDisplay);

        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}
