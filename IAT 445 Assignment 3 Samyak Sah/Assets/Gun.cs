using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f; // damage done by every bullet
    public float range = 100f; // max range at which the bullet can shoot

    // initialising player and gun properties
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public AudioClip gunshot;
    public AudioSource shotAudio;

    void Update()
    {
        //shoot when pressed mouse 1
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {

        muzzleFlash.Play(); // play the muzzle flash
        shotAudio.PlayOneShot(gunshot);// play the gunshot
        RaycastHit hit; // define raycast

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) // if the gun hits an enemy
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>(); // set target from the hit raycast
            if(target != null)
            {
                target.TakeDamage(damage); // target takes damage
            }
        }
    }
}
