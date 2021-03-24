using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pacMan
{
    public partial class pacMan : Form
    {
        #region Key Binds
        bool upDown = false;
        bool downDown = false;
        bool leftDown = false;
        bool rightDown = false;
        bool spaceBar = false;
        #endregion

        string gameState = "waiting";

        SolidBrush goldBrush = new SolidBrush(Color.Gold);
        Pen bluePen = new Pen(Color.Blue);

        public pacMan()
        {
            InitializeComponent();
        }
        private void PlayButton_Click(object sender, EventArgs e)
        {
            titleLabel.Text = "";
            playButton.Visible = false;
            controlsButton.Visible = false;
            gameTimer.Enabled = true;
            gameState = "running";
        }        
        private void PacMan_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upDown = true;
                    break;
                case Keys.Down:
                    downDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.Space:
                    spaceBar = true;
                    if (gameState == "waiting" || gameState == "over")
                    {
                        
                    }
                    break;
                case Keys.Escape:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        Application.Exit();
                    }
                    break;
            }
        }

        private void PacMan_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upDown = false;
                    break;
                case Keys.Down:
                    downDown = false;
                    break;
                case Keys.Right:
                    rightDown = false;
                    break;
                case Keys.Left:
                    leftDown = false;
                    break;
            }
        }

        private void PacMan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {

        }

    }
}

