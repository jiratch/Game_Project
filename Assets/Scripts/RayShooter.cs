using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;

public class RayShooter : MonoBehaviour {
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip hitWallSound;
    [SerializeField] AudioClip hitEnemySound;
    public GameObject dust;
    public GameObject shot;

    

    public Texture2D t;
    private Camera _camera;

  
    void Start() {

       

        _camera = GetComponent<Camera>();
        


        //Cursor.lockState = CursorLockMode.Locked;



    }

     
   /* void OnGUI() {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX - 19, posY - 19, t.width / 10, t.height / 10), t);
    }*/


	void Update() {
		if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
			Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
			Ray ray = _camera.ScreenPointToRay(point);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
				if (target != null) {
                 
                    target.ReactToHit();
                    Instantiate(shot, hit.point, this.gameObject.transform.rotation);

                    soundSource.PlayOneShot(hitEnemySound);
					Messenger.Broadcast(GameEvent.ENEMY_HIT);
				} else {
                    Instantiate(dust, hit.point, this.gameObject.transform.rotation);
                 //   StartCoroutine(SphereIndicator(hit.point));
                    soundSource.PlayOneShot(hitWallSound);
                }
			}
		}
	}

    
       
     


    private IEnumerator SphereIndicator(Vector3 pos) {
        
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.position = pos;

		yield return new WaitForSeconds(1);
      

        Destroy(sphere);
	}
}