using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotLibrary
{
    public enum CHIP_TYPE
    {
        SORT_CHIP = 0,
        TOTAL_CHIP
    }

    public enum SORT_DIRECTION
    {
        ASCENDING = 0,
        DESCENDING
    }

    public class Chip
    {
        public CHIP_TYPE cType;
        public Chip()
        { }

        public virtual int ChipLogic(int[] arr)
        {

            return 0;
        }

        public virtual int[] ChipLogic(int[] arr, SORT_DIRECTION sortDir)
        {

            return null;
        }

    }

    public class sortChip : Chip
    {

        public sortChip()
        {
            cType = CHIP_TYPE.SORT_CHIP;
        }

        public override int ChipLogic(int[] ari)
        {
            int sum = 0;
            foreach (int i in ari)
            {
                sum += i * i;
            }

            return sum;
        }
    }

    public class totalChip : Chip
    {

        public totalChip()
        {
            cType = CHIP_TYPE.TOTAL_CHIP;
        }

        public override int ChipLogic(int[] arr)
        {
            int total = arr.Length;

            return total;
        }
    }


    public class Robot
    {
        string sRobotName;
        private List<Chip> lstChips;
        private HashSet<Chip> hsChips;

        public Robot()
        {
            lstChips = new List<Chip>();
            hsChips = new HashSet<Chip>();
            sRobotName = "WLRobot;";
        }

        public string RobotName
        {
            get { return sRobotName; }
        }

        public int UniqueChips
        {
            get { return hsChips.Count; }
        }

        public void PlugChip(Chip c)
        {
            lstChips.Insert(0, c);
            hsChips.Add(c);
        }

        public int ExecChipLogic(int[] arr)
        {
            int rs = -1;

            if (lstChips.Count > 0)
            {
                Chip currChip = lstChips[0];
                
                rs = currChip.ChipLogic(arr);
            }
            return rs;
        }

        public int[] ExecChipLogic(int[] arr, SORT_DIRECTION sortDir = SORT_DIRECTION.DESCENDING)
        {
            int[] resultArr = arr;

            if (lstChips.Count > 0)
            {
                Chip currChip = lstChips[0];

                resultArr = currChip.ChipLogic(arr, sortDir);
            }
            return resultArr;
        }
    }

    public class Solution
    {
        static void Main(string[] args)
        {
            Robot testRobot = new Robot();
            int[] arr = new int[] { -1, 8, 3, 7, 21, 1 };

            sortChip sc = new sortChip();

            testRobot.PlugChip(sc);

            Console.WriteLine("The chip response {0}", testRobot.ExecChipLogic(arr).ToString());

            totalChip tc = new totalChip();

            testRobot.PlugChip(tc);

            Console.WriteLine("The chip response {0}", testRobot.ExecChipLogic(arr).ToString());

            sortChip sc2 = new sortChip();

            Console.WriteLine("The chip response {0}", testRobot.ExecChipLogic(arr).ToString());

            Console.WriteLine("The unique chip count {0}", testRobot.UniqueChips.ToString());

        }
    }

}
