﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PLay(string scencename) {
        SceneManager.LoadScene(scencename);

    }
    public void Exit() {
        Application.Quit();


    }
}