using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aidbox : MonoBehaviour
{
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip BoxCollected;
    // Start is called before the first frame update

    private int heal= 5;

    void Update()
    {
        transform.Rotate(new Vector3(0f, 45f * Time.deltaTime, 0f));

    }

    void OnTriggerEnter(Collider other)
    {
        soundSource.PlayOneShot(BoxCollected);
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (other.gameObject.name == "Player")
        {
         player.Heal(heal);
        }
        Destroy(this.gameObject);
    }

}


    

