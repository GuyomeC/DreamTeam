using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{

    public float currentScore = 0f;
    public float bestScore;
    [SerializeField] private TextMeshProUGUI scoreUI;
    public bool IsPlaying;

    void Start()
    {
        IsPlaying = true;
    }

    void Update()
    {
        if (IsPlaying)
        {
            currentScore += Time.deltaTime;
        }
        else
        {
            bestScore = currentScore;
            currentScore = 0;
        }
    }

    public string PrettyScore()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }

    private void OnGUI()
    {
        scoreUI.text = PrettyScore();
    }
}
