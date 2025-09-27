using System;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

    public float speed = 20;
    public float maxLife = 3;
    public Vector3 targetVector;
    void Start()
    {
        Destroy(gameObject, maxLife);

    }

    void Update()
    {
        transform.Translate(targetVector * speed * Time.deltaTime);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            IncreaseScore();
        }
    }

    private void IncreaseScore()
    {
        Player.SCORE+=1;
        GameObject go = GameObject.FindGameObjectWithTag("UI");
         go.GetComponentInChildren<Text>().text = "Score: " + Player.SCORE;
    }
}
