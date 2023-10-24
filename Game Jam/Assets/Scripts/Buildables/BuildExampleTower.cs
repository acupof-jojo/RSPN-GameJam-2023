using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildExampleTower : MonoBehaviour
{

    public GameObject buildTower;
    public GameObject buildMenu;
    int buildCost = 10;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver() {

        Debug.Log("test");
        if(Input.GetMouseButtonDown(0)) {

            SendMessageUpwards("checkMoney", buildCost);

        }

    }

    void buildTower1() {
        GameObject tower = Instantiate(buildTower, transform.parent.position, transform.rotation);
        gameObject.SendMessageUpwards("CloseMenu");
        Destroy(gameObject);
    }
}
