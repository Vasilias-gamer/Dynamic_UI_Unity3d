using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UI_data
{
    public string[] links;
    public List<Data> data;
}

[Serializable]
public class Data
{
    public string id = null;
    public Relationships relationships;
    public Profile profile;
}

[Serializable]
public class Relationships
{
    public Author author;
    public Comment comment;
}

[Serializable]
public class Author
{
    public Links links;
    public _Data data;
}

[Serializable]
public class Links
{
    public string self;
    public string related;
}

[Serializable]
public class _Data
{
    public string type;
    public string id;
}

[Serializable]
public class Comment
{
    public Links links;
    public List<_Data> data;
}

[Serializable]
public class Profile
{
    public string thumb;
    public byte[] thumb_byte_array;
    public Texture2D thumb_texture;
    public string gender;
    public string name;
}