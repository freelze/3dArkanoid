using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [Header("可打破的磚塊初始數量")]
    public static int brickCount;

    //static GameObject nextLevelButton;

    public static void ReloadThisScene()
    {
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.name);
    }
    public static bool LevelClear
    {
        get
        {
            if (brickCount <= 0)
            {
                return true;
            }
            return false;
        }
    }

    public static void CheckLevelClearOrNot()
    {
        if (LevelClear)
        {

            //ShowNextLevelButton();
        }
    }
    public void GotoScene(string next)
    {
        SceneManager.LoadScene(next);
    }


    /*static void ShowNextLevelButton()
    {
        nextLevelButton.SetActive(true);
    }*/

    // Use this for initialization
    void Start()
    {
        //nextLevelButton = GameObject.FindGameObjectWithTag(tags.下一關按鈕.ToString());
        //nextLevelButton.SetActive(false);

        brickCount = GameObject.FindGameObjectsWithTag("Cube").Length + GameObject.FindGameObjectsWithTag("IronCube").Length;
        Debug.Log("一開始有 " + brickCount + " 個可打破的磚塊");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
