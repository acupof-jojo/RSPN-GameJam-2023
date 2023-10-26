using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMain : MonoBehaviour
{
    public Button backToMain;
    // Start is called before the first frame update
    void Start()
    {
        backToMain.onClick.AddListener(toMain);
    }

    // Update is called once per frame
    private void toMain()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
