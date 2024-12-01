using UnityEngine;
using UnityEngine.UIElements;

public class MainUI : MonoBehaviour
{   
        Label healthText; 
        Label pointsText;
        Label waveText;
        Label enemiesLeftText;

        //example
        int playerHealth = 100;
        int playerPoints = 4;
        int currentWave = 3;
        int enemiesLeft = 2;

    private void OnEnable(){
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        healthText = root.Q<Label>("HealthText");
        pointsText = root.Q<Label>("PointsText");
        waveText = root.Q<Label>("WaveText");
        enemiesLeftText = root.Q<Label>("EnemiesLeftText");
    }

    private void Update(){
        healthText.text = $"Health: {playerHealth}";
        pointsText.text = $"Points: {playerPoints}";
        waveText.text = $"Wave: {currentWave}";
        enemiesLeftText.text = $"Enemies Left: {enemiesLeft}";

        //SimulateGameLogic();
    }

    //     private void SimulateGameLogic()
    // {
    //     if (Time.frameCount % 60 == 0) 
    //     {
    //         playerHealth = Mathf.Max(0, playerHealth - 1); 
    //         playerPoints += 10; 
    //         enemiesLeft = Mathf.Max(0, enemiesLeft - 1);
    //         if (enemiesLeft == 0) 
    //         {
    //             currentWave++;
    //             enemiesLeft = 10 + currentWave * 5;
    //         }
    //     }
    // }
}
