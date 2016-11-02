using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    // Constant Values
    public readonly static float ms_SizeFactor = 0.2f;
    public readonly static int ms_ScoreFactor = 10;
    public readonly static int ms_FirstSpawnNum = 5;

    // Play Time Management
    public float m_GameTime;
	public float m_TotalPauseTime;  // < =  m_LevelStartTime
	public float m_PauseStartTime;
	public bool m_Pause = false;
	public float m_PlayTime = 30f;

    // Static Values
	public static int ms_Score;
    public static int ms_TotalScore;
    public static int ms_CurSpawnNum = 5;

    // Level and Etc
	public int m_NextLevelScore = 40;

	public string m_NextLevel;
    public string m_TitleScene;

	public TextMesh m_TimeMesh;

    private GameObject m_EnemyManager;
    private GameObject m_T1;


	void PauseClicked()
	{
		if(m_Pause)
		{
			print ("UnPause");
			m_TotalPauseTime += Time.realtimeSinceStartup - m_PauseStartTime;
			m_Pause = false;
		}
		else
		{
			print ("Pause");
			m_PauseStartTime = Time.realtimeSinceStartup;
			m_Pause = true;
		}	
	}

    void EndProcess()
    {
        ms_TotalScore += ms_Score;
        ms_Score = 0;

        m_EnemyManager.SendMessage("DontUseAllGOs");

        m_T1.SendMessage("Init");
    }

    void ToTitle()
    {
        EndProcess();
        Application.LoadLevel(m_TitleScene);
        ms_CurSpawnNum = ms_FirstSpawnNum;
    }
    
    void ToEnd()
    {
        EndProcess();
        Application.LoadLevel("3End");
        ms_CurSpawnNum = ms_FirstSpawnNum;
    }

	void NextLevel()
	{
        EndProcess();
		//Application.LoadLevel(m_NextLevel);

        ms_CurSpawnNum += 2;
        
        m_NextLevelScore = ms_CurSpawnNum * ms_ScoreFactor;

        PlayerPrefs.SetInt("CurSpawnNum", ms_CurSpawnNum);

        m_EnemyManager.SendMessage("Init");
	}


	void Start () {
		m_TotalPauseTime = Time.realtimeSinceStartup;
        if (m_TitleScene == null)
        {
            m_TitleScene = "1Title";
        }

        m_EnemyManager = GameObject.Find("/Enemies");

        PlayerPrefs.SetInt("CurSpawnNum", ms_FirstSpawnNum);
        ms_CurSpawnNum = PlayerPrefs.GetInt("CurSpawnNum", ms_FirstSpawnNum);
        m_NextLevelScore = ms_CurSpawnNum * ms_ScoreFactor;

        m_T1 = GameObject.FindGameObjectWithTag("Player");
	}
		
	void Update () {
		if(!m_Pause)
		{
			m_GameTime = Time.realtimeSinceStartup - m_TotalPauseTime;
			m_TimeMesh.text = "Time : " + ( (int)m_GameTime ).ToString();

            // Next Level by Time
			//if (m_GameTime > m_PlayTime)
			{
				//NextLevel();
			}


            // Next Level by Score
            if (ms_Score >= m_NextLevelScore)
            {
                NextLevel();
            }
		}
	}

	void OnGUI()
	{
		GUI.Label(new Rect(10, 10, 100, 20), "Score : " + ms_Score.ToString());
	}

}











