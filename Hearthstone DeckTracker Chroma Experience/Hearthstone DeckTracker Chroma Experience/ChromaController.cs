using System;
using System.Collections;
using System.Threading.Tasks;
using Colore;
using Colore.Effects.Keyboard;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Enums;
using Hearthstone_Deck_Tracker.Enums.Hearthstone;
using Color = Colore.Data.Color;


namespace Hearthstone_DeckTracker_Chroma_Experience

{
    public class ChromaController  
    {

        internal static Task<IChroma> m_Chroma = ColoreProvider.CreateNativeAsync();
        internal static ActivePlayer m_CurrentActivePlayer = ActivePlayer.None;
        internal static ArrayList m_ButtonsForCardsInHand = new ArrayList();
        private static  int s_CardsInHand;
        public static int CardsInHand
        {
            get
            {
                return s_CardsInHand;
            }
            set
            {
                if (value == s_CardsInHand)
                {
                    return;
                }
                s_CardsInHand = value;
                UpdateCardInHand(s_CardsInHand);
            }
        }

        public ChromaController()
        {
            DefaultKyeBoard();
            InitKyeArray();
        }

        public static void DefaultKyeBoard()
        {
            ChangeColor(Color.Yellow);
        }
        internal static async void ChangeColor(Color i_Color)
        {
            await m_Chroma.Result.SetAllAsync(i_Color).ConfigureAwait(false);
        }
        internal static async void ChangeColorForKey(Color i_Color,Key i_Key)
        {
            await m_Chroma.Result.Keyboard.SetKeyAsync(i_Key, i_Color).ConfigureAwait(false);
        }
        internal static void TurnStart(ActivePlayer i_Player)
        {
            m_CurrentActivePlayer = i_Player;
        }
        internal static void GameStart()
        {
            UpdateCardInHand(0);
        }
        public static void ModeChange(Mode i_GameMode)
        {
            switch(i_GameMode)
            {
                case Mode.STARTUP:
                    break;
                case Mode.LOGIN:
                    DefaultKyeBoard();
                    break;
                case Mode.INVALID:
                    break;
                case Mode.HUB:
                    break;
                case Mode.GAMEPLAY:
                    break;
                case Mode.COLLECTIONMANAGER:
                    break;
                case Mode.PACKOPENING:
                    break;
                case Mode.TOURNAMENT:
                    break;
                case Mode.FRIENDLY:
                    break;
                case Mode.FATAL_ERROR:
                    break;
                case Mode.DRAFT:
                    break;
                case Mode.CREDITS:
                    break;
                case Mode.RESET:
                    break;
                case Mode.ADVENTURE:
                    break;
                case Mode.TAVERN_BRAWL:
                    break;
                case Mode.FIRESIDE_GATHERING:
                    break;
                case Mode.BACON:
                    DefaultKyeBoard();
                    break;
                default:
                    DefaultKyeBoard();
                    break;
            }
        }
        public static void GetPlayer(Hearthstone_Deck_Tracker.Hearthstone.Card i_Card)
        {
            CardsInHand = Core.Game.Player.HandCount;
        }

        public static void PlayerPlay(Hearthstone_Deck_Tracker.Hearthstone.Card i_Card)
        {
            CardsInHand = Core.Game.Player.HandCount;
        }

        internal static void InitKyeArray()
        {
            m_ButtonsForCardsInHand.Add(Key.F1);
            m_ButtonsForCardsInHand.Add(Key.F2);
            m_ButtonsForCardsInHand.Add(Key.F3);
            m_ButtonsForCardsInHand.Add(Key.F4);
            m_ButtonsForCardsInHand.Add(Key.F5);
            m_ButtonsForCardsInHand.Add(Key.F6);
            m_ButtonsForCardsInHand.Add(Key.F7);
            m_ButtonsForCardsInHand.Add(Key.F8);
            m_ButtonsForCardsInHand.Add(Key.F9);
            m_ButtonsForCardsInHand.Add(Key.F10);
        }

        public static void PlayerDraw(Hearthstone_Deck_Tracker.Hearthstone.Card i_DrawnCard)
        {
            CardsInHand = Core.Game.Player.HandCount+1;
        }

        internal static void UpdateCardInHand(int i_CardsInHand)
        {
            for (int index = 0; index < m_ButtonsForCardsInHand.Count; index++)
            {
                if (index < i_CardsInHand)
                {
                    ChangeColorForKey(Color.Red,(Key)m_ButtonsForCardsInHand[index]);
                }
                else
                {
                    ChangeColorForKey(Color.Green,(Key)m_ButtonsForCardsInHand[index]);
                }
            }
        }

        public static void PlayerHandDiscard(Hearthstone_Deck_Tracker.Hearthstone.Card i_DiscardedCard)
        {
            CardsInHand = Core.Game.Player.HandCount;
        }

        public static void PlayerPlayToDeck(Hearthstone_Deck_Tracker.Hearthstone.Card i_PlayedCard)
        {
            CardsInHand = Core.Game.Player.HandCount;
        }

        

        public static void TestPlugin()
        {
            Random random = new Random();
                // Loop through all Rows
                for(int i = 0; i < 120; i++)
                {
                    for(int r = 0; r < KeyboardConstants.MaxRows; r++)
                    {
                        //Loop through all Columns
                        for(int c = 0; c < KeyboardConstants.MaxColumns; c++)
                        {
                            // Set the current row and column to the random color
                            m_Chroma.Result.Keyboard[r, c] = new Color(
                                random.Next(256),
                                random.Next(256),
                                random.Next(256));
                        }
                    }
                }
        }

        public static void GameEnd()
        {
            DefaultKyeBoard();
        }
    }
}
