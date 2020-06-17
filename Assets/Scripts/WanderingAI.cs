using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class WanderingAI : MonoBehaviour
{

    public const float baseSpeed = 2.0f;

    public Transform target;
    private bool Isfound;


    public float speed = 2.0f;
    public float obstacleRange = 5.0f;
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip FireballSound;

    private Animator animator;

    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;
    private float second;

    private bool _alive;

    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    void Start()
    {
        _alive = true;
        animator = GetComponent<Animator>();
        Isfound = false;
    }

    void Update()
    {



        if (_alive)
        {

            if (!Isfound)
            {

                transform.Translate(0, 0, speed * Time.deltaTime);
            }

            if (Isfound == true)
            {
                transform.LookAt(target);
                transform.Translate(Vector3.forward * Time.deltaTime);
            }

            //	Ray ray = new Ray(transform.position, transform.forward);
            Ray ray = new Ray(transform.TransformPoint(new Vector3(0, 1, 0)), transform.forward);
            Ray rayR = new Ray(transform.TransformPoint(new Vector3(0, 1, 0)), transform.right);
            //  Ray rayL = new Ray(transform.TransformPoint(new Vector3(0, 1, 0)), transform.left);

            RaycastHit hit;

            if (Physics.SphereCast(rayR, 0.055f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {

                    Isfound = true;
                }
            }

            if (Physics.SphereCast(ray, 0.035f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {

                    Isfound = true;
                    animator.SetBool("Foundtarget", true);
                    soundSource.PlayOneShot(FireballSound);
                    if (_fireball == null && Isfound == true)
                    {

                        if (second == 0)
                        {
                            //ShootFireball();
                            //Invoke("ShootFireball",1.5f);
                            _fireball = Instantiate(fireballPrefab) as GameObject;
                            //_fireball.transform.position = transform.TransformPoint(Vector3.forward * 3.0f);
                            _fireball.transform.position = transform.TransformPoint(new Vector3(0, 1, 4));
                            _fireball.transform.rotation = transform.rotation;
                        }
                        second = second + Time.deltaTime;
                        if (second == 3) {
                            second = 0f;

                        }
                    }
                }
                else
                {
                    Isfound = false;
                }
            }

            else if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                animator.SetBool("Foundtarget", false);
                transform.Rotate(0, angle, 0);

                //  CancelInvoke("ShootFireball");
            }
            }
        }
    
   
    public void SetAlive(bool alive)
    {
        _alive = alive;
    }

    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
    }
  
}
