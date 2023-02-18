using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using utils;

public class GameManager : MonoBehaviour
{
    [SerializeField] MonoBehave monoBehaveScript;
    [SerializeField] GameObject player;
    void Start()
    {
        StaticMethod.MonoBehave = monoBehaveScript;
    }

    public void FixedUpdate() {
        if (player == null) SceneManager.LoadScene(0);
    }

}
