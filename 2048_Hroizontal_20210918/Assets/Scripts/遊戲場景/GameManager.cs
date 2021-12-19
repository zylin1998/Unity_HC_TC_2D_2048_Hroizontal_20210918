using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	[Header("畫布結束")]
	public GameObject gpFinalCanvas;
	[Header("結束標題")]
	public Text textFinalTitle;
	
	public void ShowFInalCanvas(bool win)
	{
		goFinalCanvas.SetActive(true);

		string title = "You " + (win ? "Win" : "Lose") + "!";

		textFinalTitle.text = title;
	}
}
