using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public ParticleSystem firePartical;

    [Header("FireSpeed Unit: Bullets/Sec")]
    public float fireSpeed = 5;

    // Start is called before the first frame update
    private void Start()
    {
        fireSpeed = GameManager.instance.GameSettingManager.gameSetting.speedShootRate;
        InvokeRepeating(nameof(Shoot), 0, fireSpeed);
    }


    void Shoot()
    {
        if (GamePlayManagerScript.instance.player.isPause)
            return;

        Instantiate(bullet, firePoint.position, bullet.transform.rotation);
        firePartical.Play();
    }
}
