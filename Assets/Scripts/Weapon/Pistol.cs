using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot()
    {
        Instantiate(Bullet, ShootPosition.position, Quaternion.LookRotation(ShootPosition.forward));
        AudioSource.Play();
    }
}