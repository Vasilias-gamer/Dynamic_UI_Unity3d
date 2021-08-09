using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Profile_setup : MonoBehaviour
{
    public void set_profile(Texture2D profile_pic, string name, string gender)
    {
        transform.GetChild(0).GetComponent<Image>().sprite = Sprite.Create(profile_pic, new Rect(0, 0, profile_pic.width, profile_pic.height), Vector2.one / 2);
        transform.GetChild(1).GetComponent<Text>().text = "Name : "+name;
        transform.GetChild(2).GetComponent<Text>().text = "Gender : "+gender;
    }
}
