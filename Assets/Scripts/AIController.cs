using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private StateController stateController;
    private Obstacle obstacle;
    [SerializeField] private float distance;
    private float startRunTime;

    private void Start()
    {
        obstacle = null;

        StartCoroutine(CorStartGame());
        IEnumerator CorStartGame()
        {
            yield return new WaitForSeconds(startRunTime);
            stateController.RunAnimate();
        }
    }
    private void Update()
    {
        if (obstacle)
        {
            stateController.JumpAnimate();
            obstacle = null;
        }
    }
    private void FixedUpdate()
    {
        if (!obstacle)
        {
            RaycastHit hit;

            if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z)
                , Vector3.forward, out hit, distance))
            {
                obstacle = hit.collider.GetComponent<Obstacle>();
            }
        }
        if (timer <= 0)
        {
            distance = 0;
        }
        if(timer > 0)
        {
            distance = 2.12f;
            timer -= Time.fixedDeltaTime;
        }
    }
    /// <summary>
    /// Обновляем время, которое отвечает за выбор AI дистанции
    /// В инспекторе будет отвечать кнопка Jump
    /// </summary>
    /// <param name="timeUpdate"></param>
    public void UpdateTimer()
    {
        timer += 5f;
    }
    public void StartRunEnemies(float time)
    {
        startRunTime = time;
    }
}
