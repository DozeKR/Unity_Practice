using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("부딪힘");
    }
}
