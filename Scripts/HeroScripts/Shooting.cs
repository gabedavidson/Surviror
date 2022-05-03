using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint_1_3;
    public Transform firePoint_1_4_6;
    public Rigidbody2D firePoint_1_4_6RB;
    public Transform firePoint_2_4_6;
    public Rigidbody2D firePoint_2_4_6RB;
    public Rigidbody2D mainBodyRB;

    public HeroLevelTracker levelTracker;
    public GameObject defaultBulletPrefab;
    public Camera cam;

    private bool OnCooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        if (!OnCooldown)
        {
            OnCooldown = true;
            Shoot();
            StartCoroutine(ShootCooldown());
        }
    }

    private void Shoot()
    {
        GameObject bulletPrefab;
        try
        {
            bulletPrefab = levelTracker.GetCurrentBulletPrefab();
        }
        catch
        {
            bulletPrefab = defaultBulletPrefab;
        }
        ShootBasedOnLevel(bulletPrefab);
    }

    private void ShootBasedOnLevel(GameObject prefab)
    {
        if (HeroParameters.heroLevel < 4)
        {
            ShootBullet(prefab, firePoint_1_3);
        }
        else if (HeroParameters.heroLevel > 3)
        {
            ShootBullet(prefab, firePoint_1_4_6);
            ShootBullet(prefab, firePoint_2_4_6);
        }
    }

    private void ShootBullet(GameObject prefab, Transform firePoint)
    {
        GameObject b = Instantiate(prefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * HeroParameters.bulletSpeed, ForceMode2D.Impulse);
        StartCoroutine(DestroyBullet(b));
    }

/*    private void GetFirePointRotation(Transform firePoint, Rigidbody2D firePointRB)
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - firePointRB.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        firePointRB.rotation = angle;
        return 
    }*/

    IEnumerator DestroyBullet(GameObject b)
    {
        yield return new WaitForSeconds(3f);
        Destroy(b);
    }

    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(HeroParameters.bulletCooldown);
        OnCooldown = false;
    }
}
