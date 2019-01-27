using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {
    // Singleton instance 
    [SerializeField]
    public static AudioController instance;

    [SerializeField]
    [Header("Player Dashing")]
    public AudioSource playerDashing;
    public float hitDelay;
    public float maxHitDelay;
    [SerializeField]
    [Header("Player Digging")]
    public AudioSource playerDigSrc;
    public float absorbDelay = 0.5f;
    [SerializeField]
    [Header("Asteroid Explosion")]
    public AudioSource asteroidExplosion;
    public float deathDelay = 0.5f;
    [SerializeField]
    [Header("oreCollectedSrc")]
    public AudioSource oreCollectedSrc;
    public float dash1Delay = 0.5f;
    [SerializeField]
    [Header("SpaceStation Reached")]
    public AudioSource spaceStationReachedSrc;
    public float HealthUpDelay = 0.5f;

    [Header("Explosion")]
    public AudioSource playerDeath;

    // Use this for initialization
    void Start () {
        instance = this;
	}
    public void PlayerDashing(Vector3 pos)
    {
        if (playerDashing != null)
        {
            playerDashing.pitch = Random.Range(0.8f, 1f);
            playerDashing.volume = Random.Range(0.8f, 1f);

            playerDashing.loop = false;
            playerDashing.Play();

         
        }
    }

    public void PlayerDigSrc(Vector3 pos)
    {
        if (playerDigSrc != null)
        {
            
            playerDigSrc.volume = 0.5f;
            playerDigSrc.loop = false;
            playerDigSrc.Play();

         
        }
    }

    public void OreCollectedSrc(Vector3 pos)
    {
        if (oreCollectedSrc != null)
        {
            oreCollectedSrc.transform.position = pos;

            oreCollectedSrc.loop = false;
            oreCollectedSrc.Play();

         
        }
    }



    public void PlayerDeath(Vector3 pos)
    {
        if (playerDeath != null)
        {

            playerDeath.transform.position = pos;
            playerDeath.loop = false;
            playerDeath.Play();
        }
    }


    public void SpaceStationReachedSrc(Vector3 pos)
    {
        if (spaceStationReachedSrc != null)
        {
            spaceStationReachedSrc.transform.position = pos;
            spaceStationReachedSrc.loop = false;
            spaceStationReachedSrc.Play();
        }
    }
    public void AsteroidExplosion(Vector3 pos)
    {
        if (asteroidExplosion != null)
        {
            asteroidExplosion.transform.position = pos;
            asteroidExplosion.loop = false;
            asteroidExplosion.Play();
        }
    }
    public void PlayerExplosion(Vector3 pos)
    {
        if (playerDeath != null)
        {
            playerDeath.transform.position = pos;
            playerDeath.loop = false;
            playerDeath.Play();
        }
    }
}
