using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harmony;
using UnityEngine;

[HarmonyPatch(typeof(WingmanVoiceProfile), "PlayMessage")]
class Patch_WingmanVoiceProfile_PlayMessage
{
	[HarmonyPostfix]
	static void Postfix(WingmanVoiceProfile __instance, WingmanVoiceProfile.Messages m)
	{
		string message = "";

		switch (m)
		{
			case WingmanVoiceProfile.Messages.Fox2:
				message = "Fox 2!";
				break;
			case WingmanVoiceProfile.Messages.Fox3:
				message = "Fox 3!";
				break;
			case WingmanVoiceProfile.Messages.Rifle:
				message = "Rifle!";
				break;
			case WingmanVoiceProfile.Messages.Bruiser:
				message = "Bruiser!";
				break;
			case WingmanVoiceProfile.Messages.Magnum:
				message = "Magnum!";
				break;
			case WingmanVoiceProfile.Messages.Pickle:
				message = "Pickle!";
				break;
			case WingmanVoiceProfile.Messages.Guns:
				message = "Guns! Guns! Guns!";
				break;
			case WingmanVoiceProfile.Messages.Shack:
				message = "Shack!";
				break;
			case WingmanVoiceProfile.Messages.GroundMiss:
				message = "I missed the ground target.";
				break;
			case WingmanVoiceProfile.Messages.Splash:
				message = "Splash!";
				break;
			case WingmanVoiceProfile.Messages.AirMiss:
				message = "My missile was defeated.";
				break;
			case WingmanVoiceProfile.Messages.EngagingTargets:
				message = "Arming weapons.";
				break;
			case WingmanVoiceProfile.Messages.CopyAttackOrder:
				message = "Copy that, attacking your target.";
				break;
			case WingmanVoiceProfile.Messages.AttackOrderComplete:
				message = "I destroyed your target";
				break;
			case WingmanVoiceProfile.Messages.DefendingMissile:
				message = "Going defensive!";
				break;
			case WingmanVoiceProfile.Messages.DefeatedMissile:
				message = "Missile defeated.";
				break;
			case WingmanVoiceProfile.Messages.MissileOnPlayer:
				message = "There's a missile going for you!";
				break;
			case WingmanVoiceProfile.Messages.BanditOnYourSix:
				message = "There's a bandit on your 6!";
				break;
			case WingmanVoiceProfile.Messages.LowFuel:
				message = "Low fuel, I'm returning to base.";
				break;
			case WingmanVoiceProfile.Messages.ShotDown:
				message = "I've been shot down! Ejecting!";
				break;
			case WingmanVoiceProfile.Messages.Copy:
				message = "Copy.";
				break;
			case WingmanVoiceProfile.Messages.Deny:
				message = "Unable.";
				break;
			case WingmanVoiceProfile.Messages.ReturningToBase:
				message = "I'm returning to base.";
				break;
		}

		if (message != "")
		{
			TutorialLabel.instance.DisplayLabel(message,
				null,
				Subtitles.wingmanLength);
		}
	}
}