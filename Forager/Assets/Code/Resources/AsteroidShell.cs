using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AsteroidShell : MonoBehaviour {

    public Slider sliderComp;
    private Player playerScript;
    public float asteroidHealth=20;
    private bool isCoolingDown;
    public GameObject dropObject;
    public GameObject explosion;
    private bool bIsDead;
    private void Awake()
    {
        sliderComp.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.GetComponent<Player>())
        {
            sliderComp.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider col)
    {

        if(col.GetComponent<Player>())
        {
            if(col.GetComponent<Player>().bIsMining)
                MineAsteroid();
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.GetComponent<Player>())
        {
            sliderComp.gameObject.SetActive(false);
        }
    }

    void MineAsteroid()
    {
        if(!isCoolingDown)
        {
            if(asteroidHealth<=0)
            {
                Instantiate(dropObject, transform.position, Quaternion.identity);
                Instantiate(explosion, transform.position,Quaternion.identity);
                if(!bIsDead)
                {
                    bIsDead = true;
                    GetComponent<PlayAudio>().PlayThisAudio("asteroidExplosion");
                }
                GetComponent<Collider>().enabled = false;
                Destroy(gameObject,1.5f);
            }
            else
            {
                asteroidHealth -= 1;
                sliderComp.value = asteroidHealth;
                isCoolingDown = true;
                StartCoroutine(MineCooldown());
                
            }
            
        }
    }

    IEnumerator MineCooldown()
    {
        yield return new WaitForSeconds(0.2f);
        isCoolingDown = false;
    }

}
