using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[Header("�e������")]
	public GameObject goFinalCanvas;
	[Header("�������D")]
	public Text textFinalTitle;
	
	public void ShowFInalCanvas(bool win)
	{
		goFinalCanvas.SetActive(true);

		string title = "You " + (win ? "Win" : "Lose") + "!";

		textFinalTitle.text = title;
	}

	public void ReLoadGame()
	{
		SceneManager.LoadScene("�C������");
	}

	public void QuitGame() 
	{
		Application.Quit();
	}
}
