public class BingoObjective
{
	enum ObjectiveDifficulty
	{
		Easy, Medium, Hard, Expert
	}

	enum ObjectiveCatagory
	{
		Level, Boss, Score, Rings, Keys, Character, Special
	}
	
	string ObjectiveText;
	ObjectiveCatagory Catagory;
	ObjectiveDifficulty Difficulty;
}
