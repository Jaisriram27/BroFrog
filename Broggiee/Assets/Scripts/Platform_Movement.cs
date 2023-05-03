using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Movement : MonoBehaviour
{
    public Transform posA, posB;
    public int Speed;
    Vector2 targetpos;

   
    void Start()
    {
        {
            targetpos = posB.position;
        }
    }
      void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < .1f) targetpos = posB.position;

        if (Vector2.Distance(transform.position, posB.position) < .1f) targetpos = posA.position;

        transform.position = Vector2.MoveTowards(transform.position, targetpos, Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
