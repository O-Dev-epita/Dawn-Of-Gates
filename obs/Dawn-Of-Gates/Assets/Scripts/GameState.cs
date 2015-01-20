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
	}
	
	
	public bool leftPortalOpen {
		get;
		set;
	}
	
	public bool rightPortalOpen {
		get;
		set;
	}
}
