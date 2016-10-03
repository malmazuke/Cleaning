using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections;

public class GameController : MonoBehaviour {

    #region Public Properties

    public int totalTimeInSeconds = 180;
    public Text timeRemainingText;

    #endregion

    #region Private Properties

    float timeRemaining;

    #endregion

    #region Unity Methods
	void Awake () {
	    timeRemaining = totalTimeInSeconds;
	}

    void Start() {
        UpdateTimeRemainingText ();
    }

	void Update () {
	    if (timeRemaining <= 0.0f) {
            GameOver ();
            return;
        }

        timeRemaining -= Time.deltaTime;
        UpdateTimeRemainingText ();
	}

    #endregion

    #region Private Methods

    void GameOver () {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
    }

    void UpdateTimeRemainingText () {
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeRemaining);
        timeRemainingText.text = String.Format ("Time Remaining: {0:00}:{1:00}:{2:00}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
    }

    #endregion
}
