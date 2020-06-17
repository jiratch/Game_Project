using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
   // [SerializeField] private SettingsPopup Finishpop;
    [SerializeField] private SettingsPopup Nokeypop;

    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip Finish;

    public bool Isfinish = false;


    float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Finishpop.Close();
        Nokeypop.Close();
    }

    // Update is called once per frame
    void Update()
    {
        if (Isfinish == true)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);

        }
        
        

    }


    private void Closepop()
    {
        Nokeypop.Close();
    }

    private void OnTriggerEnter(Collider Collider)
    {
        if (Collider.gameObject.name == "Player" && GameVariables.keycount > 0)
        {
           
            
          //  Finishpop.Open();
            Isfinish = true;
            Cursor.visible = true;
            soundSource.PlayOneShot(Finish);



        }
        else if (Collider.gameObject.name == "Player" && GameVariables.keycount == 0)
        {

            Nokeypop.Open();

            //  nokey.text = "YOU DON'T HAVE A KEY";

             Invoke("Closepop",2.0f);

        }


    }


}
