using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] ferryPrefabs;
    public Vector2 spawnRateRange;
    float spawnTimer;
    
    
    public Text scoreText;
    int score;

    public GameObject gameOverPanel;
    
    
    void Start()
    {
        for(int i=0; i<8; i++)
        {
            SpawnNewFerry();
        }

        gameOverPanel.SetActive(false);
    }

    
    void Update()
    {
        spawnTimer-=Time.deltaTime;

        if(spawnTimer < 0)
        {
            SpawnNewFerry();
            spawnTimer = Random.Range(spawnRateRange.x,spawnRateRange.y);
        }
    }


    void SpawnNewFerry()
    {
        GameObject ferryToSpawn = ferryPrefabs[Random.Range(0,ferryPrefabs.Length)];
        int dir = Random.value > 0.5? 1 : -1;
        Vector2 randomSpawnPos = new Vector2(dir * 7f,Random.Range(-4.7f,4.7f));

        GameObject ferry = Instantiate(ferryToSpawn,randomSpawnPos,Quaternion.identity);
        //Quaternion.identity is for the rotaion of the spawn ferry
        ferry.GetComponent<Friends>().SpawnFerry();

        if(dir == 1 )
        ferry.transform.Rotate(Vector3.up,180f);
    }

    public void GainScore(int amount)
    {
        score += amount;
        string zero = "000000";
        scoreText.text = zero.Substring(0, zero.Length - score.ToString().Length) + score; 
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void ReloadScene()
    {
         SceneManager.LoadScene(0); 
    }

}
