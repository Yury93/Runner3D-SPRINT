using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] private int indexScene;

    public void LoadingScene()
    {
        SceneManager.LoadScene(indexScene);
    }
}
