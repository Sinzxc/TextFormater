using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TextFormater
{
    public partial class Form1 : Form
    {
        string FileName= "Новый.rtf";
        string ImageName = "";
        public Form1()
        {
            InitializeComponent();
            this.Text = FileName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            newFileButton.BackgroundImage = Image.FromFile("images/icons/files.png");
            openFileButton.BackgroundImage = Image.FromFile("images/icons/folder.png");
            saveFileButton.BackgroundImage = Image.FromFile("images/icons/diskette.png");
            saveAsFileButton.BackgroundImage = Image.FromFile("images/icons/saveas.png");
            cutButton.BackgroundImage = Image.FromFile("images/icons/scissors.png");
            copyButton.BackgroundImage = Image.FromFile("images/icons/copy.png");
            pasteButton.BackgroundImage = Image.FromFile("images/icons/add.png");
            textToLeft.BackgroundImage = Image.FromFile("images/icons/align-left.png");
            textToCenter.BackgroundImage = Image.FromFile("images/icons/format.png");
            textToRight.BackgroundImage = Image.FromFile("images/icons/align-right.png");
            undoButton.BackgroundImage = Image.FromFile("images/icons/back.png");
            selectAllButton.BackgroundImage = Image.FromFile("images/icons/selectall.png");
            selectColorButton.BackgroundImage = Image.FromFile("images/icons/textcolor.png");
            selectFontButton.BackgroundImage = Image.FromFile("images/icons/font.png");
            addImageButton.BackgroundImage = Image.FromFile("images/icons/image.png");
            findButton.BackgroundImage = Image.FromFile("images/icons/find.png");
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void новыйToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            newFileButton.PerformClick();
        }

        private void Save()
        {
            if (textArea.Text != "")
            {
                if (FileName == "Новый.rtf") saveAsFileButton.PerformClick();
                else
                    textArea.SaveFile(FileName);
            }
        }   



        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exitButton.PerformClick();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textArea.Text != "")
                if (MessageBox.Show("Сохранить файл?", "Завершение..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    saveFileButton.PerformClick();
            if (MessageBox.Show("Вы точно хотите выйти?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileButton.PerformClick();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileButton.PerformClick();
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAsFileButton.PerformClick();
        }

        private void выезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cutButton.PerformClick();
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyButton.PerformClick();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pasteButton.PerformClick();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textArea.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textArea.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textArea.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoButton.PerformClick();
        }

        private void выделитьВсёToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectAllButton.PerformClick();
        }

        private void цветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectColorButton.PerformClick();
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectFontButton.PerformClick();
        }



        private void button4_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textArea.SaveFile(saveFileDialog1.FileName);
                FileName = saveFileDialog1.FileName; Text = saveFileDialog1.FileName;
            }
            textArea.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textArea.Copy();
            textArea.Focus();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textArea.Paste();
            textArea.Focus();
        }


        private void button11_Click(object sender, EventArgs e)
        {
            textArea.Undo();
            textArea.Focus();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textArea.SelectAll();
            textArea.Focus();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                textArea.SelectionColor = colorDialog1.Color;
            textArea.Focus();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                textArea.SelectionFont = fontDialog1.Font;
            textArea.Focus();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textArea.Text = "";
        }

        private void addImageButton_Click(object sender, EventArgs e)
        {
            insetImage(textArea);
        }

        void insetImage(RichTextBox item)
        {
            openFileDialog1.Filter = "PNG| *.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImageName = openFileDialog1.FileName;
                var image = new Hashtable(1) { { item, Image.FromFile(ImageName) } };
                Clipboard.SetImage((Image)image[item]);
                item.Paste();
            }
                
            
            textArea.Focus();
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void findButton_Click(object sender, EventArgs e)
        {
            findPanel.Visible = !findPanel.Visible;
        }

        private void findBtn2_Click(object sender, EventArgs e)
        {
            string str = findText.Text;
            if (textArea.Find(str).ToString() != "-1")
            {
                textArea.Focus();
                textArea.Find(str);
            }
            else
            {
                MessageBox.Show("Ничего не найдено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void findCloseButton_Click(object sender, EventArgs e)
        {
            findPanel.Visible = false;
        }

        private void cutButton_Click(object sender, EventArgs e)
        {
            textArea.Cut();
            textArea.Focus();
        }

        private void newFileButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сохранить?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                saveFileButton.PerformClick();
            textArea.Clear();
            FileName = "Новый.rtf";
            Text = FileName;
            textArea.Focus();
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "RTF| *.rtf";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textArea.LoadFile(openFileDialog1.FileName);
                FileName = openFileDialog1.FileName;
                Text = FileName;
            }
            textArea.Focus();
        }

        private void вставкаИзображенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addImageButton.PerformClick();
            
        }

        private void refreshutton_Click(object sender, EventArgs e)
        {
            

        }

        private void iconListButton_Click(object sender, EventArgs e)
        {
            textArea.SelectionBullet = !textArea.SelectionBullet;
            
        }

        private void абзацToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sectionFormatPanel.Visible = !sectionFormatPanel.Visible;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            sectionFormatPanel.Visible = false;
            indentNUD.Value = 0; fIndentNUD.Value=0; sIndentNUD.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textArea.SelectionIndent = (int)sIndentNUD.Value;
            textArea.SelectionRightIndent = (int)fIndentNUD.Value;
            textArea.SelectionIndent = (int)indentNUD.Value;
        }
    }

}
