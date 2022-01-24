using TownOfUs.CrewmateRoles.EngineerMod;
using TownOfUs.CrewmateRoles.MedicMod;
using TownOfUs.CrewmateRoles.SeerMod;
using TownOfUs.CustomOption;
using TownOfUs.NeutralRoles.ExecutionerMod;
using TownOfUs.NeutralRoles.ShifterMod;
using TownOfUs.NeutralRoles.AgentMod;
using TownOfUs.CrewmateRoles.HaunterMod;

namespace TownOfUs
{
    public static class CustomGameOptions
    {
        public static int MayorOn => (int)Generate.MayorOn.Get();
        public static int JesterOn => (int)Generate.JesterOn.Get();
        public static int LoversOn => (int)Generate.LoversOn.Get();
        public static int SheriffOn => (int)Generate.SheriffOn.Get();
        public static int JanitorOn => (int)Generate.JanitorOn.Get();
        public static int EngineerOn => (int)Generate.EngineerOn.Get();
        public static int SwapperOn => (int)Generate.SwapperOn.Get();
        public static int ShifterOn => (int)Generate.ShifterOn.Get();
        public static int InvestigatorOn => (int)Generate.InvestigatorOn.Get();
        public static int TimeLordOn => (int)Generate.TimeLordOn.Get();
        public static int MedicOn => (int)Generate.MedicOn.Get();
        public static int SeerOn => (int)Generate.SeerOn.Get();
        public static int GlitchOn => (int)Generate.GlitchOn.Get();
        public static int MorphlingOn => (int)Generate.MorphlingOn.Get();
        public static int CamouflagerOn => (int)Generate.CamouflagerOn.Get();
        public static int ExecutionerOn => (int)Generate.ExecutionerOn.Get();
        public static int SpyOn => (int)Generate.SpyOn.Get();
        public static int SnitchOn => (int)Generate.SnitchOn.Get();
        public static int MinerOn => (int)Generate.MinerOn.Get();
        public static int SwooperOn => (int)Generate.SwooperOn.Get();
        public static int ArsonistOn => (int)Generate.ArsonistOn.Get();
        public static int AltruistOn => (int)Generate.AltruistOn.Get();
        public static int UndertakerOn => (int)Generate.UndertakerOn.Get();
        public static int AssassinOn => (int)Generate.AssassinOn.Get();
        public static int UnderdogOn => (int)Generate.UnderdogOn.Get();
        public static int PhantomOn => (int)Generate.PhantomOn.Get();
        public static int RetributionistOn => (int)Generate.RetributionistOn.Get();
        public static int HaunterOn => (int)Generate.HaunterOn.Get();
        public static int GrenadierOn => (int)Generate.GrenadierOn.Get();
        public static int MediumOn => (int)Generate.MediumOn.Get();
        public static int TransporterOn => (int)Generate.TransporterOn.Get();
        public static int AgentOn => (int)Generate.AgentOn.Get();
        public static int MastermindOn => (int)Generate.MastermindOn.Get();
        public static int TorchOn => (int)Generate.TorchOn.Get();
        public static int DiseasedOn => (int)Generate.DiseasedOn.Get();
        public static int FlashOn => (int)Generate.FlashOn.Get();
        public static int TiebreakerOn => (int)Generate.TiebreakerOn.Get();
        public static int DrunkOn => (int)Generate.DrunkOn.Get();
        public static int BigBoiOn => (int)Generate.BigBoiOn.Get();
        public static int ButtonBarryOn => (int)Generate.ButtonBarryOn.Get();
        public static int VanillaGame => (int)Generate.VanillaGame.Get();
        public static float InitialCooldowns => Generate.InitialCooldowns.Get();
        public static int GlitchShieldUntilKills => (int)Generate.GlitchShieldUntilKills.Get();
        public static GlitchProtectRevealEnum GlitchShieldReveal => (GlitchProtectRevealEnum) Generate.GlitchShieldReveal.Get();
        public static int ImpShieldUntilKills => (int)Generate.ImpShieldUntilKills.Get();
        public static ImpProtectRevealEnum ImpShieldReveal => (ImpProtectRevealEnum) Generate.ImpShieldReveal.Get();
        public static bool BothLoversDie => Generate.BothLoversDie.Get();
        public static bool ShowSheriff => Generate.ShowSheriff.Get();
        public static bool SheriffKillOther => Generate.SheriffKillOther.Get();
        public static bool SheriffKillsJester => Generate.SheriffKillsJester.Get();
        public static bool SheriffKillsGlitch => Generate.SheriffKillsGlitch.Get();
        public static bool SheriffKillsAgent => Generate.SheriffKillsAgent.Get();
        public static bool SheriffKillsExecutioner => Generate.SheriffKillsExecutioner.Get();
        public static bool SheriffKillsArsonist => Generate.SheriffKillsArsonist.Get();
        public static float SheriffKillCd => Generate.SheriffKillCd.Get();
        public static float SheriffMaxUses => Generate.SheriffMaxUses.Get();
        public static bool SheriffPerRound => Generate.SheriffPerRound.Get();
        public static int MayorVoteBank => (int)Generate.MayorVoteBank.Get();
        public static bool MayorAnonymous => Generate.MayorAnonymous.Get();
        public static bool MayorButton => Generate.MayorButton.Get();
        public static bool SwapperButton => Generate.SwapperButton.Get();
        public static float ShifterCd => Generate.ShifterCd.Get();
        public static ShiftEnum WhoShifts => (ShiftEnum)Generate.WhoShifts.Get();
        public static BecomeEnum ShiftedBecomes => (BecomeEnum)Generate.ShiftedBecomes.Get();
        public static bool ShifterCrewmate => Generate.ShifterCrewmate.Get();
        public static float FootprintSize => Generate.FootprintSize.Get();
        public static float FootprintInterval => Generate.FootprintInterval.Get();
        public static float FootprintDuration => Generate.FootprintDuration.Get();
        public static bool AnonymousFootPrint => Generate.AnonymousFootPrint.Get();
        public static bool VentFootprintVisible => Generate.VentFootprintVisible.Get();
        public static bool JesterButton => Generate.JesterButton.Get();
        public static bool JesterVent => Generate.JesterVent.Get();
        public static bool RewindRevive => Generate.RewindRevive.Get();
        public static float RewindDuration => Generate.RewindDuration.Get();
        public static float RewindCooldown => Generate.RewindCooldown.Get();
        public static float RewindMaxUses => Generate.RewindMaxUses.Get();
        public static bool RewindPerRound => Generate.RewindPerRound.Get();
        public static bool TimeLordVitals => Generate.TimeLordVitals.Get();
        public static ShieldOptions ShowShielded => (ShieldOptions)Generate.ShowShielded.Get();

        public static NotificationOptions NotificationShield =>
            (NotificationOptions)Generate.WhoGetsNotification.Get();

        public static bool ShieldBreaks => Generate.ShieldBreaks.Get();
        public static float MedicReportNameDuration => Generate.MedicReportNameDuration.Get();
        public static float MedicReportColorDuration => Generate.MedicReportColorDuration.Get();
        public static bool ShowReports => Generate.MedicReportSwitch.Get();
        public static float SeerCd => Generate.SeerCooldown.Get();
        public static float SeeMaxUses => Generate.SeeMaxUses.Get();
        public static bool SeePerRound => Generate.SeePerRound.Get();
        public static SeerInfo SeerInfo => (SeerInfo)Generate.SeerInfo.Get();
        public static SeeReveal SeeReveal => (SeeReveal)Generate.SeeReveal.Get();
        public static bool NeutralRed => Generate.NeutralRed.Get();
        public static float MimicCooldown => Generate.MimicCooldownOption.Get();
        public static float MimicDuration => Generate.MimicDurationOption.Get();
        public static float HackCooldown => Generate.HackCooldownOption.Get();
        public static float HackDuration => Generate.HackDurationOption.Get();
        public static float GlitchKillCooldown => Generate.GlitchKillCooldownOption.Get();
        public static int GlitchHackDistance => Generate.GlitchHackDistanceOption.Get();
        public static bool GlitchHack => Generate.GlitchHack.Get();
        public static bool GlitchMimic => Generate.GlitchMimic.Get();
        public static bool GlitchVent => Generate.GlitchVent.Get();
        public static bool GlitchWinsTwoAlive => Generate.GlitchWinsTwoAlive.Get();
        public static float MorphlingCd => Generate.MorphlingCooldown.Get();
        public static float MorphlingDuration => Generate.MorphlingDuration.Get();
        public static bool MorphlingVent => Generate.MorphlingVent.Get();
        public static float CamouflagerCd => Generate.CamouflagerCooldown.Get();
        public static float CamouflagerDuration => Generate.CamouflagerDuration.Get();
        public static bool ColourblindComms => Generate.ColourblindComms.Get();
        public static bool MeetingColourblind => Generate.MeetingColourblind.Get();
        public static OnTargetDead OnTargetDead => (OnTargetDead)Generate.OnTargetDead.Get();
        public static bool ExecutionerButton => Generate.ExecutionerButton.Get();
        public static bool SnitchOnLaunch => Generate.SnitchOnLaunch.Get();
        public static bool SnitchSeesNeutrals => Generate.SnitchSeesNeutrals.Get();
        public static int SnitchTasksRemaining => (int)Generate.SnitchTasksRemaining.Get();
        public static bool SnitchSeesImpInMeeting => Generate.SnitchSeesImpInMeeting.Get();
        public static float MineCd => Generate.MineCooldown.Get();
        public static float SwoopCd => Generate.SwoopCooldown.Get();
        public static float SwoopDuration => Generate.SwoopDuration.Get();
        public static bool SwooperVent => Generate.SwooperVent.Get();
        public static bool ImpostorSeeRoles => Generate.ImpostorSeeRoles.Get();
        public static bool DeadSeeRoles => Generate.DeadSeeRoles.Get();
        public static bool DeadSeeVoteColors => Generate.DeadSeeVoteColors.Get();
        public static float DouseCd => Generate.DouseCooldown.Get();
        public static bool ArsonistGameEnd => Generate.ArsonistGameEnd.Get();
        public static bool ArsonistButton => Generate.ArsonistButton.Get();
        public static int MaxImpostorRoles => (int)Generate.MaxImpostorRoles.Get();
        public static int MaxNeutralRoles => (int)Generate.MaxNeutralRoles.Get();
        public static bool RoleUnderName => Generate.RoleUnderName.Get();
        public static float FixMaxUses => Generate.FixMaxUses.Get();
        public static bool FixPerRound => Generate.FixPerRound.Get();
        public static float ReviveDuration => Generate.ReviveDuration.Get();
        public static bool AltruistTargetBody => Generate.AltruistTargetBody.Get();
        public static bool SheriffBodyReport => Generate.SheriffBodyReport.Get();
        public static float DragCd => Generate.DragCooldown.Get();
        public static bool UndertakerVent => Generate.UndertakerVent.Get();
        public static bool UndertakerVentWithBody => Generate.UndertakerVentWithBody.Get();
        public static bool AssassinGuessNeutrals => Generate.AssassinGuessNeutrals.Get();
        public static bool AssassinCrewmateGuess => Generate.AssassinCrewmateGuess.Get();
        public static int AssassinKills => (int)Generate.AssassinKills.Get();
        public static bool AssassinMultiKill => Generate.AssassinMultiKill.Get();
        public static bool AssassinSnitchViaCrewmate => Generate.AssassinSnitchViaCrewmate.Get();
        public static float UnderdogKillBonus => Generate.UnderdogKillBonus.Get();
        public static bool UnderdogIncreasedKC => Generate.UnderdogIncreasedKC.Get();
        public static int PhantomTasksRemaining => (int)Generate.PhantomTasksRemaining.Get();
        public static bool RetributionistGuessNeutrals => Generate.RetributionistGuessNeutrals.Get();
        public static int RetributionistKills => (int)Generate.RetributionistKills.Get();
        public static bool RetributionistMultiKill => Generate.RetributionistMultiKill.Get();
        public static int HaunterTasksRemainingClicked => (int)Generate.HaunterTasksRemainingClicked.Get();
        public static int HaunterTasksRemainingAlert => (int)Generate.HaunterTasksRemainingAlert.Get();
        public static bool HaunterRevealsNeutrals => Generate.HaunterRevealsNeutrals.Get();
        public static HaunterCanBeClickedBy HaunterCanBeClickedBy => (HaunterCanBeClickedBy)Generate.HaunterCanBeClickedBy.Get();
        public static float GrenadeCd => Generate.GrenadeCooldown.Get();
        public static float GrenadeDuration => Generate.GrenadeDuration.Get();
        public static bool GrenadierVent => Generate.GrenadierVent.Get();
        public static float MediateCooldown => Generate.MediateCooldown.Get();
        public static float MediateMaxUses => Generate.MediateMaxUses.Get();
        public static bool MediatePerRound => Generate.MediatePerRound.Get();
        public static bool ShowMediatePlayer => Generate.ShowMediatePlayer.Get();
        public static bool MediumVitals => Generate.MediumVitals.Get();
        public static float TransportCooldown => Generate.TransportCooldown.Get();
        public static float TransportMaxUses => Generate.TransportMaxUses.Get();
        public static bool TransportPerRound => Generate.TransportPerRound.Get();
        public static bool TransporterVitals => Generate.TransporterVitals.Get();
        public static float IntelCooldown => Generate.IntelCooldown.Get();
        public static float IntelCorrect => Generate.IntelCorrect.Get();
        public static IntelInfo IntelInfo => (IntelInfo)Generate.IntelInfo.Get();
        public static bool ImpHijackKill => Generate.ImpHijackKill.Get();
        public static bool ImpHijackVent => Generate.ImpHijackVent.Get();
        public static bool AgentGameEnd => Generate.AgentGameEnd.Get();
        public static bool MastermindVent => Generate.MastermindVent.Get();
    }
}