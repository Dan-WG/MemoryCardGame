using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Sprite[] Cardfaces;
    public Sprite BackCard;

    public GameObject[] Cards;
    public Text MatchText;

    private bool init = false;
    private int matches = 48;

    private void Update()
    {
        if (!init)
        {
            InitializeCards();
        }
        if (Input.GetMouseButtonUp(0))
        {
            CheckCards();
        }
    }

    private void InitializeCards()
    {
        for (int id = 0; id < 2; id++)
        {
            for (int i = 0; i < 48; i++)
            {
                bool test = false;
                int choice = 0;
                while (!test)
                {
                    choice = Random.Range(0, Cards.Length);
                    test = !(Cards[choice].GetComponent<CardScript>().initialized);
                }
                Cards[choice].GetComponent<CardScript>().CardValue = 1;
                Cards[choice].GetComponent<CardScript>().initialized = true;
            }
        }
        foreach (GameObject c in Cards)
        {
            c.GetComponent<CardScript>().SetUpGraphics();
        }
        if (!init)
        {
            init = true;
        }
    }

    public Sprite GetCardBack()
    {
        return BackCard;
    }

    public Sprite getFrontCard(int i)
    {
        return Cardfaces[i - 1];
    }

    private void CheckCards()
    {
        List<int> c = new List<int>();

        for (int i = 0; i < Cards.Length; i++)
        {
            if (Cards[i].GetComponent<CardScript>().state == 1)
            {
                c.Add(i);
            }
        }
        if (c.Count == 2)
        {
            CardComparison(c);
        }
    }

    private void CardComparison(List<int> c)
    {
        CardScript.Do_not = true;

        int x = 0;

        if (Cards[c[0]].GetComponent<CardScript>().CardValue == Cards[c[1]].GetComponent<CardScript>().CardValue)
        {
            x = 2;
            matches--;
            MatchText.text = "Matches remaining: " + matches;
            if (matches == 0)
            {
                SceneManager.LoadScene("Menu");
            }
        }

        for (int i = 0; i < c.Count; i++)
        {
            Cards[c[i]].GetComponent<CardScript>().state = x;
            Cards[c[0]].GetComponent<CardScript>().FalseCheck();
        }
    }
}