using UnityEngine;
using System.Collections;

//

public class RandomDirection {

	//[SerializeField] GameObject[] _directionButton;
	[SerializeField] int randomIndex = 4;

	//= Random.Range(0, deck.Length);

	public int RandomBunber()
	{
		return Random.Range(0,randomIndex);
	}		

}
