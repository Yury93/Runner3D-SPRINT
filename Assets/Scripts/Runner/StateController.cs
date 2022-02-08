using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RunnerModes))]
public class StateController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private RunnerModes runnerModes;
    [SerializeField] private float timeJump;
    [SerializeField] private float timeFall;
    /// <summary>
    /// время корутины после которого мы бежим если стоим 
    /// </summary>
    [SerializeField] private float timeIdle;

    public  Action OnJump;
    public  Action OnIdle;
    public  Action OnRun;
    public  Action OnFalse;

    private void Awake()
    {
        runnerModes = GetComponent<RunnerModes>();
    }
    public void IdleAnimate()
    {
        OnIdle?.Invoke();
        runnerModes.StateController("idle");
        animator.SetTrigger("Idle");
    }
    public void RunAnimate()
    {
        if (gameObject.name == "Player")
        {
            AudioManager.Instance.PlayRunAudio();
        }
        OnRun?.Invoke();
        runnerModes.StateController("run");
        animator.SetTrigger("Run");
    }
    public void JumpAnimate()
    {
        OnJump?.Invoke();
        StartCoroutine(CorJump());
        runnerModes.StateController("jump");
        animator.SetTrigger("Jump");
    }
    public void FallAnimate()
    {
        if (gameObject.name == "Player")
        {
            AudioManager.Instance.PlayFallAudio();
        }
        
        OnFalse?.Invoke();
        runnerModes.StateController("fall");
        animator.SetTrigger("Fall");
        StartCoroutine(CorIdle());
    }

   
    IEnumerator CorJump()
    {
        yield return new WaitForSeconds(timeJump);
        RunAnimate();
    }
    IEnumerator CorIdle()
    {
        yield return new WaitForSeconds(timeFall);
        IdleAnimate();
        yield return new WaitForSeconds(timeIdle);
        RunAnimate();
    }
}
