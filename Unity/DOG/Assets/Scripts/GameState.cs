public class GameState {

	private static GameState instance;

	public static GameState Instance
	{
		get {
			if(instance == null)
			{
				instance = new GameState();
			}
			return instance;
		}
	}
	
	private GameState()
	{
		this.leftPortalOpen = false;
		this.rightPortalOpen = false;
		this.slowMotion = false;
		this.universalTime = 1f;
	}
	
	public void enableSlowMotion(float coeff)
	{
		this.universalTime = 1f / coeff;
		this.slowMotion = true;
	}
	
	public void disableSlowMotion()
	{
		this.universalTime = 1f;
		this.slowMotion = false;
	}
	
	
	public bool leftPortalOpen { get; set; }
	
	public bool rightPortalOpen { get; set; }
	
	private bool slowMotion;
	public bool SlowMotion {
		get { return this.slowMotion; }
	}
	
	private float universalTime;
	public float UniversalTime {
		get { return this.universalTime; }
	}
	
}
