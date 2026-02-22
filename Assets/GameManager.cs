using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int soldiersInHelicopter = 0;
    public int soldiersRescued = 0;
    public int soldiersOnField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject[] soldiers = GameObject.FindGameObjectsWithTag("Soldier");
        foreach (var soldier in soldiers)
        {
            soldiersOnField++;
        }
    }

    // Update is called once per frame
    void Update()
    {

       if (Input.GetKeyDown(KeyCode.R))
       {
           RestartGame();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
