using System;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance {get;private set;}

    [SerializeField] private AudioClip damageSFX;
    [SerializeField] private AudioSource sourcePrefab;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlaySFXClip(damageSFX, transform, 1);
        }
    }

    public void PlaySFXClip(AudioClip clip, Transform spawnLocation, float volume)
    {
        // spawn game object
        AudioSource sourceGO = Instantiate(sourcePrefab, spawnLocation.position, Quaternion.identity);
        
        // assign audio clip
        sourceGO.clip = clip;

        // assign volume
        sourceGO.volume = volume;

        // play sound
        sourceGO.Play();

        // destroy the clip after its done playing
        Destroy(sourceGO.gameObject, sourceGO.clip.length);
    }

    public void PlayRandomSFXClip(AudioClip[] clip, Transform spawnLocation, float volume)
    {
        
    }
}