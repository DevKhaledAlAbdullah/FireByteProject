using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Animator animator;
    public float currentSpeed = 8;
    public float blood = 100;
    public bool isDie = false;
    public bool isAwake = false;
    public Collider swordCollider;
    public float Line1 = 5;
    public float Line2 = 0;
    public float Line3 = -5;
    public float distance;

    private void Start()
    {
        GamePlayManagerScript.instance.enemyList.Add(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(MetaData.ConstVariable.GameSetting.Bullet) && !isDie)
        {
            animator.SetBool(MetaData.ConstVariable.Animation.isDie, true);
            var particleDie = Instantiate(GamePlayManagerScript.instance.fullDieParticle, transform.position, Quaternion.identity);
            particleDie.Play();
            isDie = true;
        }
    }

    void Update()
    {
        if (GamePlayManagerScript.instance.player.transform.position.z > transform.position.z + 15)
            isAwake = true;

        if (!GamePlayManagerScript.instance.player.isPause && !isDie && isAwake)
        {
            distance = DistanceToPlayer();


            if (distance > 3)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (currentSpeed * Time.fixedDeltaTime));
                animator.SetBool(MetaData.ConstVariable.Animation.isRun, true);
                animator.SetBool(MetaData.ConstVariable.Animation.isHit, false);
                swordCollider.enabled = false;
            }
            else
            {
                animator.SetBool(MetaData.ConstVariable.Animation.isHit, true);
                swordCollider.enabled = true;
            }

            if (distance < 15)
            {
                transform.position = new Vector3(
                    Mathf.Lerp(transform.position.x, GamePlayManagerScript.instance.player.transform.position.x, Time.fixedDeltaTime),
                    transform.position.y,
                    transform.position.z + (currentSpeed * Time.fixedDeltaTime));

                currentSpeed = 5;
            }
            else
            {
                currentSpeed = 15;
            }
        }
        else
        {
            if (!isDie)
            {
                animator.SetBool(MetaData.ConstVariable.Animation.isRun, false);
                animator.SetBool(MetaData.ConstVariable.Animation.isHit, false);
            }
        }


    }

    public float DistanceToPlayer()
    {
        return Vector3.Distance(transform.position , GamePlayManagerScript.instance.player.transform.position);
    }
}
