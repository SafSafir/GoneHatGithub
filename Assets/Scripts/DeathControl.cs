using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathControl : MonoBehaviour
{
    public GameObject player;
    public Texture2D[] healthBarImage;
    public GameObject healthbarButton;
    public GameObject RestartButton;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void UseRebornButton()
    {
        gameObject.SetActive(false);
        RestartButton.SetActive(false);
        Time.timeScale = 1;
        player.GetComponent<PlayerMovement>().healthCounter = 3;
        healthbarButton.GetComponent<RawImage>().texture = healthBarImage[3];
       
    } 

    public void UseRestartButton()
    {
        Time.timeScale = 1;
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
}
