using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class UIControler : MonoBehaviour
{
    [SerializeField] TMP_Text distanceTraveled;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Player player;
    [SerializeField] TMP_Text coinsCollected;
    [SerializeField] GameObject gameMusic;
    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        gameMusic.SetActive(false);
        //distanceTraveled.text = player.distanceTraveled.ToString();
        float roundedDistance = Mathf.Ceil(player.distanceTraveled);
        distanceTraveled.text = "" + roundedDistance;

        coinsCollected.text = "" + player.collectedCoins;

    }



    public void GameRestart()
    {
        SceneManager.LoadScene("EndlessRunner");

    }
}
