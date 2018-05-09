using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manage : MonoBehaviour
{


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
    }

    //implementation
    private static Manage instance;
    public static Manage Instance
    {
        get
        {
            if (instance == null)
                instance = new Manage();

            return instance;
        }
    }

    protected Manage()
    {
    }

    private float score = 0;


    public void Scoreazero()
    {
        score = 0;
        TextmiseajourScore();
    }

    public void definiScore(float valeur)
    {
        score = valeur;
        TextmiseajourScore();
    }

    public void ajourScore(float valeur)
    {
        score += valeur;
        TextmiseajourScore();
    }

    private void TextmiseajourScore()
    {
        TextduScore.text = score.ToString();
    }

    public void SetStatus(string text)
    {
        TextStatus.text = text;
    }

    public Text TextduScore, TextStatus;
}
