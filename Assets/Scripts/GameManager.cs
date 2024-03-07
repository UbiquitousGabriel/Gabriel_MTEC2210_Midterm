using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject pearlPrefab;
    public GameObject bombPrefab;
    public GameObject hazardPrefab;
    public Transform northPoint;
    public Transform southPoint;
    public Transform westPoint;
    public Transform eastPoint;

    public AudioSource audioSource;
    public AudioClip ScreamAudio;

    public int score;
    public TextMeshPro scoreText;

    [Range (1,10)] public int cointCount = 5;
    private void Start()
    {
        //SpawnCoin();
        InvokeRepeating("SpawnPearl", 2, 2);
        InvokeRepeating("SpawnBomb", 2, 2);
        InvokeRepeating("SpawnHazard", 2, 2);

    }

    public void SpawnPearl()
    {
        GameObject pearlClone = Instantiate(pearlPrefab, SpawnPos(), Quaternion.identity);
    }

    public void SpawnBomb()
    {
        GameObject bombClone = Instantiate(bombPrefab, SpawnPos(), Quaternion.identity);
    }

    public void SpawnHazard()
    {
        GameObject hazardClone = Instantiate(hazardPrefab, SpawnPos(), Quaternion.identity);
    }


    private Vector2 SpawnPos()
    {
        float xValue = Random.Range(westPoint.position.x, eastPoint.position.x);
        float yValue = Random.Range(northPoint.position.y, southPoint.position.y);
        Vector2 temp = new Vector2(xValue, yValue);
        //return Camera.main.ScreenToWorldPoint(temp);

        return temp;
    }

    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    public void IncreaseScore()
    {
        score += 1;
    }
}
