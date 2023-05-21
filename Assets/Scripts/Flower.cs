using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private string flowerName;
    [SerializeField] private float production;
    [SerializeField] private float durability;

    private void OnMouseEnter() 
    {
        Debug.Log("툴팁 켜기");
    }
    private void OnMouseExit() 
    {
        Debug.Log("툴팁 끄기");
    }
    private void OnMouseDrag() 
    {
        var mousePos = Input.mousePosition;
        var objPosition = new Vector3(mousePos.x, mousePos.y, 10);
        transform.position = Camera.main.ScreenToWorldPoint(objPosition);
    }
    private void OnMouseUp() 
    {
        transform.position = transform.parent.position;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.transform.childCount < 1)
        transform.parent = other.transform;
    }
}
