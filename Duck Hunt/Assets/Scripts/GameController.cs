using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{

    public GameObject Bird;
    public Transform Parent;
    public Text timerText;
    public Text scoreText;
    public float maxBullets;
    public float maxBirds = 3;
    public float currentBirds = 0;
    public float time = 0;
    public float counter = 0;
    public static float score;
    float roundTime;
    bool levelOneCompleted = false;
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        if (levelOneCompleted == false)
        {
            runGame();
        }
    }

    void runGame() // Runs the game and then runs the level one function 
    {
        time += Time.deltaTime;
        roundTime = Mathf.RoundToInt(time);
        timerText.text = roundTime.ToString();
        scoreText.text = "Score: " + Leaderboard.levelScore.ToString();
        counter += Time.deltaTime;
        if (levelOneCompleted == false)
        {
            levelOne();
        }
        Debug.Log("killed birds: " + Leaderboard.killedBirds);
        Debug.Log("maxBirds birds: " + maxBirds);
        if (Leaderboard.killedBirds == maxBirds)
        {
            Debug.Log("Won game");
            levelOneCompleted = true;
            SceneManager.LoadScene("Win");
            return;
        }
    }
    void levelOne() // Simply loops how many ducks will spawn. For level one this is 3 ducks
    {
        if (currentBirds < maxBirds && counter > 3)
        {
            counter = 0;
            //currentBirds++;
            createBird();
        }
    }
    void createBird() // Creates the bird using prefab
    {

        Instantiate(Bird, new Vector3(0, 0, 0), Quaternion.identity, Parent);
        currentBirds++;
    }
}
