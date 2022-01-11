using System;
using UnityEngine;
using Object = UnityEngine.Object;
using Hazel;
using Reactor;
using System.Linq;

namespace TownOfUs.Roles
{
    public class Transporter : Role
    {

        public DateTime LastTransported { get; set; }

        public bool PressedButton;
        public bool MenuClick;
        public bool LastMouse;
        public ChatController TransportList1 { get; set; }
        public ChatController TransportList2 { get; set; }
        public PlayerControl TransportPlayer1 { get; set; }
        public PlayerControl TransportPlayer2 { get; set; }
        
        public Transporter(PlayerControl player) : base(player)
        {
            Name = "Transporter";
            ImpostorText = () => "Choose two players to swap locations";
            TaskText = () => "Choose two players to swap their locations";
            Color = new Color(0f, 0.93f, 1f, 1f);
            RoleType = RoleEnum.Transporter;
            Scale = 1.4f;
            PressedButton = false;
            MenuClick = false;
            LastMouse = false;
            TransportList1 = null;
            TransportList2 = null;
            TransportPlayer1 = null;
            TransportPlayer2 = null;
        }

        public float TransportTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastTransported;
            var num = CustomGameOptions.TransportCooldown * 1000f;
            var flag2 = num - (float) timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }

        public void Update(HudManager __instance)
        {
            // if (HudManager.Instance != null && HudManager.Instance.Chat != null)
            //     foreach (var bubble in HudManager.Instance.Chat.chatBubPool.activeChildren)
            //         if (bubble.Cast<ChatBubble>().NameText != null &&
            //             Player.Data.PlayerName == bubble.Cast<ChatBubble>().NameText.text)
            //             bubble.Cast<ChatBubble>().NameText.color = Color;

            FixedUpdate(__instance);
        }

        public void FixedUpdate(HudManager __instance)
        {
            if (PressedButton && TransportPlayer1 == null && TransportPlayer2 == null && TransportList1 == null)
            {
                TransportList1 = Object.Instantiate(__instance.Chat);

                TransportList1.transform.SetParent(Camera.main.transform);
                TransportList1.SetVisible(true);
                TransportList1.Toggle();

                TransportList1.TextBubble.enabled = false;
                TransportList1.TextBubble.gameObject.SetActive(false);

                TransportList1.TextArea.enabled = false;
                TransportList1.TextArea.gameObject.SetActive(false);

                TransportList1.BanButton.enabled = false;
                TransportList1.BanButton.gameObject.SetActive(false);

                TransportList1.CharCount.enabled = false;
                TransportList1.CharCount.gameObject.SetActive(false);

                TransportList1.OpenKeyboardButton.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
                TransportList1.OpenKeyboardButton.SetActive(false);

                TransportList1.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>()
                    .enabled = false;
                TransportList1.gameObject.transform.GetChild(0).gameObject.SetActive(false);

                TransportList1.BackgroundImage.enabled = false;

                foreach (var rend in TransportList1.Content
                    .GetComponentsInChildren<SpriteRenderer>())
                    if (rend.name == "SendButton" || rend.name == "QuickChatButton")
                    {
                        rend.enabled = false;
                        rend.gameObject.SetActive(false);
                    }

                foreach (var bubble in TransportList1.chatBubPool.activeChildren)
                {
                    bubble.enabled = false;
                    bubble.gameObject.SetActive(false);
                }

                TransportList1.chatBubPool.activeChildren.Clear();

                foreach (var TempPlayer in PlayerControl.AllPlayerControls)
                    if (TempPlayer != null &&
                        TempPlayer.Data != null &&
                        !TempPlayer.Data.IsDead &&
                        !TempPlayer.Data.Disconnected &&
                        TempPlayer.PlayerId != PlayerControl.LocalPlayer.PlayerId)
                    {
                        foreach (var player in PlayerControl.AllPlayerControls)
                            if (player != null &&
                                player.Data != null &&
                                (!player.Data.Disconnected && !player.Data.IsDead) ||
                                Object.FindObjectsOfType<DeadBody>().FirstOrDefault(x => x.ParentId == player.PlayerId).ParentId == player.PlayerId)
                            {
                                TransportList1.AddChat(TempPlayer, "Click here");
                                TransportList1.chatBubPool.activeChildren[TransportList1.chatBubPool.activeChildren._size - 1].Cast<ChatBubble>().SetName(player.Data.PlayerName, false, false,
                                    PlayerControl.LocalPlayer.PlayerId == player.PlayerId ? Color : Color.white);
                                var IsDeadTemp = player.Data.IsDead;
                                player.Data.IsDead = false;
                                TransportList1.chatBubPool.activeChildren[TransportList1.chatBubPool.activeChildren._size - 1].Cast<ChatBubble>().SetCosmetics(player.Data);
                                player.Data.IsDead = IsDeadTemp;
                            }
                        break;
                    }
            }
            if (TransportList1 != null)
            {
                if (Minigame.Instance)
                    Minigame.Instance.Close();

                if (!TransportList1.IsOpen || MeetingHud.Instance || Input.GetKeyInt(KeyCode.Escape))
                {
                    TransportList1.Toggle();
                    TransportList1.SetVisible(false);
                    TransportList1 = null;
                    PressedButton = false;
                }
                else
                {
                    foreach (var bubble in TransportList1.chatBubPool.activeChildren)
                        if (TransportTimer() == 0f && TransportList1 != null)
                        {
                            // System.Console.WriteLine("Reached Here - 1");
                            Vector2 ScreenMin =
                                Camera.main.WorldToScreenPoint(bubble.Cast<ChatBubble>().Background.bounds.min);
                            Vector2 ScreenMax =
                                Camera.main.WorldToScreenPoint(bubble.Cast<ChatBubble>().Background.bounds.max);
                            if (Input.mousePosition.x > ScreenMin.x && Input.mousePosition.x < ScreenMax.x)
                                if (Input.mousePosition.y > ScreenMin.y && Input.mousePosition.y < ScreenMax.y)
                                {
                                    // System.Console.WriteLine("Reached Here - 2");
                                    // System.Console.WriteLine(Input.GetMouseButtonDown(0)+"");
                                    // System.Console.WriteLine(LastMouse+"");
                                    if (!Input.GetMouseButtonDown(0) && LastMouse)
                                    {
                                        // System.Console.WriteLine("Reached Here - 3");
                                        LastMouse = false;
                                        TransportList1.Toggle();
                                        TransportList1.SetVisible(false);
                                        TransportList1 = null;
                                        PressedButton = false;

                                        // System.Console.WriteLine(bubble.Cast<ChatBubble>().NameText.text);
                                        foreach (var player in PlayerControl.AllPlayerControls)
                                            if (player.Data.PlayerName == bubble.Cast<ChatBubble>().NameText.text)
                                            {
                                                TransportPlayer1 = player;
                                                // System.Console.WriteLine(player.Data.PlayerName+"");
                                            }
                                    }
                                }
                        }
                    if (!Input.GetMouseButtonDown(0) && LastMouse)
                    {
                        if (MenuClick)
                            MenuClick = false;
                        else {
                            TransportList1.Toggle();
                            TransportList1.SetVisible(false);
                            TransportList1 = null;
                            PressedButton = false;
                        }
                    }
                    LastMouse = Input.GetMouseButtonDown(0);
                }
            }
            if (TransportPlayer1 != null && TransportPlayer2 == null && TransportList2 == null)
            {
                TransportList2 = Object.Instantiate(__instance.Chat);

                TransportList2.transform.SetParent(Camera.main.transform);
                TransportList2.SetVisible(true);
                TransportList2.Toggle();

                TransportList2.TextBubble.enabled = false;
                TransportList2.TextBubble.gameObject.SetActive(false);

                TransportList2.TextArea.enabled = false;
                TransportList2.TextArea.gameObject.SetActive(false);

                TransportList2.BanButton.enabled = false;
                TransportList2.BanButton.gameObject.SetActive(false);

                TransportList2.CharCount.enabled = false;
                TransportList2.CharCount.gameObject.SetActive(false);

                TransportList2.OpenKeyboardButton.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
                TransportList2.OpenKeyboardButton.SetActive(false);

                TransportList2.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>()
                    .enabled = false;
                TransportList2.gameObject.transform.GetChild(0).gameObject.SetActive(false);

                TransportList2.BackgroundImage.enabled = false;

                foreach (var rend in TransportList2.Content
                    .GetComponentsInChildren<SpriteRenderer>())
                    if (rend.name == "SendButton" || rend.name == "QuickChatButton")
                    {
                        rend.enabled = false;
                        rend.gameObject.SetActive(false);
                    }

                foreach (var bubble in TransportList2.chatBubPool.activeChildren)
                {
                    bubble.enabled = false;
                    bubble.gameObject.SetActive(false);
                }

                TransportList2.chatBubPool.activeChildren.Clear();

                foreach (var TempPlayer in PlayerControl.AllPlayerControls)
                    if (TempPlayer != null &&
                        TempPlayer.Data != null &&
                        !TempPlayer.Data.IsDead &&
                        !TempPlayer.Data.Disconnected &&
                        TempPlayer.PlayerId != PlayerControl.LocalPlayer.PlayerId)
                    {
                        foreach (var player in PlayerControl.AllPlayerControls)
                        {
                            if (player.PlayerId != TransportPlayer1.PlayerId &&
                                player != null &&
                                player.Data != null &&
                                ((!player.Data.Disconnected && !player.Data.IsDead) ||
                                Object.FindObjectsOfType<DeadBody>().FirstOrDefault(x => x.ParentId == player.PlayerId).ParentId == player.PlayerId))
                            {
                                TransportList2.AddChat(TempPlayer, "Click here");
                                TransportList2.chatBubPool.activeChildren[TransportList2.chatBubPool.activeChildren._size - 1].Cast<ChatBubble>().SetName(player.Data.PlayerName, false, false,
                                    PlayerControl.LocalPlayer.PlayerId == player.PlayerId ? Color : Color.white);
                                var IsDeadTemp = player.Data.IsDead;
                                player.Data.IsDead = false;
                                TransportList2.chatBubPool.activeChildren[TransportList2.chatBubPool.activeChildren._size - 1].Cast<ChatBubble>().SetCosmetics(player.Data);
                                player.Data.IsDead = IsDeadTemp;
                            }
                        }
                        break;
                    }
            }
            if (TransportList2 != null)
            {
                if (Minigame.Instance)
                    Minigame.Instance.Close();

                if (!TransportList2.IsOpen || MeetingHud.Instance || Input.GetKeyInt(KeyCode.Escape))
                {
                    TransportList2.Toggle();
                    TransportList2.SetVisible(false);
                    TransportList2 = null;
                    TransportPlayer1 = null;
                }
                else
                {
                    foreach (var bubble in TransportList2.chatBubPool.activeChildren)
                        if (TransportTimer() == 0f && TransportList2 != null)
                        {
                            Vector2 ScreenMin =
                                Camera.main.WorldToScreenPoint(bubble.Cast<ChatBubble>().Background.bounds.min);
                            Vector2 ScreenMax =
                                Camera.main.WorldToScreenPoint(bubble.Cast<ChatBubble>().Background.bounds.max);
                            if (Input.mousePosition.x > ScreenMin.x && Input.mousePosition.x < ScreenMax.x)
                                if (Input.mousePosition.y > ScreenMin.y && Input.mousePosition.y < ScreenMax.y)
                                {
                                    if (!Input.GetMouseButtonDown(0) && LastMouse)
                                    {
                                        LastMouse = false;
                                        TransportList2.Toggle();
                                        TransportList2.SetVisible(false);
                                        TransportList2 = null;
                                        // Coroutines.Start(AbilityCoroutine.Illusion(this, PlayerControl.AllPlayerControls.ToArray().Where(x =>
                                        //         x.Data.PlayerName == bubble.Cast<ChatBubble>().NameText.text)
                                        //     .FirstOrDefault()));
                                        foreach (var player in PlayerControl.AllPlayerControls)
                                            if (player.Data.PlayerName == bubble.Cast<ChatBubble>().NameText.text)
                                            {
                                                LastTransported = DateTime.UtcNow;

                                                TransportPlayer2 = player;

                                                var deadBodies = UnityEngine.Object.FindObjectsOfType<DeadBody>();
                                                DeadBody Player1Body = null;
                                                DeadBody Player2Body = null;
                                                if (TransportPlayer1.Data.IsDead)
                                                    foreach (var body in deadBodies)
                                                        if (body.ParentId == TransportPlayer1.PlayerId)
                                                            Player1Body = body;
                                                if (TransportPlayer2.Data.IsDead)
                                                    foreach (var body in deadBodies)
                                                        if (body.ParentId == TransportPlayer2.PlayerId)
                                                            Player2Body = body;
                                                
                                                if (TransportPlayer1.inVent)
                                                {
                                                    TransportPlayer1.MyPhysics.RpcExitVent(Vent.currentVent.Id);
                                                    TransportPlayer1.MyPhysics.ExitAllVents();
                                                }
                                                if (TransportPlayer2.inVent)
                                                {
                                                    TransportPlayer2.MyPhysics.RpcExitVent(Vent.currentVent.Id);
                                                    TransportPlayer2.MyPhysics.ExitAllVents();
                                                }

                                                if (Player1Body == null && Player2Body == null)
                                                {
                                                    TransportPlayer1.MyPhysics.ResetMoveState();
                                                    TransportPlayer2.MyPhysics.ResetMoveState();
                                                    var TempPosition = TransportPlayer1.GetTruePosition();
                                                    var TempFacing = TransportPlayer1.myRend.flipX;
                                                    TransportPlayer1.NetTransform.SnapTo(new Vector2(TransportPlayer2.GetTruePosition().x, TransportPlayer2.GetTruePosition().y + 0.3636f));
                                                    TransportPlayer1.myRend.flipX = TransportPlayer2.myRend.flipX;
                                                    TransportPlayer2.NetTransform.SnapTo(new Vector2(TempPosition.x, TempPosition.y + 0.3636f));
                                                    TransportPlayer2.myRend.flipX = TempFacing;
                                                }
                                                if (Player1Body != null && Player2Body == null)
                                                {
                                                    TransportPlayer2.MyPhysics.ResetMoveState();
                                                    var TempPosition = Player1Body.TruePosition;
                                                    Player1Body.transform.position = TransportPlayer2.GetTruePosition();
                                                    TransportPlayer2.NetTransform.SnapTo(new Vector2(TempPosition.x, TempPosition.y + 0.3636f));
                                                }
                                                if (Player1Body == null && Player2Body != null)
                                                {
                                                    TransportPlayer1.MyPhysics.ResetMoveState();
                                                    var TempPosition = TransportPlayer1.GetTruePosition();
                                                    TransportPlayer1.NetTransform.SnapTo(new Vector2(Player2Body.TruePosition.x, Player2Body.TruePosition.y + 0.3636f));
                                                    Player2Body.transform.position = TempPosition;
                                                }
                                                if (Player1Body != null && Player2Body != null)
                                                {
                                                    var TempPosition =  Player1Body.TruePosition;
                                                    Player1Body.transform.position = Player2Body.TruePosition;
                                                    Player2Body.transform.position = TempPosition;
                                                }
                                                
                                                // if (Player1Body == null && Player2Body == null)
                                                // {
                                                //     Coroutines.Start(Transport());
                                                // }
                                                // else
                                                // {
                                                    var write = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                                                        (byte) CustomRPC.TransportPlayers, SendOption.Reliable, -1);
                                                    write.Write(TransportPlayer1.PlayerId);
                                                    write.Write(TransportPlayer2.PlayerId);
                                                    AmongUsClient.Instance.FinishRpcImmediately(write);

                                                    if (PlayerControl.LocalPlayer.PlayerId == TransportPlayer1.PlayerId ||
                                                    PlayerControl.LocalPlayer.PlayerId == TransportPlayer2.PlayerId)
                                                    Coroutines.Start(Utils.FlashCoroutine(Color));

                                                    TransportPlayer1 = null;
                                                    TransportPlayer2 = null;
                                                // }
                                            }
                                    }
                                }
                        }
                    if (!Input.GetMouseButtonDown(0) && LastMouse)
                    {
                        if (MenuClick)
                            MenuClick = false;
                        else {
                            TransportList2.Toggle();
                            TransportList2.SetVisible(false);
                            TransportList2 = null;
                            TransportPlayer1 = null;
                        }
                    }
                    LastMouse = Input.GetMouseButtonDown(0);
                }
            }
        }
    }
}