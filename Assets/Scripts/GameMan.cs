using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameMan : MonoBehaviour
{
    int currentBalls;
    [SerializeField] float cooldown;float cldI; // prefab enabling cooldown values
    [SerializeField] TMP_Text info;
    public bool isRunning;
    void Start()
    {
        cldI = cooldown; // set cooldown initial value for later
    }
    void Update()
    {
        currentBalls = GameObject.FindGameObjectsWithTag("Ball").Length; // get current active prefabs by searching em by their tag
        GUEI();

        if(isRunning && currentBalls < SpawnSystem.Call.maxBalls)
        {
            cooldown -= Time.deltaTime; // decreases cooldown value over time
            if (cooldown <= 0) // if cooldown is equal or below to 0
            {
                SpawnSystem.Call.RetrieveBall(); // activate prefab
                cooldown = cldI; // set cooldown to it's initial value
            }
        }
    }

    public void IR() // Start Simulation button
    {
        isRunning = true;
    }

    void GUEI()
    {
        // Informative text
        info.text = "Active Balls: " + currentBalls+ "<br>MaxBalls: " + SpawnSystem.Call.maxBalls + "<br>" +
            "Spawn Ball Cooldown " + cooldown.ToString("0.00");
    }

    public void ExitGame() // Quit game
    {
        Application.Quit();
    }
}
