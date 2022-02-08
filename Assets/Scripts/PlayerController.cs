using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private StateController player;
    [SerializeField] private Button jump, run,idle;
    [SerializeField] private RunnerModes runnerModes;
    [SerializeField] private float clickSpeedAdd;
    public float ClickSpeedAdd => clickSpeedAdd;

    private void Start()
    {
        player.OnIdle += PlayerIdle;
        player.OnRun += PlayerRun;
        player.OnJump += PlayerJump;
        player.OnFalse += PlayerFalse;

        jump.interactable = false;
        //idle.gameObject.SetActive(false);
    }

    private void PlayerIdle()
    {
        jump.interactable = false;
        run.interactable = true;
    }

    private void PlayerRun()
    {
        run.interactable = false;
        
        StartCoroutine(CorJumpButtonActivate());
    }

    private void PlayerJump()
    {
        jump.interactable = false;
        run.interactable = false;
    }

    private void PlayerFalse()
    {
        jump.interactable = false;
    }
    public void SpeedAdd()
    {
        runnerModes.ClickSpeedAdd(clickSpeedAdd);
    }
    IEnumerator CorJumpButtonActivate()
    {
        yield return new WaitForSeconds(0.4f);
        jump.interactable = true;
    }
    public void SetSpeedAdd(float addSpeed)
    {
        clickSpeedAdd = addSpeed;
    }
}
