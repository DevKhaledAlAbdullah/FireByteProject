using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2f;
    public int damage = 10;
    public int lifeTime = 2;
    
    Vector3 direction;

    public float index;

    public GameObject effect;

    public float angle = 4;

    public MeshRenderer mr;
    public TrailRenderer trail;

    private bool canFade;
    private Color alphaColor;
    private float timeToFade = 1.75f;

    private void Start()
    {
        if (mr != null)
        {
            alphaColor = mr.material.color;
            alphaColor.a = 0;
        }
        direction = new Vector3(-(index / angle), 0 , -1);
        Destroy(gameObject, 1.25f);
        Invoke("Fade", 0.5f);
    }

    void Fade()
    {
        canFade = true;
    }

    public void UpdateDir()
    {
        direction = new Vector3(-(index / angle), 0, -1);
    }
    private void Update()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        if (mr == null)
            return;
        if (canFade)
        {
            mr.material.color = Color.Lerp(mr.material.color, alphaColor, timeToFade * Time.deltaTime);
            trail.startColor = Color.Lerp(trail.startColor, alphaColor, timeToFade * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.collider.CompareTag("Enemy"))
        //{
        //    Enemy enemy = collision.collider.GetComponent<Enemy>();
        //    enemy.Hit(GetTotalDamage());
        //    Impact();
        //}
        //else
        //{
        //    if (!collision.collider.CompareTag("Player"))
        //    {
        //        Impact();
        //    }
        //}
    }

    void Impact()
    {
        //Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    float GetTotalDamage()
    {
        return 0;
        // damage + damage * (LevelUpgrades.damageUpgrade + PermenantUpgrades.damageUpgrade);
    }
    
}
