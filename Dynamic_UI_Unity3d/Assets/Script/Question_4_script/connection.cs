using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class connection : MonoBehaviour
{
    private UI_data ui_data;
    //[SerializeField]
    private json_controller controller;
    private int all_set_count;

    
    public void load_data(json_controller _controller)
    {
        controller = _controller;
        ui_data = new UI_data();
        all_set_count = 0;
        string json_url = "https://drive.google.com/uc?id=1OfQbwdt248MpcfVGP_3HXmrP66JRHAlf";
        StartCoroutine(download_data(json_url));
    }

    IEnumerator download_data(string json_URL)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(json_URL))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = json_URL.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    controller.ui_setup.status.text = "Internet connection isshu.";
                    Debug.LogError("Internet connection isshu.");//pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    controller.ui_setup.status.text = "Server isshu";
                    Debug.LogError("Server isshu");// pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    process_json_data(webRequest.downloadHandler.text);
                    break;
            }
        }
        
    }


    private void process_json_data(string URL_data)
    {
        ui_data = JsonUtility.FromJson<UI_data>(URL_data);
        for(int i=0;i<ui_data.data.Capacity;i++)
            StartCoroutine(GetTexture(ui_data.data[i].profile.thumb, i));
    }


    IEnumerator GetTexture(string URL , int i)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(URL);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            controller.ui_setup.status.text = "invalid image path.";
            Debug.Log("invalid image path.");
        }
        else
        {
            Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

            if (texture_validation(texture.GetRawTextureData()))
            {
                ui_data.data[i].profile.thumb_texture = texture;
                ui_data.data[i].profile.thumb_byte_array = texture_to_byte(texture);
                all_set_count++;
                if (all_set_count == ui_data.data.Capacity)
                {
                    data_loaded();
                }
            }
            else
            {
                controller.ui_setup.status.text = "invalid texture!!";
                Debug.Log("invalid texture");
            }

        }
    }
 
    byte[] texture_to_byte(Texture2D texture)
    {   
        return texture.EncodeToPNG();
    }

    void data_loaded()
    {
        controller.Save(ui_data);
    }

    bool texture_validation(byte[] texture)
    {
        byte[] invalid_texture = { 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 255, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 255, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 255, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 255, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 255, 0, 0, 255, 255, 255, 255, 255, 255, 255, 0, 0, 255, 0, 0, 255, 255, 255, 255, 255, 255, 255, 0, 0, 255, 0, 0, 255, 255, 255, 255, 255, 255, 255, 0, 0, 255, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 255, 0, 0, 255, 0, 0, 255, 0, 0, 255, 255, 255, 255, 255, 255 };

        bool valide = false;

        for(int i=0;i<invalid_texture.Length;i++)
        {
            if (texture[i] != invalid_texture[i])
            {
                valide = true;
            }
        }
        //Debug.Log(valide);
        return valide;
    }
    
}
