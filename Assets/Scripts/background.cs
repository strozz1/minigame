using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{
    public Transform player;        // el jugador o nave
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        // mover el offset de la textura según la posición del jugador
    }
}