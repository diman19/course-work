using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace TV_program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool isReseted = true;
        public string find = "";
        public string[] channels = { "Enter-фильм", "Киноклуб", "Eurosport", "НТВ+спорт", "М1", "OTV", "ICTV", "Интер", "Первый национальный", "СТБ" };
        public string[] channelsMovie = { "Enter-фильм" , "Киноклуб"};
        public string[] channelsSport = { "Eurosport", "НТВ+спорт" };
        public string[] channelsMusic = { "М1", "OTV" };
        public string[] channelsCommon = { "ICTV", "Интер", "Первый национальный", "СТБ"};
        public string[] categories = { "Кино", "Музыка", "Спорт", "Общеукраинские" };
        public string[] week = {"Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье"};
        public List<string> resultCategories;
        public List<string> resultChannels;
        public List<string> resultWeek;
        public DateTime time;
        public bool correctTime = false;
        public bool flag = true;
        //убрать categories заполнение до giveresult
        public void resetChannels()
        {
            for (int i = 0; i < channels.Length; i++)
            {
                channelsCheckedListBox.Items.Add(channels[i]);
            }
            isReseted = true;
        }
        private void categoryAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (categoryAllCheckBox.Checked == false)
            {
                ///////////
                categoryCommonCheckBox.Enabled = true;
                categoryMovieCheckBox.Enabled = true;
                categoryMusicCheckBox.Enabled = true;
                categorySportCheckBox.Enabled = true;
            }
            else
            {
                resetChannels();
                categoryCommonCheckBox.Enabled = false;
                categoryMovieCheckBox.Enabled = false;
                categoryMusicCheckBox.Enabled = false;
                categorySportCheckBox.Enabled = false;
            }
        }

        private void channelsAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (channelsAllCheckBox.Checked== false)
            {
                channelsCheckedListBox.Enabled = true;
            }
            else
            {
                channelsCheckedListBox.Enabled = false;
            }
        }

        private void weekAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (weekAllCheckBox.Checked == false)
            {
                weekCheckedListBox.Enabled = true;
            }
            else
            {
                weekCheckedListBox.Enabled = false;
            }
        }

        private void timeAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (timeAllCheckBox.Checked == false)
            {
                timeMaskedTextBox.Enabled = true;
            }
            else
            {
                timeMaskedTextBox.Enabled = false;
            }
        }

        private void findTextBox_TextChanged(object sender, EventArgs e)
        {
            find = findTextBox.Text;
        }

        public void giveResult(string find, List<string> resultChannels, List<string> resultWeek, DateTime time)
        {
            if (resultChannels.Count != 0)
            {
                string line;
                int counter = 0;
                TextReader reader = new StreamReader("Enter-фильм.txt");
                foreach (string str in resultChannels)
                {
                    
                    if (str == "Enter-фильм")
                    {
                       reader = new StreamReader("Enter-фильм.txt");
                    }
                    else if (str == "Киноклуб")
                    {
                        reader = new StreamReader("Киноклуб.txt");
                    }
                    else if (str == "Eurosport")
                    {
                        reader = new StreamReader("Eurosport.txt");
                    }
                    else if (str == "НТВ+спорт")
                    {
                        reader = new StreamReader("НТВ+спорт.txt");
                    }
                    else if (str == "М1")
                    {
                        reader = new StreamReader("М1.txt");
                    }
                    else if (str == "OTV")
                    {
                         reader = new StreamReader("OTV.txt");
                    }
                    else if (str == "ICTV")
                    {
                        reader = new StreamReader("ICTV.txt");
                    }
                    else if (str == "Интер")
                    {
                        reader = new StreamReader("Интер.txt");
                    }
                    else if (str == "Первый национальный")
                    {
                        reader = new StreamReader("Первый национальный.txt");
                    }
                    else
                    {
                        reader = new StreamReader("СТБ.txt");
                    }
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (reader.ReadLine() != resultWeek[counter])
                            continue;
                        string[] temp = line.Split(':');

                    }
                    counter++;
                    reader.Close();
                }
            }
            else
            {
                MessageBox.Show("Choose channels correctly, please!");
            }

        }


        private void searchButton_Click(object sender, EventArgs e)
        {
            if (find.Length != 0)
            {
                //time
                /////////////////////
                //////////
                ////////
                if (correctTime)
                {
                    MessageBox.Show("Enter correct time, please!");
                    flag = false;
                }
                //categories List
                resultCategories = new List<string> { };
                if (categoryAllCheckBox.Checked == true)
                {
                    for (int i = 0; i < categories.Length; i++)
                        resultCategories.Add(categories[i]);
                }
                else if (categoryCommonCheckBox.Checked == true)
                {
                    resultCategories.Add(categoryCommonCheckBox.Text);
                }
                else if (categoryMovieCheckBox.Checked == true)
                {
                    resultCategories.Add(categoryMovieCheckBox.Text);
                }
                else if (categoryMusicCheckBox.Checked == true)
                {
                    resultCategories.Add(categoryMusicCheckBox.Text);
                }
                else
                {
                    resultCategories.Add(categorySportCheckBox.Text);
                }

                //
                //channelsList
                resultChannels = new List<string> { };
                if (channelsAllCheckBox.Checked == true)
                {
                    for (int i = 0; i < channels.Length; i++)
                        resultChannels.Add(channels[i]);
                }
                else
                {
                    for (int i = 0; i < channelsCheckedListBox.Items.Count; i++)
                    {
                        if (channelsCheckedListBox.GetItemChecked(i))
                        {
                            resultChannels.Add(channelsCheckedListBox.Items[i].ToString());
                        }
                    }
                }

                //days of week
                resultWeek = new List<string> { };
                if (weekAllCheckBox.Checked == true)
                {
                    for (int i = 0; i < channels.Length; i++)
                        resultWeek.Add(channels[i]);
                }
                else
                {
                    for (int i = 0; i < weekCheckedListBox.Items.Count; i++)
                    {
                        if (weekCheckedListBox.GetItemChecked(i))
                        {
                            resultWeek.Add(channelsCheckedListBox.Items[i].ToString());
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Enter the keyword, please!");
                flag = false;
            }
            if (flag)
                giveResult(find, resultChannels, resultWeek, time);
            flag = true;
        }

        private void categoryMovieCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //if every checkbox becomes empty - reset 
            if (categoryAllCheckBox.Checked == false &&
                categoryCommonCheckBox.Checked == false && categoryMusicCheckBox.Checked == false &&
                categorySportCheckBox.Checked == false && categoryMusicCheckBox.Checked == false)
            {
                resetChannels();
                categoryAllCheckBox.Checked = true;
            }
            //if this checkbox is the first after "All" one
            else if (categoryAllCheckBox.Checked == false &&
               categoryCommonCheckBox.Checked == false && categoryMusicCheckBox.Checked == false &&
               categorySportCheckBox.Checked == false && categoryMusicCheckBox.Checked == true)
            {
                channelsCheckedListBox.Items.Clear();
                channelsCheckedListBox.Enabled = true;
                for (int i = 0; i < channelsMovie.Length; i++)
                {
                    channelsCheckedListBox.Items.Add(channelsMovie[i]);
                }
            
                if (channelsAllCheckBox.Checked == false)
                {
                    channelsCheckedListBox.Enabled = true;
                }
                else
                {
                    channelsCheckedListBox.Enabled = false;
                }
            }
            else
            {
                for (int i = 0; i < channelsMovie.Length; i++)
                {
                    channelsCheckedListBox.Items.Add(channelsMovie[i]);
                }
            }
            //if (categoryMovieCheckBox.Checked == false)
            //{
            //    resetChannels();
            //}
            //else
            //{
            //    channelsCheckedListBox.Items.Clear();
            //    channelsCheckedListBox.Enabled = true;
            //    for (int i = 0; i < channelsMovie.Length; i++)
            //    {
            //        channelsCheckedListBox.Items.Add(channelsMovie[i]);
            //    }
            //}
            //if (channelsAllCheckBox.Checked == false)
            //{
            //    channelsCheckedListBox.Enabled = true;
            //}
            //else
            //{
            //    channelsCheckedListBox.Enabled = false;
            //}
        }

        private void categorySportCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (categorySportCheckBox.Checked == false)
            {
                resetChannels();
               
            }
            else
            {
                
                channelsCheckedListBox.Items.Clear();
                channelsCheckedListBox.Enabled = true;
                for (int i = 0; i < channelsSport.Length; i++)
                {
                    channelsCheckedListBox.Items.Add(channelsSport[i]);
                }
            }
            if (channelsAllCheckBox.Checked == false)
            {
                channelsCheckedListBox.Enabled = true;
            }
            else
            {
                channelsCheckedListBox.Enabled = false;
            }
        }
        private void categoryMusicCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (categoryMusicCheckBox.Checked == false)
            {
                resetChannels();
            }
            else
            {
                channelsCheckedListBox.Items.Clear();
                channelsCheckedListBox.Enabled = true;
                for (int i = 0; i < channelsMusic.Length; i++)
                {
                    channelsCheckedListBox.Items.Add(channelsMusic[i]);
                }
            }
            if (channelsAllCheckBox.Checked == false)
            {
                channelsCheckedListBox.Enabled = true;
            }
            else
            {
                channelsCheckedListBox.Enabled = false;
            }
        }
        private void categoryCommonCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (categoryCommonCheckBox.Checked == false)
            {
                resetChannels();
            }
            else
            {
                channelsCheckedListBox.Items.Clear();
                channelsCheckedListBox.Enabled = true;
                for (int i = 0; i < channelsCommon.Length; i++)
                {
                    channelsCheckedListBox.Items.Add(channelsCommon[i]);
                }
            }
            if (channelsAllCheckBox.Checked == false)
            {
                channelsCheckedListBox.Enabled = true;
            }
            else
            {
                channelsCheckedListBox.Enabled = false;
            }
        }

        private void timeMaskedTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            ///correct time!!!
            if (timeMaskedTextBox.MaskFull)
                MessageBox.Show("Yes");
            else
                MessageBox.Show("No");
        }
    }
}
