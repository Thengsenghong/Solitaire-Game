using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class MusicData
{
    float volume;
    public MusicData(float volume)
    {
        this.volume = volume;
    }
}
