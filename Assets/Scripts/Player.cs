using UnityEngine;

public class Player : MonoBehaviour
{
    public float thrustForce = 10f;
    public float rotationSpeed = 120f;
    Rigidbody _rigidBody;
    Vector2 thrustDirection;

    public GameObject gun, bulletPrefab;

    public static int SCORE = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SCORE = 0;
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float rotation = Input.GetAxis("Rotate") * rotationSpeed * Time.deltaTime;
        float thrust = Input.GetAxis("Thrust") * thrustForce;
        thrustDirection = transform.right;
        transform.Rotate(Vector3.forward, -rotation);
        _rigidBody.AddForce(thrust * thrustDirection);


    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);
            Bullet b = bullet.GetComponent<Bullet>();
            b.targetVector = transform.right;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject, 0);
        }
    }
}
