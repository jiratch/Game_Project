using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReactiveTarget : MonoBehaviour {
    public GameObject Boom;
    private Animator a;
    public static int second;
    [SerializeField] private Text KillLabel;


    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip Explode;


    public void Start()
    {
       
        a = GetComponent<Animator>();
    }
    public void ReactToHit() {
		WanderingAI behavior = GetComponent<WanderingAI>();
       if (behavior != null) {
			behavior.SetAlive(false);

           
        }


        StartCoroutine(Die());
      a.SetBool("Takedamage",true);
	}

	private IEnumerator Die() {
        
        this.transform.Rotate(-35, 0, 0);
        yield return new WaitForSeconds(1.175f);
        soundSource.PlayOneShot(Explode);
        Instantiate(Boom, this.gameObject.transform.position, this.gameObject.transform.rotation);
             
        Destroy(this.gameObject);
        GameVariables.kill += 1;
    
        KillLabel.text = GameVariables.kill.ToString();
  
       
    //    Debug.log("kill = "+ GameVariables.kill);
       

    }
    
}
