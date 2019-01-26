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
    private void OnTriggerStay(Collider col)
    {

        if(col.GetComponent<Player>().bIsMining)
        {
            MineAsteroid();    
        }
    }

    void MineAsteroid()
    {
        if(!isCoolingDown)
        {
            if(asteroidHealth<=0)
            {
                Instantiate(dropObject, transform.position, Quaternion.identity);
                Destroy(gameObject);
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
