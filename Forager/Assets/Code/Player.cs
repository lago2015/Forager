using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    private GameOverManager gameOverScript;
    private int[] materialInventory =new int[4];
	int amountCarrying = 0;
    [HideInInspector]
    public int score = 0;
    public float wallBump=30;
    private float audioDuration;
    [HideInInspector]
    public bool bIsMining;
	public Text inventoryAmountDisplay;
	public Text scoreAmountDisplay;
	public Slider boostDisplay;
    public GameObject explosion;
    public Animator animComp;
    private Vector3 dir;
    private Rigidbody myBody;
    private bool bIsPlayingDash;
    private GameObject dashAudioObject;
    private GameObject deathAudioObject;
    private ObjectPoolManager audioScript;
    // Use this for initialization
    void Start()
    {
        audioScript = GameObject.FindObjectOfType<ObjectPoolManager>();
        InputManager.OnMovementInput += Move;
        InputManager.OnRotationInput += Rotate;
        InputManager.OnDashInput += changeDashingState;
		InputManager.OnMiningInput += Mining;
        //InputManager.onFireInput += OnFireInput;
        inventoryAmountDisplay.text = "Current Amount: " + amountCarrying;
        scoreAmountDisplay.text = "Score: " + score;
        gameOverScript = GameObject.FindGameObjectWithTag("Respawn").GetComponent<GameOverManager>();
        myBody = GetComponent<Rigidbody>();
        audioDuration = 2f;
    }


    private void Update()
    {
        /*if (Input.GetButtonDown("MiningTool"))
        {
            bIsMining = true;
            
        }
        if (Input.GetButtonUp("MiningTool"))
        {
            bIsMining = false;
        }*/
        /*if(Input.GetButtonDown("Fire2"))
        {
            animComp.SetBool("isBursting", true);
        }
        if(Input.GetButtonUp("Fire2"))
        {
            animComp.SetBool("isBursting", false);
        }*/
		if(dashing)
		{
			Dash();
		}
    }

    //storing material count for when player goes back to hub
    public void addMaterial(Collectible.MaterialSources currentMaterial)
    {
        switch(currentMaterial)
        {
            case Collectible.MaterialSources.orb:
                materialInventory[0] += 1;
                break;
            case Collectible.MaterialSources.smallAsteroid:
                materialInventory[1] += 3;
                break;
            case Collectible.MaterialSources.medAsteroid:
                materialInventory[2] += 7;
                break;
            case Collectible.MaterialSources.larAsteroid:
                materialInventory[3] += 15;
                break;
        }
    }
    //adds amount of each material to score then resets the material count
    void MaterialCount()
    {
        for(int i=0;i<=materialInventory.Length-1;i++)
        {
            addScore(materialInventory[i]);
            materialInventory[i] = 0;
        }
    }

	public void addToInventory(int amount)
	{
		amountCarrying += amount;
        inventoryAmountDisplay.text = "Current Amount: " + amountCarrying;
	}
	public int AmountCarrying
	{
		get
		{
			return amountCarrying;
		}
	}
	public void addScore(int amount)
	{
		score += amount;
        scoreAmountDisplay.text = "Score: " + score;
	}
	public void ReachHome()
	{
        if(amountCarrying>0)
        {
            MaterialCount();
        }
		    
		amountCarrying = 0;

        if(inventoryAmountDisplay)
		{
		    inventoryAmountDisplay.text = "Current Amount: " + amountCarrying;
		}
		boostAmount = 100;
		boostDisplay.value = boostAmount;
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Finish"))
        {
            myBody.velocity = Vector3.zero;
            dir = col.gameObject.transform.position - transform.position;
            dir = dir.normalized;
            myBody.AddForce(-dir * wallBump, ForceMode.VelocityChange);
            StartCoroutine(ResetVelocity());
        }
    }

    IEnumerator ResetVelocity()
    {
        yield return new WaitForSeconds(0.1f);
        myBody.velocity = Vector3.zero;
    }

    public void PlayerDeath()
    {
        bIsDead = true;
        if (gameOverScript)
        {
            gameOverScript.StartCountdownToGameOver(score);
        }
        //Spawn explosion particle
        Instantiate(explosion, transform.position, Quaternion.identity);    
        Destroy(gameObject);

    }
    public override void Dash()
	{
		base.Dash();
		boostDisplay.value = boostAmount;
	}
	public void Mining(bool state)
	{
		bIsMining = state;
	}
	public void changeDashingState(bool state)
	{
		currentState = State.Dashing;
		dashing = state;
        
        if(!dashAudioObject&&dashing)
        {
            dashAudioObject = audioScript.FindObject("playerDash");
            dashAudioObject.SetActive(true);
            dashAudioObject.GetComponent<AudioSource>().Play();
            audioDuration = 0.9f;
            StartCoroutine(PutObjectBack("playerDash", dashAudioObject));
        }
        if(!bIsDead)
        {
            animComp.SetBool("isBursting", state);
        }
		
	}

    IEnumerator PutObjectBack(string poolName,GameObject objectToReturn)
    {
        yield return new WaitForSeconds(audioDuration);
        dashAudioObject = null;
        audioScript.PutBackObject(poolName, objectToReturn);
    }
}
