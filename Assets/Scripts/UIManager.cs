// UIManager.cs
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text livesText;
    public PlayerController player;

    void Update()
    {
        scoreText.text = "Score: " + player.score;
        livesText.text = "Lives: " + player.lives;
    }
}
