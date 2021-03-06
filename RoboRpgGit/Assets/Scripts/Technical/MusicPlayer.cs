using UnityEngine.Audio;
using UnityEngine;
using System.IO;
using System.Linq;
using System.Collections;
using TMPro;





[System.Serializable]
public class Song
{
    public string name;
    public float duration;
    public string artist;
    [SerializeField]
    public AudioClip audioClip;
    public Song(string name)
    {
        this.name = name;
    }

    public Song(AudioClip audioClip, string artist)
    {
        this.audioClip = audioClip;
        this.artist = artist;
        duration = audioClip.length;
        name = audioClip.name;
    }  

    public new string ToString()
    {
        return $"Name: {name}\n\tBand:{artist}\n\tDuration{duration.ToString()}";
    }
}

[System.Serializable]
public class MusicPlayer : MonoBehaviour
{
    
    public Song[] songs;
    public int selected;
    public AudioListener audioListener;
    public AudioSource audioSource;
    public DirectoryInfo dir;

    public UI prefab;
    public ui_CassetPlayer test;
   
    public void Start()
    {      
       audioSource.volume = .05f;        
       test = Instantiate<ui_CassetPlayer>((ui_CassetPlayer)prefab);                
         
       LoadAlbum("TWRP");     
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        { 
            StartCoroutine(test.Display());        
        }

        if (test.isShown() && Input.GetKeyDown(KeyCode.RightArrow))
        {
            Next();
            Play();
        }

        if (test.isShown() && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Prev();
            Play();
        }
    }

    public void LoadSong(string artist, string song)
    {
        //songs.Resources.LoadAsync<AudioClip>($"Music/{artist}/{song}");
    }

    public void LoadAlbum(string artist)
    {   
        var clips =  Resources.LoadAll<AudioClip>($"Music/{artist}");
        songs = new Song[clips.Length];
        for (int i = 0; i < songs.Length; i++)
        {
            songs[i] = new Song(clips[i],artist);
        }      
        selected = 0;
        audioSource.clip = songs.ElementAt(selected).audioClip;
        test.SetText(songs.ElementAt(selected).name);
    }

    public void Next()
    {
        if (selected+1 < songs.Length)
            selected++;
    }  
    
    public void Prev()
    {
        if (selected-1 > -1)
            selected--;
    }

    public void Play( string songName = null, float time = 0)
    {
        var song = songs.Where(x => x.name == songName).FirstOrDefault();

        if (song != null) 
        {
            audioSource.clip = song.audioClip;
            test.SetText(song.name);
        }
        else
        {
            audioSource.clip = songs.ElementAt(selected).audioClip;
            test.SetText(songs.ElementAt(selected).name);
        }

        
        audioSource.time = time;
        audioSource.Play();        
    }

    public void Stop()
    {
        audioSource.Stop();
    }

    public IEnumerator FadeOut(float length, float targetVolume = 0.0f)
    {
        var rate = (audioSource.volume - targetVolume) / length;
        while (targetVolume > audioSource.volume)
        {
            audioSource.volume -= rate;
            yield return new WaitForSeconds(1);
        }
    }

      public IEnumerator FadeIn(float length, float targetVolume = 0.0f)
    {
        var rate = (audioSource.volume - targetVolume) / length;
        while (targetVolume < audioSource.volume)
        {
            audioSource.volume += rate;
            yield return new WaitForSeconds(1);
        }
    }



}


  


