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
    }
}
