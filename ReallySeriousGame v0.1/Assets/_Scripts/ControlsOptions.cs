public class ControlsOptions
{
	public enum Controls
	{
		KeyboardControls,
		GamepadControls
	}
	
	public static Controls controls = Controls.KeyboardControls;
	
	public static void ChangeControls(Controls other)
	{
		if(controls == other) return;
		controls = other;
	}
	
	public static bool IsKeyboardControls
	{
		get
		{
			return controls == Controls.KeyboardControls;
		}
	}
	
	public static bool IsGamepadControls
	{
		get
		{
			return controls == Controls.GamepadControls;
		}
	}
}