using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private bool flipState;

    // Use this for initialization
    void Start()
    {
        flipState = false;
        StartCoroutine("Flippy");

    }

    void Update()
    {

    }

    IEnumerator Flippy()
    {
        while (true)
        {
            GetComponent<SpriteRenderer>().flipX = flipState;
            flipState = !flipState;
            yield return new WaitForSeconds(.8f);
        }

    }
}
