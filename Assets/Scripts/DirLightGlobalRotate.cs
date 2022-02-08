using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirLightGlobalRotate : MonoBehaviour
{
    [SerializeField] private float speed;
  
    void Update()
    {
        transform.Rotate(speed * Time.deltaTime, 0, 0);
    }
}
