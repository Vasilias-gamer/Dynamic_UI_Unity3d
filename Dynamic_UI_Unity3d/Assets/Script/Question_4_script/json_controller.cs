using UnityEngine;
using System.IO;

public class json_controller : MonoBehaviour
{
    
    private UI_data ui_data;
    public string ui_file = "UI_data.txt";
    [SerializeField]
    public UI_setup ui_setup;
    [SerializeField]
    private connection connect;
    
    private void Start()
    {
        ui_setup.status.text = "Loading...";
        Load();
        if (ui_setup == null)
        {
            //ui_setup.status.text = "ui_setup not set!!");
            Debug.Log("ui_setup not set!!");
        }
    }

    public void Save(UI_data data)
    {
        string json = JsonUtility.ToJson(data);
        WriteToFile(ui_file, json);
        Load();
    }

    public void Load()
    {
        ui_data = new UI_data();
        string json = ReadFromFile(ui_file);
        JsonUtility.FromJsonOverwrite(json, ui_data);

        if (json.Equals(""))
        {
            connect.load_data(this);
        }
        else
        {
            foreach (Data data in ui_data.data)
            {
                data.profile.thumb_texture = byte_to_texture(data.profile);
            }
            ui_setup.status.text = "Done!!";
            ui_setup.Load_profile(ui_data);
        }
    }

    Texture2D byte_to_texture(Profile texture)
    {
        Texture2D temp = new Texture2D(1, 1);
        temp.LoadImage(texture.thumb_byte_array);
        return temp;
    }

    public void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);
        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }

    private string ReadFromFile(string fileName)
    {
        string path = GetFilePath(fileName);
        Debug.Log(path);
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else
        {
            ui_setup.status.text = "File not found locally. downloading from web.";
            Debug.LogWarning("File not found!!!");
            return "";
        }
    }

    private string GetFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }
}
