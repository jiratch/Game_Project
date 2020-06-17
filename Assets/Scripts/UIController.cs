using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour {
	
	[SerializeField] private SettingsPopup settingsPopup;

    //[SerializeField] private AudioSource music;
   // [SerializeField] private AudioClip m;
    private int _score;
    
    void Awake() {
		Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
	}
	void OnDestroy() {
		Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
	}

	void Start() {
	

		settingsPopup.Close();
	}

	private void OnEnemyHit() {
	
	}

	public void OnOpenSettings() {
		settingsPopup.Open();
        Cursor.visible = true;


    }

   /* public void OnPlaymusic() {
        music.PlayOneShot(m);
    }

    public void OnStopmusic() {
        music.Stop();
    }*/


    public void Closepop()
    {
        settingsPopup.Close();
        Cursor.visible = false;
    }

    public void OnPointerDown() {
		Debug.Log("pointer down");
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {

            settingsPopup.Open();
         //   Cursor.lockState = CursorLockMode.Locked;
         
        }
    }
}
