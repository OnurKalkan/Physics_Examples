using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Move : MonoBehaviour
{
    public int speed = 10, score = 0;
    //public Transform leftPoint, rightPoint, midPoint;
    public int leftPos, rightPos, midPos;
    public bool atLeft, atRight, atMid = true, onMove = false;
    public Positions positions;
    UIManager uimanager;

    private void Awake()
    {
        uimanager = GameObject.Find("GameManager").GetComponent<UIManager>();
    }

    public enum Positions
    {
        OnLeft,
        OnMid,
        OnRight
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed);
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && atLeft == false && !onMove)
        {            
            if (atMid)
            {
                atLeft = true;
                atMid = false;
            }
            else if (atRight)
            {
                atRight = false;
                atMid = true;
            }
            if(positions == Positions.OnMid)
            {
                positions = Positions.OnLeft;
            }
            else if (positions == Positions.OnRight)
            {
                positions = Positions.OnMid;
            }
            //transform.position = new Vector3(transform.position.x - 6,transform.position.y,transform.position.z);
            transform.DOMoveX(transform.position.x - 6, 0.25f).SetEase(Ease.Linear).OnComplete(OnMoveToFalse);
            onMove = true;
        }
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && positions != Positions.OnRight && !onMove)
        {            
            if (atMid)
            {
                atRight = true;
                atMid = false;
            }
            else if (atLeft)
            {
                atLeft = false;
                atMid = true;
            }
            if (positions == Positions.OnMid)
            {
                positions = Positions.OnRight;
            }
            else if (positions == Positions.OnLeft)
            {
                positions = Positions.OnMid;
            }
            //transform.position = new Vector3(transform.position.x + 6, transform.position.y, transform.position.z);
            transform.DOMoveX(transform.position.x + 6, 0.25f).SetEase(Ease.Linear).OnComplete(OnMoveToFalse);
            onMove = true;
        }
    }

    void OnMoveToFalse()
    {
        onMove = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Star"))
        {
            score++;
            uimanager.inGamePanel.transform.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();
            //Destroy(other.gameObject);
            //other.gameObject.SetActive(false);
            other.GetComponent<MeshRenderer>().material.DOColor(Color.red,1);
            transform.GetChild(0).DOLocalRotate(new Vector3(-90, 180, 90), 1);
        }
        if (other.CompareTag("Finish"))
        {
            speed = 0;
            uimanager.winPanel.SetActive(true);
        }
        if (other.CompareTag("Check Point"))
        {
            speed *= 2;
            transform.GetChild(0).DOLocalRotate(new Vector3(-90, 0, 90), 1);
        }
        if (other.CompareTag("Obstacle"))
        {
            speed = 0;
            uimanager.failPanel.SetActive(true);
        }
    }
}
