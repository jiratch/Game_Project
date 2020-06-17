using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeasureBox : MonoBehaviour
{
    [SerializeField] private SettingsPopup Finishpop;
    
    // Start is called before the first frame update
    void Start()
    {
        Finishpop.Close();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider Collider)
    {
        if (Collider.gameObject.name == "Player" && GameVariables.keycount > 0)
        {
            Finishpop.Open();
        }
        Destroy(this.gameObject);

    }
}
