using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Question_3_setup : MonoBehaviour
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
        int[] myArray = Array.ConvertAll<string, int>(Input.text.Split(' '), int.Parse);
        string selected_items = "";
        for (var i = myArray.Length - 1; i > 0; i--)
        {
            var r = Random.Range(0, i);
            var tmp = myArray[i];
            myArray[i] = myArray[r];
            myArray[r] = tmp;
        }
        foreach (int i in myArray)
            selected_items += i.ToString() + " ";
        Result.text = selected_items;
    }

    public void back()
    {
        SceneManager.LoadScene("main");
    }
}
