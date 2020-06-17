using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {
	public float speed = 20.0f;
	public int damage = 3;
    

    void Update() {
      
        transform.Translate(0, 0, speed * Time.deltaTime);

    }

    void OnTriggerEnter(Collider other) {
		PlayerCharacter player = other.GetComponent<PlayerCharacter>();
		if (player != null) {
			player.Hurt(3);
		}
		Destroy(this.gameObject);
	}
}
