using UnityEngine;

public class Follow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject follow;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        gameObject.transform.position = new Vector3(follow.transform.position.x, follow.transform.position.y, gameObject.transform.position.z);
        gameObject.transform.rotation = Quaternion.identity;
        
    }
}
