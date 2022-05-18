using UnityEngine;
using System.Collections;
using TMPro;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 1000f;
    public float fireRate = 15f;
    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public Camera fpsCam;
    //public GameObject impactEffect;
    private float nextTimeToFire = 0f;
    public TextMeshProUGUI ammotext;
    public ParticleSystem muzzleFlash;
    public Animator animator;
    public AudioClip gunshotSound;
    public AudioSource sfx;
    public float pitchrandomizer;


    void Start()
    {
        currentAmmo = maxAmmo;
        DisplayAmmo(currentAmmo, maxAmmo);
    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }
    
    void Update()
    {
        if (isReloading)
        {
            return;
        }
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate; 
            Shoot();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);
        currentAmmo = maxAmmo;
        DisplayAmmo(currentAmmo, maxAmmo);
        isReloading = false;
    }

    void Shoot()
    {
        muzzleFlash.Play();
        currentAmmo--;
//        fireSource.Play();

        //sound
        sfx.Stop();
        sfx.clip = gunshotSound;
        sfx.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            /*GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);*/
        }
        DisplayAmmo(currentAmmo, maxAmmo);
    }

    void DisplayAmmo(int currentAmmo, int maxAmmo)
    {
        ammotext.text = string.Format("{0} / {1}", currentAmmo, maxAmmo);
    }
}
