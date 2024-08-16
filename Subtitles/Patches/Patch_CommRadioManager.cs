/*
[HarmonyPatch(typeof(CommRadioManager), "PlayMessage")]
class Patch_CommRadioManager_PlayMessage
{
	[HarmonyPostfix]
	static void Postfix(CommRadioManager __instance, string messageName, float cooldownTime)
	{
		string message = "";

		switch (messageName)
		{
			case "refuelContact":
				message = "Contact!";
				break;
			case "refuelFail":
				message = "Disconnect.";
				break;
			case "refuelComplete":
				message = "Refuel complete!";
				break;
		}

		if (message != "")
		{
			TutorialLabel.instance.DisplayLabel(message,
				null,
				Subtitles.groundCrewLength);
		}
	}
}
*/