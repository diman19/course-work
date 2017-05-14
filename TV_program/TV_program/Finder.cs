using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TV_program
{
    public partial class Finder : Form1
    {
        public string find;
        public string[] channels;
        public void saveChannels()
        {
            channels = new string[channelsCheckedListBox.Items.Count];
            for (int i = 0; i < channelsCheckedListBox.Items.Count; i++)
            {
                channels[i] = channelsCheckedListBox.Items[i].ToString();
            }

        }
    }
}
