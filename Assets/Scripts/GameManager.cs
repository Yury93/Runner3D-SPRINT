using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonBase<GameManager>
{
    [Header("StartGameTime")]
    [SerializeField] private float startTimeGame;
    [SerializeField] private AIController[] enemys;
    

    [Header("Modes Game")]
    [SerializeField] private GameObject obstales;
    [SerializeField] private RunnerModes player;

    [Header("DarkSreen of false")]
    [SerializeField] private Animator imageDarkScreen;
    [SerializeField] private StateController stateController;
    [SerializeField] private GameObject idleButton, jumpButton, runButton,accelerationButton;


    private void Awake()
    {
        StartGamePlayer();
    }
    private void Start()
    {
        stateController.OnFalse += ImageActiveFalse;
    }
    public void StartGamePlayer()
    {
        for (int i = 0; i < enemys.Length; i++)
        {
            enemys[i].StartRunEnemies(startTimeGame);
        }
    }

    #region EditFalse
    public void ImageActiveFalse()
    {
        //idleButton.SetActive(false);
        jumpButton.SetActive(false);
        runButton.SetActive(false);
        accelerationButton.SetActive(false);

        StartCoroutine(CorButtonActive());

        imageDarkScreen.SetTrigger("DarkScreen");
        IEnumerator CorButtonActive()
        {
            yield return new WaitForSeconds(2f);
            //idleButton.SetActive(false);
            jumpButton.SetActive(true);
            runButton.SetActive(true);
            accelerationButton.SetActive(true);
        }
    }
    #endregion
    #region ModesGame
    public void OffObstacles()
    {
        obstales.SetActive(false);
        player.PlayModeObstacle(false);
    }
    public void OnObstacles()
    {
        obstales.SetActive(true);
        player.PlayModeObstacle(true);
    }
    #endregion
}
