using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponType currentWeapon;

    public GameObject bulletPrefab;

    public Transform firePoint;

    public KatanaHitbox katanaHitbox;

    public float pistolBulletSpeed = 25f;
    public float shotgunBulletSpeed = 15f;

    public float pistolCooldown = 0.5f;
    public float shotgunCooldown = 1.5f;
    public float katanaCooldown = 0.4f;

    private float cooldownTimer;

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        HandleWeaponSwitch();

        if (Input.GetMouseButtonDown(0))
        {
            UseWeapon();
        }
    }

    void HandleWeaponSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = WeaponType.Pistol;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = WeaponType.Shotgun;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = WeaponType.Katana;
        }

        float scroll = Input.mouseScrollDelta.y;

        if (scroll > 0)
        {
            currentWeapon++;

            if ((int)currentWeapon > 2)
            {
                currentWeapon = 0;
            }
        }

        if (scroll < 0)
        {
            currentWeapon--;

            if ((int)currentWeapon < 0)
            {
                currentWeapon = WeaponType.Katana;
            }
        }
    }

    void UseWeapon()
    {
        if (cooldownTimer > 0)
        {
            return;
        }

        switch (currentWeapon)
        {
            case WeaponType.Pistol:

                ShootPistol();

                cooldownTimer = pistolCooldown;

                break;

            case WeaponType.Shotgun:

                ShootShotgun();

                cooldownTimer = shotgunCooldown;

                break;

            case WeaponType.Katana:

                KatanaAttack();

                cooldownTimer = katanaCooldown;

                break;
        }
    }

    void ShootPistol()
    {
        ShootBullet(
            firePoint.position,
            GetMouseDirection(),
            pistolBulletSpeed,
            1.5f
        );
    }

    void ShootShotgun()
    {
        for (int i = -2; i <= 2; i++)
        {
            Vector2 direction =
                Quaternion.Euler(0, 0, i * 10)
                * GetMouseDirection();

            ShootBullet(
                firePoint.position,
                direction,
                shotgunBulletSpeed,
                0.25f
            );
        }
    }

    void ShootBullet(
        Vector3 spawnPosition,
        Vector2 direction,
        float speed,
        float lifeTime
    )
    {
        GameObject bullet = Instantiate(
            bulletPrefab,
            spawnPosition,
            Quaternion.identity
        );

        bullet.transform.right = direction;

        Bullet bulletScript =
            bullet.GetComponent<Bullet>();

        if (bulletScript != null)
        {
            bulletScript.lifeTime = lifeTime;
        }

        Rigidbody2D rb =
            bullet.GetComponent<Rigidbody2D>();

        rb.linearVelocity = direction * speed;
    }

    Vector2 GetMouseDirection()
    {
        Vector3 mousePosition =
            Camera.main.ScreenToWorldPoint(
                Input.mousePosition
            );

        return (
            mousePosition - firePoint.position
        ).normalized;
    }

    void KatanaAttack()
    {
        StartCoroutine(KatanaSwing());
    }

    System.Collections.IEnumerator KatanaSwing()
    {
        katanaHitbox.ActivateHitbox();

        yield return new WaitForSeconds(0.15f);

        katanaHitbox.DeactivateHitbox();
    }
}