using UnityEngine;
using System.Collections;

public class Turrettwo : MonoBehaviour
{

    public Rigidbody bulletPrefab;
    private Transform target;
    public Projectile bullet;
    private float nextFire;
    private turretspawn scr;
    public PlaneDroite ss;
    public Transform spawn;
    private bool shotting = false;

    void Start()
    {
        
    }

    void Update()
    {

        bool newShotting = ss.PlayerIn;
        if(newShotting != shotting)
        {
            if (newShotting)
            {
                target = this.transform;
                StartCoroutine("Fire");

            }
            else
            {
                target = null;
                StopCoroutine("Fire");
            }
            
            shotting = newShotting;
           
        }

        

    }

    IEnumerator Fire()
    {
        while (target != null)
        {
            nextFire = Time.time + 0.5f / GameState.Instance.UniversalTime;
            
            while (Time.time < nextFire)
            {


                yield return new WaitForEndOfFrame();
            }

            bullet = Instantiate(bulletPrefab, spawn.position, spawn.rotation) as Projectile;

        }
    }

}