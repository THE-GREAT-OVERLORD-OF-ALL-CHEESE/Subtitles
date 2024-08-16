using HarmonyLib;

namespace CheeseMods.Subtitles
{
    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayLandedBeforeClearanceMsg")]
    class Patch_ATCVoiceProfile_PlayLandedBeforeClearanceMsg
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel(FlightSceneManager.instance.playerActor.designation.ToString() + ", Tower, you were not authorised to land.",
                null,
                Subtitles.atcLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayLandedElseWhereMsg")]
    class Patch_ATCVoiceProfile_PlayLandedElseWhereMsg
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel(FlightSceneManager.instance.playerActor.designation.ToString() + ", Tower, we lost you on radar.",
                null,
                Subtitles.atcLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayWaitForCatapultClearanceMsg")]
    class Patch_ATCVoiceProfile_PlayWaitForCatapultClearanceMsg
    {
        [HarmonyPostfix]
        static void Postfix(UnitSpawner __instance)
        {
            TutorialLabel.instance.DisplayLabel(FlightSceneManager.instance.playerActor.designation.ToString() + ", Tower, roger that, hold your position and wait for clearance.",
                null,
                Subtitles.atcLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayTaxiToCatapultMsg")]
    class Patch_ATCVoiceProfile_PlayTaxiToCatapultMsg
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance, CarrierCatapult c)
        {
            TutorialLabel.instance.DisplayLabel(FlightSceneManager.instance.playerActor.designation.ToString() + ", you are cleared to taxi to cat " + c.catapultDesignation + ".",
                null,
                Subtitles.atcLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayPreCatapultMsg")]
    class Patch_ATCVoiceProfile_PlayPreCatapultMsg
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel(FlightSceneManager.instance.playerActor.designation.ToString() + ", locked in, throttle down and run your launch checklist.",
                null,
                Subtitles.atcLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayRunUpEnginesCatapultMsg")]
    class Patch_ATCVoiceProfile_PlayRunUpEnginesCatapultMsg
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel(FlightSceneManager.instance.playerActor.designation.ToString() + ", shields up, ready to go.",
                null,
                Subtitles.atcLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayCancelledRequestMsg")]
    class Patch_ATCVoiceProfile_PlayCancelledRequestMsg
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel(FlightSceneManager.instance.playerActor.designation.ToString() + ", Tower, roger, canceling your request.",
                null,
                Subtitles.atcLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayClearedToLandCarrierMsg")]
    class Patch_ATCVoiceProfile_PlayClearedToLandCarrierMsg
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel(FlightSceneManager.instance.playerActor.designation.ToString() + ", cleared to land on the carrier.",
                null,
                Subtitles.atcLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayTaxiToRunwayMsg")]
    class Patch_ATCVoiceProfile_PlayTaxiToRunwayMsg
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance, float heading, Runway.ParallelDesignations pDes)
        {
            string message = "Copy, taxi to runway ";
            message += Subtitles.instance.RunwayDesignationString(heading, pDes);
            message += ".";
            TutorialLabel.instance.DisplayLabel(message, null, Subtitles.atcLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayRequestedWrongATCMsg")]
    class Patch_ATCVoiceProfile_PlayRequestedWrongATCMsg
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel(FlightSceneManager.instance.playerActor.designation.ToString() + ", Tower, I think you are contacting the wrong tower.",
                null,
                Subtitles.atcLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayUnableMsg")]
    class Patch_ATCVoiceProfile_PlayUnableMsg
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel(FlightSceneManager.instance.playerActor.designation.ToString() + ", Tower, unable.",
                null,
                Subtitles.atcLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayHoldShortAtRunwayMsg")]
    class Patch_ATCVoiceProfile_PlayHoldShortAtRunwayMsg
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance, float heading)
        {
            string message = FlightSceneManager.instance.playerActor.designation.ToString() + ", hold short at runway ";
            message += Subtitles.instance.HeadingString(heading);
            message += ".";

            TutorialLabel.instance.DisplayLabel(message, null, Subtitles.atcLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayClearForTakeoffRunwayMsg")]
    class Patch_ATCVoiceProfile_PlayClearForTakeoffRunwayMsg
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance, float heading)
        {
            string message = FlightSceneManager.instance.playerActor.designation.ToString() + ", Tower, cleared for take off at runway ";
            message += Subtitles.instance.HeadingString(heading);
            message += ".";

            TutorialLabel.instance.DisplayLabel(message, null, Subtitles.atcLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayClearedVerticalTakeoffMsg")]
    class Patch_ATCVoiceProfile_PlayClearedVerticalTakeoffMsg
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel(FlightSceneManager.instance.playerActor.designation.ToString() + ", Tower, cleared for vertical take off.",
                null,
                Subtitles.atcLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayClearedVerticalLandingMsg")]
    class Patch_ATCVoiceProfile_PlayClearedVerticalLandingMsg
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance, int padNumber)
        {
            TutorialLabel.instance.DisplayLabel(FlightSceneManager.instance.playerActor.designation.ToString() + ", Tower, cleared to land on pad " + padNumber + ".",
                null,
                Subtitles.atcLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayTaxiToParkingMsg")]
    class Patch_ATCVoiceProfile_PlayTaxiToParkingMsg
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel("Welcome back, follow the taxi paths to your parking area.",
                null,
                Subtitles.atcLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayLandingFlyHeadingMsg")]
    class Patch_ATCVoiceProfile_PlayLandingFlyHeadingMsg
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance, float heading, Runway runway)
        {
            string message = FlightSceneManager.instance.playerActor.designation.ToString();
            message += ", Tower, copy, fly heading ";
            message += Subtitles.instance.HeadingString(heading);
            message += ". Expect runway ";
            message += Subtitles.instance.RunwayDesignationString(VectorUtils.Bearing(runway.transform.position, runway.transform.position + runway.transform.forward), runway.parallelDesignation);
            message += ".";

            TutorialLabel.instance.DisplayLabel(message,
                null,
                Subtitles.atcLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayVerticalLandingFlyHeadingMsg")]
    class Patch_ATCVoiceProfile_PlayVerticalLandingFlyHeadingMsg
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance, float heading)
        {
            string message = FlightSceneManager.instance.playerActor.designation.ToString();
            message += ", Tower, copy, fly heading ";
            message += Subtitles.instance.HeadingString(heading);
            message += ".";

            TutorialLabel.instance.DisplayLabel(message,
                null,
                Subtitles.atcLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayLandingPatternFullMsg")]
    class Patch_ATCVoiceProfile_PlayLandingPatternFullMsg
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel(FlightSceneManager.instance.playerActor.designation.ToString() + ", Tower, the landing pattern is full. Wait for clearance.",
                null,
                Subtitles.lsoLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayLandingClearedForRunwayMsg")]
    class Patch_ATCVoiceProfile_PlayLandingClearedForRunwayMsg
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance, float heading, Runway.ParallelDesignations parallelDesignation)
        {
            string message = FlightSceneManager.instance.playerActor.designation.ToString();
            message += ", Tower, copy, cleared to land at runway ";
            message += Subtitles.instance.RunwayDesignationString(heading, parallelDesignation);
            message += ".";

            TutorialLabel.instance.DisplayLabel(message,
                null,
                Subtitles.atcLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayCallTheBallMsg")]
    class Patch_ATCVoiceProfile_PlayCallTheBallMsg
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel(FlightSceneManager.instance.playerActor.designation.ToString() + ", call the ball.",
                null,
                Subtitles.lsoLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayRogerBallMsg")]
    class Patch_ATCVoiceProfile_PlayRogerBallMsg
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel("Roger ball.",
                null,
                Subtitles.lsoLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayLSOLinedUp")]
    class Patch_ATCVoiceProfile_PlayLSOLinedUp
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel("Lined up.",
                null,
                Subtitles.lsoLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayLSOComeLeft")]
    class Patch_ATCVoiceProfile_PlayLSOComeLeft
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel("Come left.",
                null,
                Subtitles.lsoLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayLSORightForLineup")]
    class Patch_ATCVoiceProfile_PlayLSORightForLineup
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel("Right for line up.",
                null,
                Subtitles.lsoLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayLSOYoureHigh")]
    class Patch_ATCVoiceProfile_PlayLSOYoureHigh
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel("You're high.",
                null,
                Subtitles.lsoLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayLSOPowerLow")]
    class Patch_ATCVoiceProfile_PlayLSOPowerLow
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel("Power.",
                null,
                Subtitles.lsoLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayLSOHighLeft")]
    class Patch_ATCVoiceProfile_PlayLSOHighLeft
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel("You're high. Come left.",
                null,
                Subtitles.lsoLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayLSOHighRight")]
    class Patch_ATCVoiceProfile_PlayLSOHighRight
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel("You're high. Right for line up.",
                null,
                Subtitles.lsoLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayLSOLowLeft")]
    class Patch_ATCVoiceProfile_PlayLSOLowLeft
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel("Power. Come left.",
                null,
                Subtitles.lsoLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayLSOLowRight")]
    class Patch_ATCVoiceProfile_PlayLSOLowRight
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel("Power. Right for line up.",
                null,
                Subtitles.lsoLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayLSOWaveOff")]
    class Patch_ATCVoiceProfile_PlayLSOWaveOff
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel("Wave off, wave off!",
                null,
                Subtitles.lsoLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayLSOFoulDeck")]
    class Patch_ATCVoiceProfile_PlayLSOFoulDeck
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel("Foul deck, wave off!",
                null,
                Subtitles.lsoLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayLSOBolter")]
    class Patch_ATCVoiceProfile_PlayLSOBolter
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel("Bolter, bolter!",
                null,
                Subtitles.lsoLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayLSOXwire")]
    class Patch_ATCVoiceProfile_PlayLSOXwire
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance, int idx)
        {
            TutorialLabel.instance.DisplayLabel((idx + 1).ToString() + " wire!",
                null,
                Subtitles.lsoLength);
        }
    }

    [HarmonyPatch(typeof(ATCVoiceProfile), "PlayLSOReturnToHolding")]
    class Patch_ATCVoiceProfile_PlayLSOReturnToHolding
    {
        [HarmonyPostfix]
        static void Postfix(ATCVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel("Climb and return to the holding pattern, wait for clearance.",
                null,
                Subtitles.lsoLength);
        }
    }
}