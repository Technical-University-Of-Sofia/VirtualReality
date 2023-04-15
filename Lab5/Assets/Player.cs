using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float ShootForce = 1.0f;

    //new fields for health
    public float TotalHealth = 100.0f;
    private float currentHealth;
    public Image HealthBar;

    void Start()
    {
        currentHealth = TotalHealth;
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, transform);
        Ray r = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        bullet.GetComponent<Rigidbody>().AddForce(r.direction * ShootForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Bullet bullet = collision.collider.GetComponent<Bullet>();
        if (bullet != null)
        {
            currentHealth -= bullet.DamageInflicted;
            HealthBar.fillAmount = currentHealth / TotalHealth;
            Destroy(bullet.gameObject);
            if (currentHealth <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
