using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsLogic : MonoBehaviour
{
    public static int EnemyPoints = 0;
    public static int PlayerPoints = 0;

    public static float timeRemaining = 20;
    // [SerializeField] int goalsToScore = 2;
    float totalTime;
    Component textObjectPoints;
    Component timer;
    Component initialAndFinalText;
    Image imageObject;
    AudioSource audioTicking;
    void Start()
    {
        textObjectPoints = GetComponentInChildren<TextMesh>();
        audioTicking = GetComponent<AudioSource>();
        timer = gameObject.transform.Find("Timer");
        initialAndFinalText = gameObject.transform.Find("Results");
        initialAndFinalText.gameObject.SetActive(false);
        imageObject = timer.GetComponent<Image>();
        totalTime = timeRemaining;
    }

    void Update()
    {
        string result = PlayerPoints.ToString() + " : " + EnemyPoints.ToString();
        textObjectPoints.GetComponent<TextMesh>().text = result;
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            imageObject.fillAmount = timeRemaining / totalTime;
            if (timeRemaining < 5 && !audioTicking.isPlaying)
            {
                audioTicking.Play();
            }
        }
        else
        {
            if (PlayerPoints > EnemyPoints)
            {
                initialAndFinalText.gameObject.GetComponent<TextMesh>().text = "YOU WIN!";
                PlayerPrefs.SetString("won", "true");
            }
            else if (PlayerPoints == EnemyPoints)
            {
                initialAndFinalText.gameObject.GetComponent<TextMesh>().text = "IT'S A TIE!";
            }
            else
            {
                initialAndFinalText.gameObject.GetComponent<TextMesh>().text = "YOU LOST!";
            }
            initialAndFinalText.gameObject.SetActive(true);
            if (!PlayerPrefs.HasKey("best") || PlayerPrefs.GetInt("best") < PlayerPoints)
            {
                PlayerPrefs.SetInt("best", PlayerPoints);
            }
            Invoke("returnToTheOffice", 5f);
        }
    }

    void returnToTheOffice()
    {
        EnemyPoints = 0;
        PlayerPoints = 0;
        timeRemaining = 20;
        Initiate.Fade("Level1", Color.black, 5f);
    }
}
