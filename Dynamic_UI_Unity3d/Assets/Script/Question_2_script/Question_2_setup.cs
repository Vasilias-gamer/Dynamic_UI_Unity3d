using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Question_2_setup : MonoBehaviour
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
        Result.text = "";
        int sum = 255;
        int[] input_num = Array.ConvertAll<string, int>(Input.text.Split(' '), int.Parse);
        foreach(int s in input_num)
        {
            sum -= s;
        }
        if (sum > 30)
        {
            sum = 255;
            Result.text = "More than one number is missing.";
        }
        else
            Result.text = sum.ToString();
    }

    public void back()
    {
        SceneManager.LoadScene("main");
    }
}
