using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject deathMenu;
    public Vector3 spawnPoint;
    public GameObject playerPrefab;

    // Update is called once per frame

    void Start()
    {
    }
    void Update()
    {
        if (!Player.ALIVE)
        {
            if (!deathMenu.activeSelf)
            {
                ToggleMenu(deathMenu);
            }
            else if (Input.GetKeyDown("r"))
            {
                AudioListener.volume = 1f;
                Time.timeScale = 1;
                Retry();
            }

        }
        else if (Input.GetKeyDown("p"))
        {
            ToggleMenu(pauseMenu);
        }

    }

    public void Retry()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    void ToggleMenu(GameObject menu)
    {
        menu.SetActive(!menu.activeSelf);
        if (menu.activeSelf)
        {
            AudioListener.volume = 0f;
            Time.timeScale = 0;
        }
        else
        {
            AudioListener.volume = 1f;
            Time.timeScale = 1;
        }
    }
}
