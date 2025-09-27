using UnityEngine;

public class MenuController : MonoBehaviour
{

    public GameObject playerPrefab;
    public Vector3 spawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnRetryButton()
    {
        Instantiate(playerPrefab,spawnPoint,Quaternion.identity);
    }
}
