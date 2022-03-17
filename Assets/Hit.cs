using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Hit : MonoBehaviour
{
    public GeneralLogic gameController;

    public int targetHealth = 1;
    private int currentHealth = 1;

    public AudioClip impact;
    public AudioSource audioSource;

    void Start()
    {
        if(audioSource == null)
            audioSource = GetComponent<AudioSource>();
        currentHealth = targetHealth;
    }

    public void TargetHit(Collider collider)
    {
        currentHealth--;
        if (impact != null)
            audioSource.PlayOneShot(impact, 0.5F);
        gameController.TargetHit();
        if (currentHealth <= 0)
            StartCoroutine(Wait(collider));
    }

    private IEnumerator Wait(Collider collider)
    {
        yield return new WaitForEndOfFrame();
        gameController.TargetDestroy(collider);
    }

    public void ResetHealth()
    {
        currentHealth = targetHealth;
    }
}
