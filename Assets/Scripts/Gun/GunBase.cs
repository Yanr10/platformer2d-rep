using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;
    public Transform positionToShoot;
    public Transform playerSideReference;

    public float timeBetweenShoot = 0.3f;

    private Coroutine _currentCoroutine;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        }

        else if (Input.GetKeyUp(KeyCode.F))
        {
            if (_currentCoroutine != null)
                StopCoroutine(_currentCoroutine);
        
        }
                
    }




    IEnumerator StartShoot()
    {
        while(true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }
    public void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.side = playerSideReference.transform.localScale.x;
    }

}
