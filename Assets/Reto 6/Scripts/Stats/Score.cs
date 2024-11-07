using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public float score;
    public float multiplier = 2;

    [Header("UI")]
    public TextMeshProUGUI scoreText;

    void Update()
    {
        //score += ;
        AddScore(Time.deltaTime * multiplier);

        UpdateUI();
    }

    private void AddScore(float score)
    {
        this.score += score;
    }


    private void UpdateUI()
    {
        scoreText.text = ((int)score).ToString();
    }
}
