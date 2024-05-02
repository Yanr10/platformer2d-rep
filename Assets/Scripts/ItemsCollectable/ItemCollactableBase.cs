using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem ParticleSystem;

    public AudioSource audioSource;



    private void Awake()
    {
        if (ParticleSystem != null) ParticleSystem.transform.SetParent(null);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compareTag)) 
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        gameObject.SetActive(false);
        OnCollect();

    }

    

    protected virtual void OnCollect()
    {
        if (ParticleSystem != null) ParticleSystem.Play();
        if (audioSource != null) audioSource.Play();
    }
}
