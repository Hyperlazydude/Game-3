using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwitchScene{
	private static SwitchScene instance = new SwitchScene ();
	public static SwitchScene Instance
	{
		get { return SwitchScene.instance; }
	}

	private readonly string[] levels = new string[] {"level-1", "level-2", "level-3", "level-4", "level-5"};
	private int currentLevel;

	private SwitchScene(){
		this.currentLevel = 0;
	}
		
	public void ShuffleLevel()
	{
		this.currentLevel = 0;

		for (int i = 0; i < this.levels.Length - 1; i++) 
		{
			int intLevel = Random.Range (i, this.levels.Length - 1);
			string swapOut = this.levels [i];
			this.levels [i] = this.levels [intLevel];
			this.levels [intLevel] = swapOut;
		}
	}

	public string GetLevel ()
	{
		return this.levels [this.currentLevel++];
	}

}
