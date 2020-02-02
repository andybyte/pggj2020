using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillController : MonoBehaviour
{
    Animator animator;
    public GameObject petals;
    public GameObject gc;
    public float energy;

    public GameObject dustcloud;

    AudioSource audioData;

    bool warned;

    

    // Start is called before the first frame update
    void Start()
    {
        animator = petals.GetComponent<Animator>();

        InvokeRepeating("UseEnergy", 3.0f, 1.0f);

        audioData = GetComponent<AudioSource>();

        warned = false;
        
    }

    void UseEnergy () 
    {
        if (energy>0)
        {
            energy -= 1; //Use energy
            gc.GetComponent<GameController>().AddPoints(1);
        } else {
            animator.SetFloat("State",0);
            dustcloud.SetActive(false);

            if(warned==false)
            {
                audioData.Play(0);
                warned = true;
            }
                
        }
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
    
    // Update is called once per frame
    // void Update () {
    //     float h = Input.GetAxis("Horizontal");
    //     float v = Input.GetAxis("Vertical");
    //     bool fire = Input.GetButtonDown("Fire1");

    //     animator.SetFloat("Forward",v);
    //     animator.SetFloat("Strafe",h);
    //     animator.SetBool("Fire", fire);
    // }

    void OnCollisionEnter2D(Collision2D  collision) 
     {
        Collider2D collider = collision.collider;

        Debug.Log(collider.gameObject.tag);
        
        if(collider.gameObject.tag == "energy")
        {
            animator.SetFloat("State",1);
            dustcloud.SetActive(true);
            audioData.Play(1);
            warned = false;
            float takeenergy = collision.gameObject.GetComponent<EnemyScript>().GetEnergyLevel();
            Debug.Log("here is " + takeenergy);
            energy+=takeenergy;
            Destroy(collision.gameObject);
        }
    }
}