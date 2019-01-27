using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour {

    private AudioSource currentAudio;
    private AudioSource stopAudio;
    private GameObject currentObject;
    private ObjectPoolManager audioScript;
    private float audioDuration;
    private void Awake()
    {
        audioScript = FindObjectOfType<ObjectPoolManager>();
    }

    public void PlayThisAudio(string poolName)
    {
        currentObject = audioScript.FindObject(poolName);
        if(currentObject)
        {
            currentObject.SetActive(true);
            currentAudio = currentObject.GetComponent<AudioSource>();
            audioDuration = currentAudio.clip.length;
            if(!currentAudio.isPlaying)
            {
                currentAudio.Play();
            }
            //else
            //{
            //    Debug.Log("Here");

            //    currentAudio.Play();
            //}
        }

    }

    public void StopAudio(string poolName)
    {
        currentObject = audioScript.FindObject(poolName);
        if(currentObject)
        {
            stopAudio = currentObject.GetComponent<AudioSource>();
            stopAudio.Stop();
        }
    }

    IEnumerator ReturnObject(string poolName)
    {
        yield return new WaitForSeconds(audioDuration);
        audioScript.PutBackObject(poolName, currentObject);
    }
}
