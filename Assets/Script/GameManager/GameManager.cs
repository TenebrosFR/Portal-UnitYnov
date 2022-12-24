using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using utils;

public class GameManager : MonoBehaviour
{
    [SerializeField] MonoBehave monoBehaveScript;
    void Start()
    {
        StaticMethod.MonoBehave = monoBehaveScript;
    }

}
