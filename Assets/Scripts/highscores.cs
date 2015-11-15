
using UnityEngine;
using System.Collections;


public struct Highscore
{
	public string username;
	public int score;
	public string level;
	
	public Highscore(string _username, int _score, string _level)
	{
		username = _username;
		score = _score;
		level = _level;
	}
}

public class highscores : MonoBehaviour
{
    public string playerName = "Name: Anonymous";
    const string privateCode = "rHti1Jj9_kupSkil2g8Sjw8_Mes8UXpUi7e7GH1sES0g";
    const string publicCode = "5646f0f26e51b61a945cd3c3";
    const string webURL = "http://dreamlo.com/lb/";

	public string level = "0";

    public Highscore[] highscoresList;
	private int lastHighScore = 0;
	
    void Start()
    {
		Data data = GameObject.Find ("Data").GetComponent<Data>();
		lastHighScore = data.lastScore;
		level = data.lastLevel;
		AddNewHighscore (data.username, data.lastScore);
		GameObject.Find ("Score").GetComponent<UILabel> ().text = data.username + "      " + lastHighScore.ToString() + "s"; 
    }

    public void AddNewHighscore(string username, int score)
    {
        StartCoroutine(UploadNewHighscore(username, score));
    }

    IEnumerator UploadNewHighscore(string username, int score)
    {
		int lvl = int.Parse(level.Substring (level.Length - 1));
		WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score + "/" + lvl);
        yield return www;

        //check if the score is successful
        if (string.IsNullOrEmpty(www.error))
        {
            print("Upload Successful");
			DownloadHighscores();
        }
        else { print("Error uploading: " + www.error); }
    }

    public void DownloadHighscores()
    {
        StartCoroutine("DownloadHighscoresFromDatabase");
    }

    IEnumerator DownloadHighscoresFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        //check if the score is successful
        if (string.IsNullOrEmpty(www.error)) { GameObject.Find("ScoresLabel").GetComponent<UILabel>().text = FormatToBeDisplayer(www.text); }
        else { print("Error Downloading: " + www.error); }
    }

    public string FormatToBeDisplayer(string someText)
    {
        string[] entries = someText.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];
        string test = string.Empty; 
        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoresList[i] = new Highscore(username, score, entryInfo[2]);
            someText = highscoresList[i].level + "/ " + highscoresList[i].username + ": " + highscoresList[i].score + "\n";
            test += someText;
        }
        return test;
    }
}