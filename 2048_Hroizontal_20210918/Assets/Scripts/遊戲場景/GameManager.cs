using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	[Header("�e������")]
	public GameObject gpFinalCanvas;
	[Header("�������D")]
	public Text textFinalTitle;
	
	public void ShowFInalCanvas(bool win)
	{
		goFinalCanvas.SetActive(true);

		string title = "You " + (win ? "Win" : "Lose") + "!";

		textFinalTitle.text = title;
	}
}
