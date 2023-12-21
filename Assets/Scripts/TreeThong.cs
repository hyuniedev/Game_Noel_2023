using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeThong : MonoBehaviour
{
    [SerializeField] private GameObject tree;
    private void OnCollisionEnter2D(Collision2D other) {
        tree.GetComponent<SpriteRenderer>().sortingOrder = 29;
    }
    private void OnCollisionExit2D(Collision2D other) {
        tree.GetComponent<SpriteRenderer>().sortingOrder = 40;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        tree.GetComponent<SpriteRenderer>().sortingOrder = 29;
    }
    private void OnTriggerExit2D(Collider2D other) {
        tree.GetComponent<SpriteRenderer>().sortingOrder = 40;
    }
}
