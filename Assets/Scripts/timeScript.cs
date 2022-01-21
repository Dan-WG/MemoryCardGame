using UnityEngine;
using UnityEngine.UI;

public class timeScript : MonoBehaviour
{
    public Text counterText;
    public bool timeCounter = true;
    public float seconds, minutes;

    // Use this for initialization
    private void Start()
    {
        counterText = GetComponent<Text>() as Text;
    }

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