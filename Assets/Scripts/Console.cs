using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// A UnityEngine.UI in-game player console
/// 
/// This console can take input from inputField, process it and display the results on the ingame Console UI object.
/// 
/// </summary>

public class Console : MonoBehaviour {

	/// <summary>
	/// Used to process input.
	/// </summary>
	public string inputText;
	/// <summary>
	/// Inspector assigned Text object
	/// </summary>
	/// 
	public Text consoleText;
	/// <summary>
	/// Inspector assigned Button object
	/// </summary>
	/// 
	public Button inputSubmit;
	/// <summary>
	/// Inspector assigned InputField object
	/// </summary>
	/// 
	public InputField inputField;
	/// <summary>
	/// Inspector assigned Scroller object
	/// </summary>
	/// 
	public ScrollRect scroller;

	ConsoleCommands commands = new ConsoleCommands();

	/// <summary>
	/// Always set the Scroller bar to the bottom
	/// </summary>
	void Start () {
		scroller.verticalNormalizedPosition = 0;
	}

	// Update is called once per frame
	void Update () {
		
	}
	/// <summary>
	/// Processes the user command.
	/// </summary>
	public void ProcessUserCommand()
	{
		if (inputField.text.Length > 0) {
			if (!KnownCommand (inputField.text)) {
				consoleText.text += "\nCommand: -" + inputField.text + "- not recognized.";
				inputField.text = "";
				UpdateCanvas ();
			} else {
				consoleText.text += "\nCommand: -" + inputField.text + "- accepted.";
				Invoke (inputField.text,0);
				inputField.text = "";
				UpdateCanvas ();
			}
		}
	}

	/// <summary>
	/// Forces and update on the canvas
	/// sets the Scrollbar to the bottom.
	/// </summary>
	void UpdateCanvas()
	{
		Canvas.ForceUpdateCanvases ();
		scroller.verticalNormalizedPosition = 0.0f;
	}

	/// <summary>
	/// Checks ConsoleCommands for known commands
	/// </summary>
	/// <returns><c>true</c>, if command was found in ConsoleCommands, <c>false</c> otherwise.</returns>
	/// <param name="_userInput">String to test</param>
	bool KnownCommand(string _userInput)
	{

		for (int i = 0; i < commands.validCommands.Length; i++)
		{
			if (_userInput.Equals (commands.validCommands [i])) {
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// Clears the console
	/// </summary>
	void clear() {
		consoleText.text = "";
	}

	/// <summary>
	/// Exits the application.
	/// </summary>
	void quit()
	{
		Application.Quit ();
	}

	/// <summary>
	/// Writes to the console
	/// </summary>
	/// <param name="input">string input</param>
	public void Write(string input)
	{
		consoleText.text += "\n" + input;
		UpdateCanvas ();
	}
}
