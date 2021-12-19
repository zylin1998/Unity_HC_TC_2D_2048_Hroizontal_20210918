using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[Header("畫布結束")]
	public GameObject goFinalCanvas;
	[Header("結束標題")]
	public Text textFinalTitle;
	
	public void ShowFInalCanvas(bool win)
	{
		goFinalCanvas.SetActive(true);

		string title = "You " + (win ? "Win" : "Lose") + "!";

		textFinalTitle.text = title;
	}

	public void ReLoadGame()
	{
		SceneManager.LoadScene("遊戲場景");
	}

	public void QuitGame() 
	{
		Application.Quit();
	}
}
