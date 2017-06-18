using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SnakeOOP;

namespace WinSnake
{
    public partial class Form1 : Form
    {
        IFieldViewable field;
        UserAction action = UserAction.Top;

        public Form1()
        {
            DoubleBuffered = true;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            field = new Field(44,35);
            field.Initialize();
            DataGridSnake.RowCount = field.Width;
            DataGridSnake.ColumnCount = field.Height;

            for (int i = 0; i < field.Height; i++)
            {
                DataGridSnake.Columns[i].Width = 17;
            }
            for (int i = 0; i < field.Width; i++)
            {
                DataGridSnake.Rows[i].Height = 10;
            }

            DataGridSnake.Enabled = false;

            ShowElements();
            
            
            
        }

        private void ShowElements()
        {
            for (int i = 0; i < field.Height; i++)
            {
                for (int j = 0; j < field.Width; j++)
                {
                    if (field[i, j] is Obstacle)
                    {
                        if (DataGridSnake[i, j].Style.BackColor != Color.Yellow)
                        {
                            DataGridSnake[i, j].Style.BackColor = Color.Yellow;    
                        }                        
                    }
                    else if (field[i, j] is Food)
                    {
                        if (DataGridSnake[i, j].Style.BackColor != Color.Green)
                        {
                            DataGridSnake[i, j].Style.BackColor = Color.Green;    
                        }                        
                    }
                    else if (field[i, j] is Head)
                    {
                        if (DataGridSnake[i, j].Style.BackColor != Color.Red)
                        {
                            DataGridSnake[i, j].Style.BackColor = Color.Red;    
                        }                        
                    }
                    else if (field[i, j] is Body)
                    {
                        if (DataGridSnake[i, j].Style.BackColor != Color.Blue)
                        {
                            DataGridSnake[i, j].Style.BackColor = Color.Blue;
                        }
                    }
                    else
                    {
                        if (DataGridSnake[i, j].Style.BackColor != Color.White)
                        {
                            DataGridSnake[i, j].Style.BackColor = Color.White;
                        }                        
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            
            //field.Run(action);
            //ShowElements();
        }

        private void DataGridSnake_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                default:
                    break;
            }

            //field.Run(action);
            //ShowElements();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //(sender as Timer).Enabled = false;

            if (field.IsGameOver())
            {
                field.Run(action);
                ShowElements();
            }
            else
            {
                timer1.Stop();
                MessageBox.Show("GAME OVER");
                Close();
            }

            (sender as Timer).Enabled = true;
        }

        private void btUP_Click(object sender, EventArgs e)
        {
            action = UserAction.Top;
        }

        private void btLeft_Click(object sender, EventArgs e)
        {
            action = UserAction.Left;
        }

        private void btRight_Click(object sender, EventArgs e)
        {
            action = UserAction.Right;
        }

        private void btDowm_Click(object sender, EventArgs e)
        {
            action = UserAction.Bottom;
        }

        private void btUP_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            field.Initialize();
            ShowElements();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //switch (e.KeyData)
            //{
            //    case Keys.Down:
            //    case Keys.S:
            //        action = UserAction.Bottom;
            //        break;
            //    case Keys.Left:
            //    case Keys.A:
            //        action = UserAction.Left;
            //        break;
            //    case Keys.Escape:
            //        Close();    // Завершение работы приложения
            //        break;
            //    case Keys.Up:
            //        break;
            //    default:
            //        break;
            //}
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool retOk = true;

            switch (keyData)
            {
                case Keys.Down:
//                case Keys.S:
                    action = UserAction.Bottom;
                    break;
                case Keys.Left:
//                case Keys.A:
                    action = UserAction.Left;
                    break;
                case Keys.Escape:
                    Close();    // Завершение работы приложения
                    break;
                case Keys.Up:
                    action = UserAction.Top;
                    break;
                default:
                    retOk = base.ProcessCmdKey(ref msg, keyData);
                    break;
            }

            return retOk;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)        
        {
            timer1.Enabled = false;
            if (MessageBox.Show("Вы уверены?", "", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                field = new Field(44, 35);
                field.Initialize();
                DataGridSnake.RowCount = field.Width;
                DataGridSnake.ColumnCount = field.Height;

                for (int i = 0; i < field.Height; i++)
                {
                    DataGridSnake.Columns[i].Width = 17;
                }
                for (int i = 0; i < field.Width; i++)
                {
                    DataGridSnake.Rows[i].Height = 10;
                }

                DataGridSnake.Enabled = false;

                ShowElements();
            }
            else
            {
                e.Cancel = true;
                timer1.Enabled = true;
            }
        }

    }
}
