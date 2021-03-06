﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    public partial class Form1 : Form
    {
        static string filename = ""; //File opened
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Opens file with FileDialog
        /// </summary>
        private void Open_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = openFileDialog1.ShowDialog(); //Open file select menu
            if (dialogResult == DialogResult.OK) //If file is selected 
            {
                filename = openFileDialog1.FileName; //Save current file into string for saving
                richTextBox1.Text = System.IO.File.ReadAllText(openFileDialog1.FileName); //Fill textbox with content from file.
            }
        }
        /// <summary>
        /// Opens FileDialog and saves file
        /// </summary>
        private void SaveAs_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = saveFileDialog1.ShowDialog(); //Open file select menu
            if (dialogResult == DialogResult.OK) //If file is selected (file to save)
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text); //Write all content from richtextbox into file.
            }
        }
        /// <summary>
        /// Closes applciation
        /// </summary>
        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Saves open file 
        /// </summary>
        private void Save_Click(object sender, EventArgs e)
        {
                System.IO.File.WriteAllText(filename, richTextBox1.Text); //Save content from richtextbox to opened file
        }
        /// <summary>
        /// Searches for search query inside richtextbox
        /// </summary>
        private void Search_Click(object sender, EventArgs e)
        {
            string searchQuery = searchTextBox.Text; //Save search query to string
            int line = richTextBox1.GetLineFromCharIndex(
                richTextBox1.Find(searchQuery)
            ); //Find line that specific text locates at
            lineLabel.Text = "Line " + line.ToString();
        }
        /// <summary>
        /// Replaces searchQuery with replaceQuery inside of richTextBox
        /// </summary>
        private void Replace_Click(object sender, EventArgs e)
        {
            string searchQuery = searchTextBox.Text; //Save search query
            string replaceQuery = replaceTextBox.Text; //Save replace query
            richTextBox1.Text = richTextBox1.Text.Replace(searchQuery, replaceQuery); //Replace searchQuery content in richtextbox with replaceQuery content.
            richTextBox1.Update();
        }
        /// <summary>
        /// Undos text
        /// </summary>
        private void Undo_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo(); //Undo text,  no need to reinvent the wheel.
        }
    }
}
