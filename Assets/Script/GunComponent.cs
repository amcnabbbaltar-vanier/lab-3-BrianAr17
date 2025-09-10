using UnityEngine;

public class GunComponent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletMaxImpulse = 10.0f;
    public float maxChargeTime = 3.0f;
    private float chargeTime = 0.0f;
    private bool isCharging = false;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            chargeTime = 0.0f;
        }
        if (Input.GetButton("Fire1"))
        {
            chargeTime += Time.deltaTime * 2.5f; // made it 2.5 times faster because the charge was too slow
            if (chargeTime > maxChargeTime)
            {
                chargeTime = maxChargeTime;
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // TODO Change that equation so that it adds an impulse that follows charge time
        float bulletImpulse = bulletMaxImpulse * chargeTime;

        // An impulse is a force you apply on an object in a single instant
        rb.AddForce(bulletSpawnPoint.forward * bulletImpulse, ForceMode.Impulse);
    }


}
