using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerStartGame : MonoBehaviour
{
    [SerializeField] private Text textStartGame;
    [SerializeField] private GameObject[] buttonUIPlayer;
    void Start()
    {
        for (int i = 0; i < buttonUIPlayer.Length; i++)
        {
            buttonUIPlayer[i].gameObject.SetActive(false);
        }
        StartCoroutine(CorStartGame());
        IEnumerator CorStartGame()
        {
            yield return new WaitForSeconds(0.01f);
            textStartGame.text = "5";
            yield return new WaitForSeconds(1f);
            textStartGame.text = "4";
            yield return new WaitForSeconds(1f);
            textStartGame.text = "3";
            yield return new WaitForSeconds(1f);
            textStartGame.text = "2";
            yield return new WaitForSeconds(1f);
            textStartGame.text = "1";
            yield return new WaitForSeconds(1f);
            textStartGame.enabled = false;
            for (int i = 0; i < buttonUIPlayer.Length; i++)
            {
                buttonUIPlayer[i].gameObject.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
