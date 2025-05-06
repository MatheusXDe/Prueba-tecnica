using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameMan : MonoBehaviour
{
    int currentBalls;
    [SerializeField] float cooldown;float cldI;
    [SerializeField] TMP_Text info;
    public bool isRunning;
    void Start()
    {
        cldI = cooldown;
    }
    void Update()
    {
        currentBalls = GameObject.FindGameObjectsWithTag("Ball").Length; GUEI();

        if(isRunning && currentBalls < SpawnSystem.Call.maxBalls)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                SpawnSystem.Call.RetrieveBall();
                cooldown = cldI;
            }
        }
    }

    public void IR()
    {
        isRunning = true;
    }

    void GUEI()
    {
        info.text = "Active Balls: " + currentBalls+ "<br>MaxBalls: " + SpawnSystem.Call.maxBalls + "<br>" +
            "Spawn Ball Cooldown " + cooldown.ToString("0.00");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
