using HarmonyLib;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CheeseMods.Subtitles
{
    [HarmonyPatch(typeof(AWACSVoiceProfile), "ReportGoingDown")]
    class Patch_AWACSVoiceProfile_ReportGoingDown
    {
        [HarmonyPostfix]
        static void Postfix(AWACSVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel("Mayday, Mayday, Mayday! Overlord is going down!",
                null,
                Subtitles.awacsLength);
        }
    }

    [HarmonyPatch(typeof(AWACSVoiceProfile), "ReportGrandSlam")]
    class Patch_AWACSVoiceProfile_ReportGrandSlam
    {
        [HarmonyPostfix]
        static void Postfix(AWACSVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel(FlightSceneManager.instance.playerActor.designation.ToString() + ", overlord, grandslam.",
                null,
                Subtitles.awacsLength);
        }
    }

    [HarmonyPatch(typeof(AWACSVoiceProfile), "ReportGroup")]
    class Patch_AWACSVoiceProfile_ReportGroup
    {
        [HarmonyPostfix]
        static void Postfix(AWACSVoiceProfile __instance, Vector3 pos, Vector3 velocity, bool braaOnly)
        {
            Vector3 referencePos = FlightSceneManager.instance.playerActor.position;
            bool bullseye = !braaOnly && WaypointManager.instance && WaypointManager.instance.bullseye;
            if (bullseye)
            {
                referencePos = WaypointManager.instance.bullseye.position;
            }

            string message = FlightSceneManager.instance.playerActor.designation.ToString() + ", overlord"; ;
            if (bullseye)
            {
                message += ", group bullseye, ";
            }
            else
            {
                message += ", group BRAA, ";
            }

            message += Subtitles.instance.BearingString(referencePos, pos);
            message += ", ";
            message += Subtitles.instance.RangeString(referencePos, pos);
            message += ", ";
            message += Subtitles.instance.AltitudeString(pos);
            message += ", ";
            message += Subtitles.instance.AzumithString(pos, velocity);
            message += ".";


            TutorialLabel.instance.DisplayLabel(message,
                null,
                Subtitles.awacsLength);
        }
    }

    [HarmonyPatch(typeof(AWACSVoiceProfile), "ReportGroups")]
    class Patch_AWACSVoiceProfile_ReportGroups
    {
        [HarmonyPostfix]
        static void Postfix(List<AIAWACSSpawn.ContactGroup> groups, int offset, int count)
        {
            Vector3 referencePos = FlightSceneManager.instance.playerActor.position;
            bool bullseye = WaypointManager.instance && WaypointManager.instance.bullseye;
            if (bullseye)
            {
                referencePos = WaypointManager.instance.bullseye.position;
            }

            int num = offset;
            int num2 = 0;

            string message = "Overlord, picture. ";
            while (num < groups.Count && num2 < count)
            {
                AIAWACSSpawn.ContactGroup contactGroup = groups[num];
                if (contactGroup.count > 1)
                {
                    if (bullseye)
                    {
                        message += "Group bullseye, ";
                    }
                    else
                    {
                        message += "Group BRAA, ";
                    }
                }
                else
                {
                    if (bullseye)
                    {
                        message += "Hostile bullseye, ";
                    }
                    else
                    {
                        message += "Hostile BRAA, ";
                    }
                }

                Vector3 position = contactGroup.globalPos.point;
                Vector3 velocity = contactGroup.velocity;

                message += Subtitles.instance.BearingString(referencePos, position);
                message += ", ";
                message += Subtitles.instance.RangeString(referencePos, position);
                message += ", ";
                message += Subtitles.instance.AltitudeString(position);
                message += ", ";
                message += Subtitles.instance.AzumithString(position, velocity);
                message += ". ";

                num++;
                num2++;
            }

            TutorialLabel.instance.DisplayLabel(message,
                null,
                Subtitles.awacsLength);
        }
    }

    [HarmonyPatch(typeof(AWACSVoiceProfile), "ReportHomeplateBra")]
    class Patch_AWACSVoiceProfile_ReportHomeplateBra
    {
        [HarmonyPostfix]
        static void Postfix(AWACSVoiceProfile __instance, Vector3 homePos)
        {
            string message = FlightSceneManager.instance.playerActor.designation.ToString() + ", overlord"; ;
            message += ", homeplate BRAA, ";

            message += Subtitles.instance.BearingString(FlightSceneManager.instance.playerActor.position, homePos);
            message += ", ";
            message += Subtitles.instance.RangeString(FlightSceneManager.instance.playerActor.position, homePos);
            message += ".";


            TutorialLabel.instance.DisplayLabel(message,
                null,
                Subtitles.awacsLength);
        }
    }

    [HarmonyPatch(typeof(AWACSVoiceProfile), "ReportHostile")]
    class Patch_AWACSVoiceProfile_ReportHostile
    {
        [HarmonyPostfix]
        static void Postfix(AWACSVoiceProfile __instance, Vector3 pos, Vector3 velocity, bool braaOnly)
        {
            Vector3 referencePos = FlightSceneManager.instance.playerActor.position;
            bool bullseye = !braaOnly && WaypointManager.instance && WaypointManager.instance.bullseye;
            if (bullseye)
            {
                referencePos = WaypointManager.instance.bullseye.position;
            }

            string message = FlightSceneManager.instance.playerActor.designation.ToString() + ", overlord"; ;
            if (bullseye)
            {
                message += ", hostile bullseye, ";
            }
            else
            {
                message += ", hostile BRAA, ";
            }

            message += Subtitles.instance.BearingString(referencePos, pos);
            message += ", ";
            message += Subtitles.instance.RangeString(referencePos, pos);
            message += ", ";
            message += Subtitles.instance.AltitudeString(pos);
            message += ", ";
            message += Subtitles.instance.AzumithString(pos, velocity);
            message += ".";


            TutorialLabel.instance.DisplayLabel(message,
                null,
                Subtitles.awacsLength);
        }
    }

    [HarmonyPatch(typeof(AWACSVoiceProfile), "ReportPictureClean")]
    class Patch_AWACSVoiceProfile_ReportPictureClean
    {
        [HarmonyPostfix]
        static void Postfix(AWACSVoiceProfile __instance)
        {
            string message = FlightSceneManager.instance.playerActor.designation.ToString() + ", overlord"; ;

            message += ", picture clean.";

            TutorialLabel.instance.DisplayLabel(message,
                null,
                Subtitles.awacsLength);
        }
    }

    [HarmonyPatch(typeof(AWACSVoiceProfile), "ReportPopups", new Type[] { typeof(List<AIAWACSSpawn.ContactGroup>), typeof(int), typeof(int) })]
    class Patch_AWACSVoiceProfile_ReportPopups
    {
        [HarmonyPostfix]
        static void Postfix(List<AIAWACSSpawn.ContactGroup> groups, int offset, int count)
        {
            Vector3 referencePos = FlightSceneManager.instance.playerActor.position;
            bool bullseye = WaypointManager.instance && WaypointManager.instance.bullseye;
            if (bullseye)
            {
                referencePos = WaypointManager.instance.bullseye.position;
            }

            int num = offset;
            int num2 = 0;

            string message = FlightSceneManager.instance.playerActor.designation.ToString() + ", overlord"; ;
            message += ", popup. ";

            while (num < groups.Count && num2 < count)
            {
                AIAWACSSpawn.ContactGroup contactGroup = groups[num];
                if (contactGroup.count > 1)
                {
                    if (bullseye)
                    {
                        message += "Group bullseye, ";
                    }
                    else
                    {
                        message += "Group BRAA, ";
                    }
                }
                else
                {
                    if (bullseye)
                    {
                        message += "Hostile bullseye, ";
                    }
                    else
                    {
                        message += "Hostile BRAA, ";
                    }
                }

                Vector3 position = contactGroup.globalPos.point;
                Vector3 velocity = contactGroup.velocity;

                message += Subtitles.instance.BearingString(referencePos, position);
                message += ", ";
                message += Subtitles.instance.RangeString(referencePos, position);
                message += ", ";
                message += Subtitles.instance.AltitudeString(position);
                message += ", ";
                message += Subtitles.instance.AzumithString(position, velocity);
                message += ". ";

                num++;
                num2++;
            }

            TutorialLabel.instance.DisplayLabel(message,
                null,
                Subtitles.awacsLength);
        }
    }

    [HarmonyPatch(typeof(AWACSVoiceProfile), "ReportRTB")]
    class Patch_AWACSVoiceProfile_ReportRTB
    {
        [HarmonyPostfix]
        static void Postfix(AWACSVoiceProfile __instance)
        {
            TutorialLabel.instance.DisplayLabel("Overlord is off station, we are RTB",
                null,
                Subtitles.awacsLength);
        }
    }

    [HarmonyPatch(typeof(AWACSVoiceProfile), "ReportThreatToAwacs")]
    class Patch_AWACSVoiceProfile_ReportThreatToAwacs
    {
        [HarmonyPostfix]
        static void Postfix(AWACSVoiceProfile __instance, int count, Vector3 pos, Vector3 velocity)
        {
            Vector3 referencePos = FlightSceneManager.instance.playerActor.position;

            string message = FlightSceneManager.instance.playerActor.designation.ToString() + ", overlord";

            if (count > 1)
            {
                message += " group BRAA, ";
            }
            else
            {
                message += ", hostile BRAA, ";
            }

            message += Subtitles.instance.BearingString(referencePos, pos);
            message += ", ";
            message += Subtitles.instance.RangeString(referencePos, pos);
            message += ", ";
            message += Subtitles.instance.AltitudeString(pos);
            message += ", ";
            message += Subtitles.instance.AzumithString(pos, velocity);
            message += ", leans on overlord!";


            TutorialLabel.instance.DisplayLabel(message,
                null,
                Subtitles.awacsLength);
        }
    }

    [HarmonyPatch(typeof(AWACSVoiceProfile), "ReportUnable")]
    class Patch_AWACSVoiceProfile_ReportUnable
    {
        [HarmonyPostfix]
        static void Postfix(AWACSVoiceProfile __instance)
        {
            string message = FlightSceneManager.instance.playerActor.designation.ToString() + ", overlord";

            message += ", unable.";

            TutorialLabel.instance.DisplayLabel(message,
                null,
                Subtitles.awacsLength);
        }
    }
}