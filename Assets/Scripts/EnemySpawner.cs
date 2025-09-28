using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRatePerMin = 10;
    public float spawnIncrement = 1;

    float xBorderLimit = 6, yBorderLimit = 8;

    float spawnNext = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnNext)
        {
            spawnNext = Time.time + 60f / spawnRatePerMin;
            spawnRatePerMin += spawnIncrement;

            var rand = Random.Range(-xBorderLimit, xBorderLimit);

            var spawnPos = new Vector2(transform.position.x + rand,
                                       transform.position.y + yBorderLimit);

            var met = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

            Destroy(met, 4f);
        }
    }
}
