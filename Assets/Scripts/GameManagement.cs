using System.Collections.Generic;

public static class GameManager
{

	// playe score storage class
	public static int leftPlayerScore { get; set; }
	public static int rightPlayerScore { get; set; }

	public static bool nextServe = false;


}

public class PlayerPowerUpsData
{
	public enum POWERUPS { NONE, FREEZE_OPP, SHRINK_TARGET, DEC_GRAVITY_BALL, SMASH, INC_PLAYER_MOV_SPEED };

	Dictionary<string, float> powerUpsData = new Dictionary<string, float>();

	public PlayerPowerUpsData()
	{
		powerUpsData.Add(POWERUPS.FREEZE_OPP.ToString(), 1f);
		powerUpsData.Add(POWERUPS.SHRINK_TARGET.ToString(), 3.5f);
		powerUpsData.Add(POWERUPS.DEC_GRAVITY_BALL.ToString(), 1f);
		powerUpsData.Add(POWERUPS.SMASH.ToString(), 0f);        // directly apply force on ball no duration
		powerUpsData.Add(POWERUPS.INC_PLAYER_MOV_SPEED.ToString(), 3f);
	}

	public float getPowerUpDuration(PlayerPowerUp.POWERUPS p)
	{
		return powerUpsData[p.ToString()];
	}

}
