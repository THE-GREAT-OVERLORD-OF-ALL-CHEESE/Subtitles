using HarmonyLib;

namespace CheeseMods.Subtitles
{
    [HarmonyPatch(typeof(GroundCrewVoiceProfile), "PlayMessage")]
	class Patch_GroundCrewVoiceProfile_PlayMessage
	{
		[HarmonyPostfix]
		static void Postfix(GroundCrewVoiceProfile __instance, GroundCrewVoiceProfile.GroundCrewMessages m)
		{
			string message = "";

			switch (m)
			{
				case GroundCrewVoiceProfile.GroundCrewMessages.NotAvailable:
					message = "Negative, rearming is not available.";
					break;
				case GroundCrewVoiceProfile.GroundCrewMessages.IsAirborne:
					message = "Copy, return to base and we can fix you up.";
					break;
				case GroundCrewVoiceProfile.GroundCrewMessages.TaxiToStation:
					message = "Copy, taxi over to a rearming station.";
					break;
				case GroundCrewVoiceProfile.GroundCrewMessages.EnteredStation:
					message = "Ready to rearm and refuel.";
					break;
				case GroundCrewVoiceProfile.GroundCrewMessages.TurnOffEngines:
					message = "Negative, your engines are still running.";
					break;
				case GroundCrewVoiceProfile.GroundCrewMessages.DisarmWeapons:
					message = "Negative, you need to dissarm your weapons.";
					break;
				case GroundCrewVoiceProfile.GroundCrewMessages.Success:
					message = "Copy that, tell us what you need.";
					break;
				case GroundCrewVoiceProfile.GroundCrewMessages.ReturnedToVehicle:
					message = "You are good to go.";
					break;
			}

			TutorialLabel.instance.DisplayLabel(message,
				null,
				Subtitles.groundCrewLength);
		}
	}
}