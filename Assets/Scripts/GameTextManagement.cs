using UnityEngine;
using UnityEngine.UI;

public class GameTextManagement : MonoBehaviour
{
	public Text leftPlayerScore;
	public Text rightPlayerScore;

	void Update()
	{
		leftPlayerScore.text = GameManager.leftPlayerScore.ToString();
		rightPlayerScore.text = GameManager.rightPlayerScore.ToString();
	}

}
