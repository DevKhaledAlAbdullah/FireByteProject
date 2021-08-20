using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2f;
    Vector3 direction;
    Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.WakeUp();
    }
    private void Start()
    {
        direction = new Vector3(0, 0 , -1);
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);       
    }

   
    
}
