using Godot;
using System;


public class Quiz : CanvasLayer
{
	[Export]
	public NodePath questionTextPath;
	
	[Signal]
	public delegate void QuizWon();
	
	[Signal]
	public delegate void End();
	
	string[] questionsList = new string[]
  	{
	  "Un arbre binaire peut avoir 2 branches.",
	  "Godot est un langage.",
	  "Le C# est un langage orienté objet.",
	  "GIF est l'acronyme de Graphics Interface Format.",
	  "Un arbre 2-3-4 est un arbre binaire H-équilibré.",
	  "Une file est une structure séquentielle.",
	  "Godot est un moteur graphique open-source.",
	  "La première version de Linux date de 1997.",
	  "1 octet = 8 bytes.",
	  "FTP est l'acronyme de File Transfer Protocol.",
	  "ASCII est l'acronyme de American Standard Computing for Information Interchange.",
	  "Le ASCII est apparu dans les années 1980.",
	  "1 bit = 8 byte.",
	  "Le processeur est aussi appelé GPU.",
	  "1 + 2 * (3 * 2 - 5) = 3.",
	  "On peut créer un site internet sans HTML."
	
  	};
	
	bool[] answerList = new bool[] 
	{
		true, false, true, false, true, true, true, false, false, true, false, false, false, false, true, false
	};
	
	int questions = 16;	
	
	private Random _random = new Random();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}
	
	private int RandRange(int min, int max)
	{
		Random r = new Random();
		return r.Next(min, max);
	}
	
	public bool answerbutton;
	
	public void set_question(int i)
	{
		
		Label questionTextPath = GetNode<Label>("button/questionText");
		
		string whichQuestion = questionsList[i];
		bool answer = answerList[i];
		answerbutton = answer;
		questionTextPath.Text = whichQuestion;
	}


	private void _on_buttonFalse_pressed()
	{
		if (answerbutton == false)
		{
			EmitSignal("QuizWon");
		}
		EmitSignal("End");
	}
	
	private void _on_buttonTrue_pressed()
	{
		if (answerbutton == true)
		{
			EmitSignal("QuizWon");
		}
		EmitSignal("End");
	}
	
	private void _on_Interface_Quiz()
	{
		int rand = RandRange(0, questions - 1);
		set_question(rand);
	}
	
}

