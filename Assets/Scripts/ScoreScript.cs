using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour {

	[SerializeField] public string teamName = "Team One";
	[SerializeField] public TextMeshProUGUI text;
	private int score = 0;

	public void AddNewScore() {
		score += 1;
		UpdateScoreText();
	}
	private void Start() {
		UpdateScoreText();
	}

	private void UpdateScoreText() {
		text.text = teamName + ": " + score.ToString();
	}
}
