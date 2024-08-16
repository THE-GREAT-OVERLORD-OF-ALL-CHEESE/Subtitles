using ModLoader.Framework;
using ModLoader.Framework.Attributes;
using UnityEngine;


namespace CheeseMods.Subtitles
{
    [ItemId("cheese.subtitles")]
    public class Subtitles : VtolMod
    {
        public static Subtitles instance;

        public static float atcLength = 5;
        public static float lsoLength = 2;
        public static float wingmanLength = 2;
        public static float groundCrewLength = 5;
        public static float awacsLength = 20;
        public static float refuelPlaneLength = 5;

        public class AWACSRange
        {
            public float distance;
            public string name;

            public AWACSRange(float distance, string name)
            {
                this.distance = distance;
                this.name = name;
            }
        }

        public AWACSRange[] ranges;
        public AWACSRange[] altitudes;
        public AWACSRange[] cardinalDirs;

        public void Awake()
        {
            Debug.Log("Patched Subtitles");

            instance = this;

            ranges = new AWACSRange[] {
            new AWACSRange(1, "1"),
            new AWACSRange(2, "2"),
            new AWACSRange(3, "3"),
            new AWACSRange(4, "4"),
            new AWACSRange(5, "5"),
            new AWACSRange(6, "6"),
            new AWACSRange(7, "7"),
            new AWACSRange(8, "8"),
            new AWACSRange(9, "9"),
            new AWACSRange(10, "10"),
            new AWACSRange(12, "12"),
            new AWACSRange(14, "14"),
            new AWACSRange(16, "16"),
            new AWACSRange(18, "18"),
            new AWACSRange(20, "20"),
            new AWACSRange(25, "25"),
            new AWACSRange(30, "30"),
            new AWACSRange(35, "35"),
            new AWACSRange(40, "40"),
            new AWACSRange(50, "50"),
            new AWACSRange(60, "60")
        };

            altitudes = new AWACSRange[] {
            new AWACSRange(1, "1,000"),
            new AWACSRange(2, "2,000"),
            new AWACSRange(3, "3,000"),
            new AWACSRange(4, "4,000"),
            new AWACSRange(5, "5,000"),
            new AWACSRange(6, "6,000"),
            new AWACSRange(7, "7,000"),
            new AWACSRange(8, "8,000"),
            new AWACSRange(9, "9,000"),
            new AWACSRange(10, "10,000"),
            new AWACSRange(12, "12,000"),
            new AWACSRange(14, "14,000"),
            new AWACSRange(16, "16,000"),
            new AWACSRange(18, "18,000"),
            new AWACSRange(20, "20,000"),
            new AWACSRange(25, "25,000"),
            new AWACSRange(30, "30,000"),
            new AWACSRange(35, "35,000")
        };

            cardinalDirs = new AWACSRange[] {
            new AWACSRange(0, "tracking north"),
            new AWACSRange(90, "tracking east"),
            new AWACSRange(180, "tracking south"),
            new AWACSRange(270, "tracking west"),
            new AWACSRange(360, "tracking north")
        };
        }

        public string HeadingString(float heading)
        {
            int intHeading = Mathf.RoundToInt(heading / 10f);
            if (intHeading == 0)
            {
                intHeading = 36;
            }
            return intHeading.ToString();
        }

        public string RunwayDesignationString(float heading, Runway.ParallelDesignations designation)
        {
            string message = HeadingString(heading);
            switch (designation)
            {
                case Runway.ParallelDesignations.Left:
                    message += " left";
                    break;
                case Runway.ParallelDesignations.Center:
                    message += " center";
                    break;
                case Runway.ParallelDesignations.Right:
                    message += " right";
                    break;
                case Runway.ParallelDesignations.None:
                    break;
            }
            return message;
        }

        public string BearingString(Vector3 from, Vector3 to)
        {
            return Mathf.RoundToInt(VectorUtils.Bearing(from, to)).ToString("000");
        }

        public string RangeString(Vector3 from, Vector3 to, bool merge = true)
        {
            float range = Vector3.ProjectOnPlane(from - to, Vector3.up).magnitude;
            if (merge && range < 2000f)
            {
                return "merged";
            }
            range = MeasurementManager.instance.ConvertedDistance(range);
            if (MeasurementManager.instance.distanceMode == MeasurementManager.DistanceModes.Meters)
            {
                range /= 1000f;
            }
            return GetClosestRangeString(range);
        }

        public string AltitudeString(Vector3 pos)
        {
            float altitude = WaterPhysics.GetAltitude(pos);
            if (altitude < 1500f)
            {
                return "low";
            }

            altitude = MeasurementManager.instance.ConvertedAltitude(altitude) / 1000;
            return GetClosestAltitudeString(altitude);
        }

        public string AzumithString(Vector3 position, Vector3 velocity)
        {
            string message = "";

            float num = Vector3.Dot(velocity.normalized, (position - FlightSceneManager.instance.playerActor.position).normalized);
            if (num < -0.8f)
            {
                message += "hot";
            }
            else if (num > 0.5f)
            {
                message += "cold";
            }
            else
            {
                message += GetClosestCardinalString(VectorUtils.Bearing(Vector3.zero, velocity));
            }

            if (velocity.magnitude > 340f)
            {
                message += ", fast";
            }

            return message;
        }

        public string GetClosestRangeString(float actual)
        {
            string closest = actual.ToString();
            float closestDifference = float.MaxValue;

            foreach (AWACSRange range in ranges)
            {
                float difference = Mathf.Abs(range.distance - actual);
                if (difference < closestDifference)
                {
                    closestDifference = difference;
                    closest = range.name;
                }
            }
            return closest;
        }

        public string GetClosestAltitudeString(float actual)
        {
            string closest = actual.ToString();
            float closestDifference = float.MaxValue;

            foreach (AWACSRange altitude in altitudes)
            {
                float difference = Mathf.Abs(altitude.distance - actual);
                if (difference < closestDifference)
                {
                    closestDifference = difference;
                    closest = altitude.name;
                }
            }
            return closest;
        }

        public string GetClosestCardinalString(float actual)
        {
            string closest = actual.ToString();
            float closestDifference = float.MaxValue;

            foreach (AWACSRange cardinalDir in cardinalDirs)
            {
                float difference = Mathf.Abs(cardinalDir.distance - actual);
                if (difference < closestDifference)
                {
                    closestDifference = difference;
                    closest = cardinalDir.name;
                }
            }
            return closest;
        }

        public override void UnLoad()
        {
            Debug.Log("Cheeses Subtitles Mod: Nothing to unload! =3");
        }
    }
}