using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    /*[SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip Gametheme;*/


    void Start()
    {
        Cursor.visible = false;
      //  soundSource.PlayOneShot(Gametheme);
    }
    
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            Cursor.visible = false;
        }
        if (Input.GetKeyDown("m"))
        {
            Cursor.visible = true;
        }
    }
}
