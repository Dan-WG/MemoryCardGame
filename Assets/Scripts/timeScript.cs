using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timeScript : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    public bool timeCounter = true;
    public float seconds, minutes;

  

    // Update is called once per frame
    private void Update()
    {
        if (timeCounter)
        {
            seconds = (int)(Time.timeSinceLevelLoad % 60f);
            counterText.text = seconds.ToString("00");
        }
    }

    public void endGame()
    {
        timeCounter = false;
        counterText.color = Color.yellow;
    }
}