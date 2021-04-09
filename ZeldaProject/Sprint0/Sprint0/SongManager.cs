using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class SongManager
    {
        private Song Title_music;
        private Song Overworld_music;
        private Song Dungeon_music;
        private Song Ending_music;

        public SongManager(Song Title, Song Overworld, Song Dungeon, Song Ending)
        {
            Title_music = Title;
            Overworld_music = Overworld;
            Dungeon_music = Dungeon;
            Ending_music = Ending;

            MediaPlayer.Play(Title_music);
            MediaPlayer.Volume = 0.25f;
            MediaPlayer.IsRepeating = true;
        }

        public void Overworld()
        {
            MediaPlayer.Stop();
            MediaPlayer.Play(Overworld_music);
        }
        public void Dungeon()
        {
            MediaPlayer.Stop();
            MediaPlayer.Play(Dungeon_music);
        }
        public void Ending()
        {
            MediaPlayer.Stop();
            MediaPlayer.Play(Ending_music);
        }


    }
}
