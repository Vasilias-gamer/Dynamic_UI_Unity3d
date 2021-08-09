using UnityEngine;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
    public void Load_Question_1()
    {
        SceneManager.LoadScene("Question_1");
    }

    public void Load_Question_2()
    {
        SceneManager.LoadScene("Question_2");
    }

    public void Load_Question_3()
    {
        SceneManager.LoadScene("Question_3");
    }

    public void Load_Question_4()
    {
        SceneManager.LoadScene("Question_4");
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            exit();
        }
    }

    public void exit()
    {
        Application.Quit();
    }

}
