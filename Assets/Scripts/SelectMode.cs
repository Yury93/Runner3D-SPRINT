using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMode : SingletonBase<SelectMode>
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject[] gameObjectsScene;
    [SerializeField] private RunnerModes player;
    [SerializeField] private GameObject PumpingPlayer;
    private void Awake()
    {
        Time.timeScale = 0.000001f;
        for (int i = 0; i < gameObjectsScene.Length; i++)
        {
            gameObjectsScene[i].SetActive(false);
        }
        PumpingPlayer.SetActive(false);
    }
    public  void OnObstacle()
    {
        PumpingPlayer.SetActive(true);
        for (int i = 0; i < gameObjectsScene.Length; i++)
        {
            gameObjectsScene[i].SetActive(true);
        }
        player.SpeedController(3.4F);
        gameManager.OnObstacles();
        Time.timeScale = 1;
        Destroy(gameObject);
        
    }
    public void OffObstacle()
    {
        PumpingPlayer.SetActive(true);
        for (int i = 0; i < gameObjectsScene.Length; i++)
        {
            gameObjectsScene[i].SetActive(true);
        }
        player.SpeedController(4F);
        gameManager.OffObstacles();
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
