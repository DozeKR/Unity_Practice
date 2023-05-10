using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [Header("[endPos]")]
    public float endPosX;
    public float endPosY;

    [Header("Bool")]
    public bool isMove;

    [Header("[UI]")]
    public Color stopColor;
    public Color moveColor;
    public float moveSpeed;
    public float changeSpeed;
    public float moveDistance;

    void Awake()
    {
        //변수 초기화
        stopColor = Color.white;
        moveColor = Color.red;

        isMove = false;

        moveSpeed = 3.0f;
        changeSpeed = 1.5f;
        moveDistance = 3.0f;
    }

    void Update()
    {
        if(!isMove)
        {
            playerMove();
        }
    }

    // 플레이어 이동 함수
    void playerMove()
    {
        if(Input.GetKeyDown("right")){
            isMove = true;
            endPosX = transform.position.x;
            endPosX += moveDistance;

            transform.DOMoveX(endPosX, moveSpeed).OnComplete(ActionComplete).SetEase(Ease.OutCirc);
            playerColor();
        }
        if(Input.GetKeyDown("left")){
            isMove = true;
            endPosX = transform.position.x;
            endPosX -= moveDistance;

            transform.DOMoveX(endPosX, moveSpeed).OnComplete(ActionComplete).SetEase(Ease.OutCirc);
            playerColor();
        }
        if(Input.GetKeyDown("up")){
            isMove = true;
            endPosY = transform.position.y;
            endPosY += moveDistance;

            transform.DOMoveY(endPosY, moveSpeed).OnComplete(ActionComplete).SetEase(Ease.OutCirc);
            playerColor();
        }
        if(Input.GetKeyDown("down")){
            isMove = true;
            endPosY = transform.position.y;
            endPosY -= moveDistance;

            transform.DOMoveY(endPosY, moveSpeed).OnComplete(ActionComplete).SetEase(Ease.OutCirc);
            playerColor();

        }
        void ActionComplete(){
            isMove = false;

            playerColor();
        }
    }

    void playerColor()
    {
        if(isMove)
        {
            transform.GetComponent<Renderer>().material.DOColor(moveColor,changeSpeed);
        }
        else
        {
            transform.GetComponent<Renderer>().material.DOColor(stopColor,changeSpeed);
        }
    }
}
