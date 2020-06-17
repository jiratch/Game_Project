using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SettingsPopup : MonoBehaviour {
	
 
	
	void Start() {
		//speedSlider.value = PlayerPrefs.GetFloat("speed", 1);
	}

	public void Open() {
		gameObject.SetActive(true);
	}
	public void Close() {
		gameObject.SetActive(false);
	}

	public void OnSubmitName(string name) {
		Debug.Log(name);
	}


    public void Restart(string scencename)
    {
        SceneManager.LoadScene(scencename);

    }

    public void NextLevel(string scencename)
    {
        SceneManager.LoadScene(scencename);

    }

    public void BacktoMainMenu(string scencename)
    {
        SceneManager.LoadScene(scencename);

    }
    public void Exit()
    {
        Application.Quit();


    }

   
}
