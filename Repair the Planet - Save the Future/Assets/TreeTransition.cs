using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTransition : MonoBehaviour
{

    public GameObject gamecon;

    // Start is called before the first frame update
    void Start()
    {
        gamecon = GameObject.Find("MainHeroCharacter");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            float vs = gamecon.GetComponent<GameController>().GetVictoryStatus();
            transform.localScale += new Vector3(vs/100,vs/100,vs/100);
        }
            
    }
}
