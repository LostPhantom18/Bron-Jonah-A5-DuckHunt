using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class GameController : MonoBehaviour
{

    public GameObject Bird;
    public Transform Parent;
    public Text timerText;
    public float maxBullets;
    public float maxBirds;
    public float currentBirds;
    public float time = 0;
    public float counter = 0;
    float roundTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 300)
        {
            levelOne();
        }
    }
    void levelOne()
    {
        while (true)
        {
            time += Time.deltaTime;
            roundTime = Mathf.RoundToInt(time);
            timerText.text = roundTime.ToString();
            counter += Time.deltaTime;
            //Debug.Log(time);
            if (currentBirds < maxBirds && counter > 3)
            {
                Debug.Log("Create");
                counter = 0;
                createBird();
            }
            if (time < 300)
            {
                return;
            }
        }
    }

    void createBird()
    {

        Instantiate(Bird, new Vector3(0, 0, 0), Quaternion.identity, Parent);
        currentBirds++;
    }
}
