using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem ParticleSystem;
    public float TimeToHide = 3f;

    [Header("Sounds")]
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
        Invoke("HideOnObject", TimeToHide);
        OnCollect();

    }
    private void HideOnObject()
    {
        gameObject.SetActive(false);
    }
    

    protected virtual void OnCollect()
    {
        if (ParticleSystem != null) ParticleSystem.Play();
        if (audioSource != null) audioSource.Play();
    }
}
