using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Controller")]
    public Animator animator;
    public bool isPause;
    public Vector3 screenPoint;
    public bool isMouseDrag = false;
    public Vector3 offset;
    private Rigidbody rb;
    public Vector2 cameraEdges;
    public float currentSpeed = 5;
    public float speedMoveLeftRight = 2f;
    public bool isHitObstacles = false;

    // Start is called before the first frame update
    void Start()
    {
        isPause = true;
        rb = GetComponent<Rigidbody>();
        //anim.transform.rotation = Quaternion.Euler(-90, 25, 0);
        GamePlayManagerScript.instance.OnStartGame -= OnStartGame;
        GamePlayManagerScript.instance.OnStartGame += OnStartGame;

        GamePlayManagerScript.instance.OnWinGame -= OnWinGame;
        GamePlayManagerScript.instance.OnWinGame += OnWinGame;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(MetaData.ConstVariable.GameSetting.Obstacles))
        {
            animator.SetBool(MetaData.ConstVariable.Animation.isHit, true);
            Invoke(nameof(StopHitAnimation), 0.3f);
            rb.AddForce(new Vector3(0, 0, -10), ForceMode.Impulse);
            isHitObstacles = true;
        }
        if (collision.gameObject.CompareTag(MetaData.ConstVariable.GameSetting.Enemy) && !isPause && collision.gameObject.GetComponent<EnemyScript>().isAwake)
        {
            isPause = true;
            animator.SetBool(MetaData.ConstVariable.Animation.isDie, true);
            GamePlayManagerScript.instance.Lose();
            var particleDie = Instantiate(GamePlayManagerScript.instance.fullDieParticle, transform.position, Quaternion.identity);
            particleDie.Play();
        }
    }

    private void StopHitAnimation()
    {
        animator.SetBool(MetaData.ConstVariable.Animation.isHit, false);
        isHitObstacles = false;
    }

    private void OnWinGame()
    {
        GamePlayManagerScript.instance.OnWinGame -= OnWinGame;
        animator.SetBool(MetaData.ConstVariable.Animation.isDance, true);
        isPause = true;
    }

    private void OnStartGame()
    {
        GamePlayManagerScript.instance.OnStartGame -= OnStartGame;
        isPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPause)
        {
            #region mouse Input
            if (Input.GetMouseButtonDown(0))
            {
                isMouseDrag = true;
                screenPoint = Camera.main.WorldToScreenPoint(transform.transform.position);
                offset = transform.transform.position -
                     Camera.main.ScreenToWorldPoint(
                        new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            }

            if (Input.GetMouseButtonUp(0))
            {
                isMouseDrag = false;
            }

            if (!isHitObstacles)
            {
                if (isMouseDrag)
                {
                    Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
                    Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;

                    Vector3 getcurrant =
                        new Vector3(
                            Mathf.Lerp(transform.position.x,
                            Mathf.Clamp(currentPosition.x, cameraEdges.x, cameraEdges.y), (speedMoveLeftRight * Time.fixedDeltaTime)),
                        transform.position.y,
                        transform.position.z + (currentSpeed * Time.fixedDeltaTime));

                    //rb.MovePosition(getcurrant);
                    transform.position = new Vector3(getcurrant.x, getcurrant.y, getcurrant.z);
                }
                else
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (currentSpeed * Time.fixedDeltaTime));

                animator.SetBool(MetaData.ConstVariable.Animation.isRun, true);
            }
            #endregion
        }
    }
}
