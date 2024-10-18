using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }


    public float currentScore = 0f;
    public float bestScore;
    [SerializeField] private TextMeshProUGUI scoreUI;
    public bool IsPlaying;

    [SerializeField] private GameObject startMenuUI;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

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

    public void StartGame()
    {
        Destroy(startMenuUI);
        IsPlaying = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
