using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //GameObject player;
    Move playerMove;
    public GameObject tapToStartPanel, winPanel, failPanel, inGamePanel;

    private void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        //player.GetComponent<Move>().speed = 0;
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<Move>();
        playerMove.speed = 0;
    }

    public void TapToStart()
    {
        playerMove.speed = 15;
        tapToStartPanel.SetActive(false);
        inGamePanel.SetActive(true);
    }
}
