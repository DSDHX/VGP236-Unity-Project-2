using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI checkpointTimerText;
    [SerializeField] private TextMeshProUGUI totalTimeText;
    [SerializeField] private TextMeshProUGUI FinalText;

    [SerializeField] private float checkpointTimeLimit = 60f;

    private float totalTime = 1f;
    private float currentCheckpointTimer;
    private bool isCheckpointReached = false;
    private bool isGameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentCheckpointTimer = checkpointTimeLimit;
        UpdateCheckpointTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            totalTime += Time.deltaTime;
            totalTimeText.text = FormatTime(totalTime);

            if (!isCheckpointReached)
            {
                currentCheckpointTimer -= Time.deltaTime;
                UpdateCheckpointTimer();

                if (currentCheckpointTimer <= 0)
                {
                    HandleTimeOut();
                }
            }
        }
    }

    public void OnFirstCheckPoint()
    {
        isCheckpointReached = true;
        checkpointTimerText.color = Color.green;
    }

    public void OnFinishReach()
    {
        isGameOver = true;
        ShowFinal();
    }

    private void UpdateCheckpointTimer()
    {
        checkpointTimerText.text = $"FIRST CHCKPOINT:\n{FormatTime(currentCheckpointTimer)}";
    }

    private string FormatTime(float seconds)
    {
        int minutes = Mathf.FloorToInt(seconds / 60);
        int remaingSeconds = Mathf.FloorToInt(seconds % 60);
        return $"{minutes:00}:{remaingSeconds:00}";
    }

    private void HandleTimeOut()
    {
        FindFirstObjectByType<PlayerHealth>().Respawn();
        currentCheckpointTimer = checkpointTimeLimit;
    }

    private void ShowFinal()
    {
        FinalText.text = $"FINISHED!\nTotal Time: {FormatTime(totalTime)}";        
    }
}
