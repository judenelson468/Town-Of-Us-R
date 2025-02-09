using UnityEngine;
using TMPro;

namespace TownOfUs.Roles
{
    public class Engineer : Role
    {
        public int UsesLeft;
        public TextMeshPro UsesText;
        public bool UsedThisRound;

        public bool ButtonUsable => UsesLeft != 0 && (!UsedThisRound || !CustomGameOptions.FixPerRound);

        public Engineer(PlayerControl player) : base(player)
        {
            Name = "Engineer";
            ImpostorText = () => "Maintain important systems on the ship";
            TaskText = () => "Vent and fix a sabotage from anywhere!";
            Color = new Color(1f, 0.65f, 0.04f, 1f);
            RoleType = RoleEnum.Engineer;
            UsedThisRound = false;
            UsesLeft = (int) CustomGameOptions.FixMaxUses;
            if (UsesLeft == 0) UsesLeft = -1;
        }
    }
}