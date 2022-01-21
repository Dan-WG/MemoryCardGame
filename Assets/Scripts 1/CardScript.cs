using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CardScript : MonoBehaviour
{
    public static bool Do_not = false;

    [SerializeField]
    public int state;

    public int CardValue;
    public bool initialized = false;

    private Sprite BackCard;
    private Sprite FrontCard;

    private GameObject Manager;

    private void Start()
    {
        state = 0;
        Manager = GameObject.FindGameObjectWithTag("GameManager");
    }

    public void SetUpGraphics()
    {
        BackCard = Manager.GetComponent<GameManager>().GetCardBack();
        FrontCard = Manager.GetComponent<GameManager>().getFrontCard(CardValue);

        FlipCard();
    }

    public void FlipCard()
    {
        if (state == 0 && !Do_not)
        {
            GetComponent<Image>().sprite = BackCard;
        }
        else if (state == 1 && !Do_not)
        {
            GetComponent<Image>().sprite = FrontCard;
        }
    }

    public int CardValueFunction
    {
        get { return CardValue; }
        set { CardValue = value; }
    }

    public int stateFunction
    {
        get { return state; }
        set { state = value; }
    }

    public bool Initialize
    {
        get { return initialized; }
        set { initialized = value; }
    }

    public void FalseCheck()
    {
        StartCoroutine(Pause());
    }

    private IEnumerator Pause()
    {
        yield return new WaitForSeconds(1);
        if (state == 0)
        {
            GetComponent<Image>().sprite = BackCard;
        }
        else if (state == 1)
        {
            GetComponent<Image>().sprite = FrontCard;
        }
        Do_not = false;
    }
}