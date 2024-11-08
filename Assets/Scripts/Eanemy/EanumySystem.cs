using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EanumySystem : MonoBehaviour
{
    public GameObject EanumyPrefab;
    private GameObject CurrentEanemy;

    public Text killCoutText;

    public int elimenations = 0;

    public GameObject menu;

    void Start()
    {
        CurrentEanemy = Instantiate(EanumyPrefab, new Vector3(Random.Range(-200, 200), 100, Random.Range(-200, 200)), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
    }

    void Update()
    {
        if (CurrentEanemy.IsDestroyed())
        {
            CurrentEanemy = Instantiate(EanumyPrefab, new Vector3(Random.Range(-200, 200), 100, Random.Range(-200, 200)),Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
            elimenations++;

            killCoutText.text = "Elemination Count = " + elimenations;

            if (elimenations == 10)
            {
                Time.timeScale = 0;
                menu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void LoadHome()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
