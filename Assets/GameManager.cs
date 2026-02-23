 using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int soldiersInHelicopter = 0;
    public int soldiersRescued = 0;
    public int soldiersOnField = 5;

    [SerializeField]
    private Text VictoryGameOverText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() 
    {
        // GameObject[] soldiers = GameObject.FindGameObjectsWithTag("Soldier");
        // foreach (var soldier in soldiers)
        // {
        //     soldiersOnField++;
        // }


        VictoryGameOverText = this.GetComponent<Text>();
        //VictoryGameOverText.text = "Hello";
    }

    // Update is called once per frame
    void Update()
    {

       if (Input.GetKeyDown(KeyCode.R))
       {
           RestartGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (soldiersOnField == 0 && soldiersInHelicopter == 0)
        {
            Victory();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver ()
    {
        VictoryGameOverText.text = "Game Over";
        Time.timeScale = 0;
    }

    public void Victory ()
    {
        VictoryGameOverText.text = "You Win";
        Time.timeScale = 0;
    }
}
