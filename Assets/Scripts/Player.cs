using UnityEngine;

public class Player : MonoBehaviour
{
    public float thrustForce = 10f;
    private float currentThrust;
    public float rotationSpeed = 120f;
    public GameObject followCamera;
    public GameObject bg;
    public GameObject enemySpawner;

    //Cuan rapiod decae la velocidad
    public float decayRate = 1f;
    Rigidbody _rigidBody;
    Vector2 thrustDirection;

    public GameObject gun, bulletPrefab;

    public static int SCORE = 0;
    public static bool ALIVE = true;
    private Renderer bgRend;

    private float factor = 0.1f; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ALIVE = true;
        SCORE = 0;
        currentThrust = 0;
        _rigidBody = GetComponent<Rigidbody>();
        bgRend=bg.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float rotation = Input.GetAxis("Rotate") * rotationSpeed * Time.deltaTime;
        float thrust = Input.GetAxis("Thrust") * thrustForce;
        thrustDirection = transform.right;
        transform.Rotate(Vector3.forward, -rotation);
        if (Mathf.Abs(thrust) > 0)
        {
            currentThrust = thrust;
        }
        else if (Mathf.Abs(currentThrust) > 0.001)
        {
            thrustDirection = transform.right;
            currentThrust = Mathf.Lerp(currentThrust, 0f, decayRate * Time.deltaTime);//preguntar diferencia entre deltatime
        }
        _rigidBody.AddForce(thrustDirection * currentThrust);

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);
            Bullet b = bullet.GetComponent<Bullet>();
            b.targetVector = transform.right;
        }
        if (ALIVE)
        {
            followCamera.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, followCamera.transform.position.z);
            followCamera.transform.rotation = Quaternion.identity;

            Vector2 offset = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) * factor;
            bgRend.material.mainTextureOffset = offset;
            bg.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, bg.transform.position.z);
            bg.transform.rotation = Quaternion.identity;

            
            enemySpawner.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, enemySpawner.transform.position.z);
            enemySpawner.transform.rotation = Quaternion.identity;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject, 0);
            ALIVE = false;
        }
    }
}
