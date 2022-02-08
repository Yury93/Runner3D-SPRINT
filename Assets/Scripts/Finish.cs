using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private int indexLoadScene;
    [SerializeField] private List<string> names;
    [SerializeField] private MenuPumping menuPumping;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<NameRunner>())
        {
            StartCoroutine(CorIdleAnimate());
            IEnumerator CorIdleAnimate()
            {
                yield return new WaitForSeconds(Random.Range(2F,4F));
                other.gameObject.GetComponent<StateController>().IdleAnimate();
            }
            var  nameRun = other.gameObject.GetComponent<NameRunner>();
            names.Add(nameRun.RunnerName);
        }
        if(names.Count == 5)
        {
            print("турнир окончен");
            StartCoroutine(CorFinish());
        }
    }
    IEnumerator CorFinish()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < names.Count; i++)
        {
            if(names[0] == "Semen")
            {
                menuPumping.SetScore(1);
            }
            if (names[1] == "Semen")
            {
                menuPumping.SetScore(4);
            }
            if (names[2] == "Semen")
            {
                menuPumping.SetScore(6);
            }
            if (names[3] == "Semen")
            {
                menuPumping.SetScore(8);
            }
            if (names[4] == "Semen")
            {
                menuPumping.SetScore(10);
            }
        }
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(indexLoadScene);
    }
}
