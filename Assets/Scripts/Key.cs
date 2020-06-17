using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip keyCollected;
  

    // Update is called once per frame
    void Update()
     {
         transform.Rotate(new Vector3(0f, 45f * Time.deltaTime, 0f));

     }
     
    private void OnTriggerEnter(Collider Collider)
    {
        if (Collider.gameObject.name == "Player")
        {

            GameVariables.keycount = GameVariables.keycount + 1;
         

            soundSource.PlayOneShot(keyCollected);
            Destroy(this.gameObject);
        }


    }
}