using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Question_1_setup : MonoBehaviour
{
    [SerializeField]
    private InputField Input;
    [SerializeField]
    private Text Result;
    // Start is called before the first frame update
    void Start()
    {
        Input.text = "";
        Result.text = "";
    }

    public void solve()
    {
        string[] text = Input.text.Split(' ');
        string reversed="";
        foreach(string s in text)
        {
            reversed = s + " " + reversed;
        }
        Result.text = reversed;
    }

    public void back()
    {
        SceneManager.LoadScene("main");
    }
}
