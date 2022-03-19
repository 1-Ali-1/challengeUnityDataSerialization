using System.Collections;
using System.Collections.Generic;
using UnityEngine; using UnityEngine.SceneManagement; using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text text;
    public InputField input;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Best Score : " + DataManager.Instance.highestScore;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        DataManager.Instance.playerName = input.text;
       SceneManager.LoadScene("main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
