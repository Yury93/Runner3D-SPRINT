using System;
using System.Collections;
using UnityEngine;

public class RunnerModes : MonoBehaviour
{
    public enum State
    {
        idle,
        run,
        jump,
        fall
    }
    [SerializeField] State mode = State.idle;
    [SerializeField] private float speed;
    public float Speed => speed;
    private float startSpeed;
    public void SpeedController(float newSpeed)
    {
        speed = newSpeed;
    }
    [SerializeField] private float jump;
    [SerializeField] private float gravity;
    [SerializeField] private CharacterController character;
    /// <summary>
    /// дистанция на которую мы отходим назад при падении
    /// </summary>
    [SerializeField] private float distanceBack;
    [SerializeField] private bool playModeObstacle;

    void Update()
    {
        if (playModeObstacle)
        {
            StateUpdate();
        }
        else if (mode == State.run && !playModeObstacle)
        {
            if(speed > 3)
            {
                speed -= Time.deltaTime / 15;
            }
            character.Move(new Vector3(0, gravity * Time.deltaTime, speed * Time.deltaTime));
        }
    }
    public void StateUpdate()
    {
        if (mode == State.idle)
        {
            character.Move(new Vector3(0, gravity * Time.deltaTime, 0));
            return;
        }
        else if (mode == State.run)
        {
            character.Move(new Vector3(0, gravity * Time.deltaTime, speed * Time.deltaTime));
        }
        else if (mode == State.jump)
        {
            character.Move(new Vector3(0, jump * Time.deltaTime, speed / 1.2f * Time.deltaTime));
        }
        else if (mode == State.fall)
        {
            character.Move(new Vector3(0, 0, distanceBack * Time.deltaTime));
        }
    }
    public void StateController(string state)
    {
        if(state == "idle")
        {
            mode = State.idle;
        }
        if (state == "run")
        {
            mode = State.run;
            startSpeed = speed;
        }
        if (state == "jump")
        {
            mode = State.jump;
        }
        if(state == "fall")
        {
            speed = startSpeed;
            mode = State.fall;
        }
    }
    public void ClickSpeedAdd(float AddSpeed)
    {
        speed += AddSpeed;
    }
    public void PlayModeObstacle(bool obstacleActive)
    {
        playModeObstacle = obstacleActive;
    }
}
