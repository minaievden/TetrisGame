using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using  Курсовой_по_ОПП.Тетрис;

namespace Курсовой_по_ОПП
{
    public partial class Form1 : Form
    {
        int level = 1;
        Tetris tetris;
        
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (tetris != null && tetris.gameIsOver == false)
            {
                if (e.KeyCode == Keys.Left)
                {
                    tetris.Muve(1);
                }

                if (e.KeyCode == Keys.Right)
                {
                    tetris.Muve(2);
                }
                if (e.KeyCode == Keys.Down)
                {
                    tetris.Muve(3);
                }

                if (e.KeyCode == Keys.Up)
                {
                    tetris.WipeOffFigure();
                    tetris.Rotate();
                    tetris.DrowFigure();
                }
            }
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (tetris != null)
                tetris.DrawOllField();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {   
            стартToolStripMenuItem.Enabled = false;
            стопToolStripMenuItem.Enabled = false;
            уровень1ToolStripMenuItem.Checked = true;
        }

        private void Form1_Resize(object sender, EventArgs e)//при изменении размеров формы
        {
            if (tetris != null)
            {
                tetris.SetArea(this.CreateGraphics(), this.BackColor, this.Width, this.Height, 20, 50);
                tetris.DrawOllField();
            }

        }

        private void стопToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tetris.Stop();
            стартToolStripMenuItem.Enabled = true;
            стопToolStripMenuItem.Enabled = false;
    
        }

        private void стартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tetris.Start();
            стопToolStripMenuItem.Enabled = true;
            стартToolStripMenuItem.Enabled = false;
        }

        private void начатьНовуюИгруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tetris != null)
            {
                tetris.WipeOffFeeld();
                tetris.Dispose();
            }
            стопToolStripMenuItem.Enabled = true;
            стопToolStripMenuItem.Enabled = true;
            tetris = new Tetris(level);
            tetris.SetArea(this.CreateGraphics(), this.BackColor, this.Width, this.Height, 20, 50);
            tetris.GenerateFigure();
            tetris.DrawOllField();
            tetris.Start();
        }

        private void уровень1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            уровень2ToolStripMenuItem.Checked = false;
            уровень3ToolStripMenuItem.Checked = false;
            уровень4ToolStripMenuItem.Checked = false;
            уровень1ToolStripMenuItem.Checked = true;
            level = 1;
            tetris.Level = level;
        }

        private void уровень2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            уровень1ToolStripMenuItem.Checked = false;
            уровень3ToolStripMenuItem.Checked = false;
            уровень4ToolStripMenuItem.Checked = false;
            уровень2ToolStripMenuItem.Checked = true;
            level = 2;
            tetris.Level = level;
        }

        private void уровень3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            уровень2ToolStripMenuItem.Checked = false;
            уровень1ToolStripMenuItem.Checked = false;
            уровень4ToolStripMenuItem.Checked = false;
            уровень3ToolStripMenuItem.Checked = true;
            level = 3;
            tetris.Level = level;
        }

        private void уровень4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            уровень2ToolStripMenuItem.Checked = false;
            уровень3ToolStripMenuItem.Checked = false;
            уровень1ToolStripMenuItem.Checked = false;
            уровень4ToolStripMenuItem.Checked = true;
            level = 4;
            tetris.Level = level;
        }
    }
}
