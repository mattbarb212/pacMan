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
        int borderX = 3;
        int borderY = 3;
        int borderWidth = 354;
        int borderHeight = 494;
        int pacManX = 175;
        int pacManY = 310;
        int pacManHeight = 15;
        int pacManWidth = 15;
        int pacManSpeed = 3;
        int borderLineWidth = 5;

        #region Key Binds
        bool upDown = false;
        bool downDown = false;
        bool leftDown = false;
        bool rightDown = false;
        bool spaceBar = false;
        #endregion

        List<int> wallXList = new List<int>();
        List<int> wallYList = new List<int>();
        List<int> wallWidthList = new List<int>();
        List<int> wallHeightList = new List<int>();

        string gameState = "waiting";

        SolidBrush goldBrush = new SolidBrush(Color.Gold);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        Pen bluePen = new Pen(Color.Blue, 5);

        public pacMan()
        {
            InitializeComponent();
        }
        public void GameInitialize()
        {
            titleLabel.Text = "";
            playButton.Visible = false;
            controlsButton.Visible = false;
            gameTimer.Enabled = true;
            gameState = "running";
            this.Focus();

            wallXList.Add(220);
            wallYList.Add(460);
            wallWidthList.Add(90);
            wallHeightList.Add(5);

            wallXList.Add(50);
            wallYList.Add(460);
            wallWidthList.Add(100);
            wallHeightList.Add(5);

            wallXList.Add(310);
            wallYList.Add(420);
            wallWidthList.Add(50);
            wallHeightList.Add(5);

            wallXList.Add(0);
            wallYList.Add(420);
            wallWidthList.Add(50);
            wallHeightList.Add(5);

            wallXList.Add(150);
            wallYList.Add(420);
            wallWidthList.Add(70);
            wallHeightList.Add(5);

            wallXList.Add(265);
            wallYList.Add(420);
            wallWidthList.Add(5);
            wallHeightList.Add(40);

            wallXList.Add(185);
            wallYList.Add(420);
            wallWidthList.Add(5);
            wallHeightList.Add(40);

            wallXList.Add(100);
            wallYList.Add(420);
            wallWidthList.Add(5);
            wallHeightList.Add(40);

            wallXList.Add(220);
            wallYList.Add(380);
            wallWidthList.Add(45);
            wallHeightList.Add(5);

            wallXList.Add(100);
            wallYList.Add(380);
            wallWidthList.Add(50);
            wallHeightList.Add(5);

            wallXList.Add(50);
            wallYList.Add(340);
            wallWidthList.Add(5);
            wallHeightList.Add(40);

            wallXList.Add(310);
            wallYList.Add(340);
            wallWidthList.Add(5);
            wallHeightList.Add(40);

            wallXList.Add(150);
            wallYList.Add(340);
            wallWidthList.Add(70);
            wallHeightList.Add(5);

            wallXList.Add(185);
            wallYList.Add(340);
            wallWidthList.Add(5);
            wallHeightList.Add(40);

            wallXList.Add(0);
            wallYList.Add(300);
            wallWidthList.Add(150);
            wallHeightList.Add(5);

            wallXList.Add(220);
            wallYList.Add(300);
            wallWidthList.Add(140);
            wallHeightList.Add(5);

            wallXList.Add(265);
            wallYList.Add(300);
            wallWidthList.Add(5);
            wallHeightList.Add(40);

            wallXList.Add(100);
            wallYList.Add(300);
            wallWidthList.Add(5);
            wallHeightList.Add(40);

            wallXList.Add(220);
            wallYList.Add(40);
            wallWidthList.Add(90);
            wallHeightList.Add(5);

            wallXList.Add(50);
            wallYList.Add(40);
            wallWidthList.Add(100);
            wallHeightList.Add(5);

            wallXList.Add(310);
            wallYList.Add(80);
            wallWidthList.Add(50);
            wallHeightList.Add(5);

            wallXList.Add(0);
            wallYList.Add(80);
            wallWidthList.Add(50);
            wallHeightList.Add(5);

            wallXList.Add(150);
            wallYList.Add(80);
            wallWidthList.Add(70);
            wallHeightList.Add(5);

            wallXList.Add(265);
            wallYList.Add(40);
            wallWidthList.Add(5);
            wallHeightList.Add(40);

            wallXList.Add(185);
            wallYList.Add(40);
            wallWidthList.Add(5);
            wallHeightList.Add(40);

            wallXList.Add(100);
            wallYList.Add(40);
            wallWidthList.Add(5);
            wallHeightList.Add(40);

            wallXList.Add(220);
            wallYList.Add(120);
            wallWidthList.Add(45);
            wallHeightList.Add(5);

            wallXList.Add(100);
            wallYList.Add(120);
            wallWidthList.Add(50);
            wallHeightList.Add(5);

            wallXList.Add(50);
            wallYList.Add(120);
            wallWidthList.Add(5);
            wallHeightList.Add(40);

            wallXList.Add(310);
            wallYList.Add(120);
            wallWidthList.Add(5);
            wallHeightList.Add(40);

            wallXList.Add(150);
            wallYList.Add(160);
            wallWidthList.Add(70);
            wallHeightList.Add(5);

            wallXList.Add(185);
            wallYList.Add(120);
            wallWidthList.Add(5);
            wallHeightList.Add(40);

            wallXList.Add(0);
            wallYList.Add(200);
            wallWidthList.Add(150);
            wallHeightList.Add(5);

            wallXList.Add(220);
            wallYList.Add(200);
            wallWidthList.Add(140);
            wallHeightList.Add(5);

            wallXList.Add(265);
            wallYList.Add(200);
            wallWidthList.Add(5);
            wallHeightList.Add(40);

            wallXList.Add(100);
            wallYList.Add(200);
            wallWidthList.Add(5);
            wallHeightList.Add(40);
        }
        private void PlayButton_Click(object sender, EventArgs e)
        {
            GameInitialize();
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
                        GameInitialize();
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
            if (gameState == "running")
            {
                e.Graphics.DrawRectangle(bluePen, borderX, borderY, borderWidth, borderHeight);
                e.Graphics.FillEllipse(goldBrush, pacManX, pacManY, pacManWidth, pacManHeight);
                //e.Graphics.DrawLine(bluePen, 220, 460, 310, 460);
                //e.Graphics.DrawLine(bluePen, 50, 460, 150, 460);
                //e.Graphics.DrawLine(bluePen, 360, 420, 310, 420);
                //e.Graphics.DrawLine(bluePen, 0, 420, 50, 420);
                //e.Graphics.DrawLine(bluePen, 150, 420, 220, 420);
                //e.Graphics.DrawLine(bluePen, 265, 420, 265, 460);
                //e.Graphics.DrawLine(bluePen, 185, 420, 185, 460);
                //e.Graphics.DrawLine(bluePen, 100, 420, 100, 460);
                //e.Graphics.DrawLine(bluePen, 220, 380, 265, 380);
                //e.Graphics.DrawLine(bluePen, 150, 380, 100, 380);
                //e.Graphics.DrawLine(bluePen, 50, 380, 50, 340);
                //e.Graphics.DrawLine(bluePen, 310, 380, 310, 340);
                //e.Graphics.DrawLine(bluePen, 150, 340, 220, 340);
                //e.Graphics.DrawLine(bluePen, 185, 340, 185, 380);
                //e.Graphics.DrawLine(bluePen, 0, 300, 150, 300);
                //e.Graphics.DrawLine(bluePen, 220, 300, 360, 300);
                //e.Graphics.DrawLine(bluePen, 265, 300, 265, 340);
                //e.Graphics.DrawLine(bluePen, 100, 300, 100, 340);
                //e.Graphics.DrawLine(bluePen, 220, 40, 310, 40);
                //e.Graphics.DrawLine(bluePen, 50, 40, 150, 40);
                //e.Graphics.DrawLine(bluePen, 360, 80, 310, 80);
                //e.Graphics.DrawLine(bluePen, 0, 80, 50, 80);
                //e.Graphics.DrawLine(bluePen, 150, 80, 220, 80);
                //e.Graphics.DrawLine(bluePen, 265, 80, 265, 40);
                //e.Graphics.DrawLine(bluePen, 185, 80, 185, 40);
                //e.Graphics.DrawLine(bluePen, 100, 80, 100, 40);
                //e.Graphics.DrawLine(bluePen, 220, 120, 265, 120);
                //e.Graphics.DrawLine(bluePen, 150, 120, 100, 120);
                //e.Graphics.DrawLine(bluePen, 50, 120, 50, 160);
                //e.Graphics.DrawLine(bluePen, 310, 120, 310, 160);
                //e.Graphics.DrawLine(bluePen, 150, 160, 220, 160);
                //e.Graphics.DrawLine(bluePen, 185, 160, 185, 120);
                //e.Graphics.DrawLine(bluePen, 0, 200, 150, 200);
                //e.Graphics.DrawLine(bluePen, 220, 200, 360, 200);
                //e.Graphics.DrawLine(bluePen, 265, 200, 265, 160);
                //e.Graphics.DrawLine(bluePen, 100, 200, 100, 160);
                for (int i = 0; i < wallXList.Count; i++)
                {
                    e.Graphics.FillRectangle(blueBrush, wallXList[i], wallYList[i], wallWidthList[i], wallHeightList[i]);
                }
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {            
            //Move Player
            if (upDown == true && pacManY > borderY + 6)
            {
                pacManY -= pacManSpeed;
            }

            if (downDown == true && pacManY < borderHeight - pacManHeight)
            {
                pacManY += pacManSpeed;
            }
            if (leftDown == true && pacManX > borderX + borderLineWidth)
            {
                pacManX -= pacManSpeed;
            }
            if (rightDown == true && pacManX < borderWidth - pacManWidth)
            {
                pacManX += pacManSpeed;
            }

            Refresh();
        }        
    }
}

