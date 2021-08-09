using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_setup : MonoBehaviour
{
    [SerializeField]
    private Transform Items;
    [SerializeField]
    private GameObject profile_panal;
    [SerializeField]
    public Text status;

    public void Load_profile(UI_data ui_data)
    {
        foreach(Data d in ui_data.data)
        {
            GameObject profile = Instantiate(profile_panal, Items);
            profile.GetComponent<Profile_setup>().set_profile(d.profile.thumb_texture, d.profile.name, d.profile.gender);
        }
        status.gameObject.SetActive(false);
    }


    public void back()
    {
        SceneManager.LoadScene("main");
    }
}
