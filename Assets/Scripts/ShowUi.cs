using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUi : MonoBehaviour
{
    public GameObject uiObject;
    public GameObject uiObject2;
    void Start()
    {
        uiObject.SetActive(false);
        uiObject2.SetActive(false);
    }

    // Update is called before the first frame update
    void OnTriggerEnter (Collider player)
    {
        if(player.gameObject.tag == "Player")
        {
            uiObject.SetActive(true);
            uiObject2.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(uiObject);
        Destroy(uiObject2);
        Destroy(gameObject);
    }
}
