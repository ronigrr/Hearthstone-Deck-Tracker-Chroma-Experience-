using System;
using System.Windows.Controls;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Plugins;

namespace Hearthstone_DeckTracker_Chroma_Experience
{
    public class Plugin : IPlugin
    {
        public void OnLoad()
        {
            ChromaController.DefaultKyeBoard();
            ChromaController.InitKyeArray();
            GameEvents.OnGameStart.Add(ChromaController.GameStart);
            GameEvents.OnGameEnd.Add(ChromaController.GameEnd);
            GameEvents.OnTurnStart.Add(ChromaController.TurnStart);
            GameEvents.OnModeChanged.Add(ChromaController.ModeChange);


            GameEvents.OnPlayerPlay.Add(ChromaController.PlayerPlay);
            GameEvents.OnPlayerDraw.Add(ChromaController.PlayerDraw);
            GameEvents.OnPlayerHandDiscard.Add(ChromaController.PlayerHandDiscard);
            GameEvents.OnPlayerPlayToDeck.Add(ChromaController.PlayerPlayToDeck);
            GameEvents.OnPlayerGet.Add(ChromaController.GetPlayer);
        }

        public void OnUnload()
        {
            // Triggered when the user unticks the plugin, however, HDT does not completely unload the plugin.
            // see https://git.io/vxEcH
        }

        public void OnButtonPress()
        {
            ChromaController.TestPlugin();
        }

        public void OnUpdate()
        {

        }

        public string Name => "Chroma Experience";

        public string Description => "This plugin connects to you chroma keyboard and controls its colors to improve in game experience";

        public string ButtonText => "Test your keyboard";

        public string Author => "Ronald Granovsky";

        public Version Version => new Version(1, 0, 0);

        public MenuItem MenuItem => null;
    }
}