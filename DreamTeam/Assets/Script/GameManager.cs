using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{

    public float currentScore = 0f;
    [SerializeField] private TextMeshProUGUI scoreUI;


    void Start()
    {
        
    }

    void Update()
    {
        currentScore += Time.deltaTime;
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
