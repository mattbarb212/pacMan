using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// Matthew Barber
/// PacMan
/// March, 2021

namespace pacMan
{
    public partial class pacMan : Form
    {
        #region Images
        Image pacManUpImage;
        Image pacManLeftImage;
        Image pacManRightImage;
        Image pacManDownImage;
        Image pacManBaseImage;
        Image pacManMouthClosedImage;
        #endregion

        #region Integers
        int borderX = 3;
        int borderY = 3;
        int borderWidth = 354;
        int borderHeight = 494;
        int pacManX = 175;
        int pacManY = 295;
        int pacManHeight = 20;
        int pacManWidth = 20;
        int pacManSpeed = 3;
        int borderLineWidth = 5;
        int score = 0000;
        int animationCounter = 1;
        int lives = 3;

        Random randGen = new Random();
        #endregion

        #region Key Binds
        bool upDown = false;
        bool downDown = false;
        bool leftDown = false;
        bool rightDown = false;
        #endregion

        #region Lists
        List<int> wallXList = new List<int>();
        List<int> wallYList = new List<int>();
        List<int> wallWidthList = new List<int>();
        List<int> wallHeightList = new List<int>();
        List<int> orbXList = new List<int>();
        List<int> orbYList = new List<int>();
        List<int> orbWidthList = new List<int>();
        List<int> orbHeightList = new List<int>();
        List<int> ghostXList = new List<int>();
        List<int> ghostYList = new List<int>();
        List<int> ghostWidthList = new List<int>();
        List<int> ghostHeightList = new List<int>();
        List<int> ghostYSpeedList = new List<int>();
        List<int> ghostXSpeedList = new List<int>();
        List<string> ghostColorList = new List<string>();
        #endregion

        string gameState = "waiting";

        #region Brushes
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush pinkBrush = new SolidBrush(Color.Pink);
        SolidBrush cyanBrush = new SolidBrush(Color.Cyan);
        SolidBrush orangeBrush = new SolidBrush(Color.Orange);
        Pen bluePen = new Pen(Color.Blue, 5);
        #endregion

        public pacMan()
        {
            InitializeComponent();
        }
        public void GameInitialize()
        {
            titleLabel.Text = "";
            scoreLabel.Text = $"Score\n{score.ToString("0000")}";
            playButton.Visible = false;
            controlsButton.Visible = false;
            gameTimer.Enabled = true;
            gameState = "running";
            this.Focus();

            #region Images
            pacManUpImage = Properties.Resources.PacManUpMouthOpen;
            pacManLeftImage = Properties.Resources.PacManLeftMouthOpen;
            pacManRightImage = Properties.Resources.PacManRightMouthOpen;
            pacManDownImage = Properties.Resources.PacManDownMouthOpen;
            pacManMouthClosedImage = Properties.Resources.PacManOpenClosed;
            pacManBaseImage = Properties.Resources.pacmanBaseImage;
            #endregion

            #region Map Wall Locations
            wallXList.Add(0);
            wallYList.Add(0);
            wallWidthList.Add(5);
            wallHeightList.Add(494);

            wallXList.Add(0);
            wallYList.Add(494);
            wallWidthList.Add(360);
            wallHeightList.Add(5);

            wallXList.Add(360);
            wallYList.Add(0);
            wallWidthList.Add(5);
            wallHeightList.Add(500);

            wallXList.Add(0);
            wallYList.Add(0);
            wallWidthList.Add(360);
            wallHeightList.Add(5);

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
            wallYList.Add(160);
            wallWidthList.Add(5);
            wallHeightList.Add(40);

            wallXList.Add(100);
            wallYList.Add(160);
            wallWidthList.Add(5);
            wallHeightList.Add(40);

            wallXList.Add(50);
            wallYList.Add(230);
            wallWidthList.Add(5);
            wallHeightList.Add(40);

            wallXList.Add(310);
            wallYList.Add(230);
            wallWidthList.Add(5);
            wallHeightList.Add(40);

            wallXList.Add(220);
            wallYList.Add(230);
            wallWidthList.Add(5);
            wallHeightList.Add(40);

            wallXList.Add(145);
            wallYList.Add(230);
            wallWidthList.Add(5);
            wallHeightList.Add(40);

            wallXList.Add(145);
            wallYList.Add(270);
            wallWidthList.Add(80);
            wallHeightList.Add(5);

            wallXList.Add(95);
            wallYList.Add(230);
            wallWidthList.Add(5);
            wallHeightList.Add(40);

            wallXList.Add(265);
            wallYList.Add(230);
            wallWidthList.Add(5);
            wallHeightList.Add(40);
            #endregion

            #region Orb Locations
            orbXList.Add(20);
            orbYList.Add(20);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(100);
            orbYList.Add(140);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(40);
            orbYList.Add(20);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(60);
            orbYList.Add(20);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(80);
            orbYList.Add(20);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(100);
            orbYList.Add(20);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(120);
            orbYList.Add(20);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(140);
            orbYList.Add(20);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(160);
            orbYList.Add(20);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(180);
            orbYList.Add(20);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(200);
            orbYList.Add(20);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(220);
            orbYList.Add(20);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(240);
            orbYList.Add(20);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(260);
            orbYList.Add(20);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(280);
            orbYList.Add(20);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(300);
            orbYList.Add(20);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(320);
            orbYList.Add(20);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(340);
            orbYList.Add(20);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(20);
            orbYList.Add(40);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(20);
            orbYList.Add(60);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(40);
            orbYList.Add(60);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(60);
            orbYList.Add(60);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(80);
            orbYList.Add(60);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(80);
            orbYList.Add(80);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(80);
            orbYList.Add(100);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(80);
            orbYList.Add(120);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(80);
            orbYList.Add(140);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(80);
            orbYList.Add(160);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(80);
            orbYList.Add(180);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(60);
            orbYList.Add(180);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(40);
            orbYList.Add(180);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(20);
            orbYList.Add(180);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(20);
            orbYList.Add(160);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(20);
            orbYList.Add(140);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(20);
            orbYList.Add(120);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(20);
            orbYList.Add(100);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(40);
            orbYList.Add(100);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(60);
            orbYList.Add(100);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(100);
            orbYList.Add(100);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(120);
            orbYList.Add(100);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(140);
            orbYList.Add(100);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(160);
            orbYList.Add(100);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(120);
            orbYList.Add(80);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(120);
            orbYList.Add(60);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(140);
            orbYList.Add(60);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(160);
            orbYList.Add(60);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(160);
            orbYList.Add(40);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(200);
            orbYList.Add(40);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(200);
            orbYList.Add(60);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(220);
            orbYList.Add(60);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(240);
            orbYList.Add(60);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(240);
            orbYList.Add(80);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(240);
            orbYList.Add(100);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(220);
            orbYList.Add(100);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(200);
            orbYList.Add(100);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(180);
            orbYList.Add(100);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(260);
            orbYList.Add(100);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(280);
            orbYList.Add(100);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(300);
            orbYList.Add(100);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(280);
            orbYList.Add(80);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(280);
            orbYList.Add(60);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(300);
            orbYList.Add(60);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(320);
            orbYList.Add(60);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(340);
            orbYList.Add(60);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(340);
            orbYList.Add(40);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(320);
            orbYList.Add(100);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(340);
            orbYList.Add(100);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(340);
            orbYList.Add(120);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(340);
            orbYList.Add(140);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(340);
            orbYList.Add(160);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(340);
            orbYList.Add(180);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(320);
            orbYList.Add(180);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(300);
            orbYList.Add(180);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(280);
            orbYList.Add(180);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(280);
            orbYList.Add(160);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(280);
            orbYList.Add(140);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(280);
            orbYList.Add(120);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(260);
            orbYList.Add(140);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(240);
            orbYList.Add(140);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(220);
            orbYList.Add(140);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(200);
            orbYList.Add(140);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(200);
            orbYList.Add(120);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(240);
            orbYList.Add(160);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(240);
            orbYList.Add(180);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(220);
            orbYList.Add(180);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(200);
            orbYList.Add(180);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(180);
            orbYList.Add(180);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(160);
            orbYList.Add(180);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(140);
            orbYList.Add(180);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(120);
            orbYList.Add(180);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(120);
            orbYList.Add(160);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(120);
            orbYList.Add(140);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(140);
            orbYList.Add(140);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(160);
            orbYList.Add(140);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(160);
            orbYList.Add(120);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(20);
            orbYList.Add(480);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(40);
            orbYList.Add(480);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(60);
            orbYList.Add(480);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(80);
            orbYList.Add(480);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(100);
            orbYList.Add(480);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(120);
            orbYList.Add(480);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(140);
            orbYList.Add(480);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(160);
            orbYList.Add(480);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(180);
            orbYList.Add(480);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(200);
            orbYList.Add(480);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(220);
            orbYList.Add(480);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(240);
            orbYList.Add(480);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(260);
            orbYList.Add(480);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(280);
            orbYList.Add(480);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(300);
            orbYList.Add(480);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(320);
            orbYList.Add(480);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(340);
            orbYList.Add(480);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(20);
            orbYList.Add(460);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(20);
            orbYList.Add(440);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(40);
            orbYList.Add(440);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(60);
            orbYList.Add(440);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(80);
            orbYList.Add(440);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(80);
            orbYList.Add(420);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(80);
            orbYList.Add(400);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(80);
            orbYList.Add(380);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(80);
            orbYList.Add(360);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(80);
            orbYList.Add(340);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(80);
            orbYList.Add(320);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(60);
            orbYList.Add(320);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(40);
            orbYList.Add(320);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(20);
            orbYList.Add(320);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(20);
            orbYList.Add(340);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(20);
            orbYList.Add(360);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(20);
            orbYList.Add(380);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(20);
            orbYList.Add(400);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(40);
            orbYList.Add(400);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(60);
            orbYList.Add(400);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(100);
            orbYList.Add(400);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(120);
            orbYList.Add(400);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(140);
            orbYList.Add(400);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(160);
            orbYList.Add(400);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(120);
            orbYList.Add(420);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(120);
            orbYList.Add(440);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(140);
            orbYList.Add(440);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(160);
            orbYList.Add(440);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(160);
            orbYList.Add(460);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(200);
            orbYList.Add(460);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(200);
            orbYList.Add(460);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(220);
            orbYList.Add(440);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(240);
            orbYList.Add(440);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(240);
            orbYList.Add(420);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(240);
            orbYList.Add(400);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(220);
            orbYList.Add(400);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(200);
            orbYList.Add(400);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(180);
            orbYList.Add(400);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(260);
            orbYList.Add(400);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(280);
            orbYList.Add(400);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(300);
            orbYList.Add(400);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(280);
            orbYList.Add(420);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(280);
            orbYList.Add(440);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(300);
            orbYList.Add(440);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(320);
            orbYList.Add(440);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(340);
            orbYList.Add(440);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(340);
            orbYList.Add(460);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(320);
            orbYList.Add(400);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(340);
            orbYList.Add(400);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(340);
            orbYList.Add(380);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(340);
            orbYList.Add(360);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(340);
            orbYList.Add(340);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(340);
            orbYList.Add(320);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(320);
            orbYList.Add(320);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(300);
            orbYList.Add(320);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(280);
            orbYList.Add(320);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(280);
            orbYList.Add(340);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(280);
            orbYList.Add(360);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(280);
            orbYList.Add(380);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(260);
            orbYList.Add(360);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(240);
            orbYList.Add(360);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(220);
            orbYList.Add(360);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(200);
            orbYList.Add(360);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(200);
            orbYList.Add(380);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(240);
            orbYList.Add(340);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(240);
            orbYList.Add(320);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(220);
            orbYList.Add(320);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(200);
            orbYList.Add(320);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(180);
            orbYList.Add(320);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(160);
            orbYList.Add(320);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(140);
            orbYList.Add(320);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(120);
            orbYList.Add(320);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(120);
            orbYList.Add(340);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(120);
            orbYList.Add(340);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(140);
            orbYList.Add(360);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(160);
            orbYList.Add(360);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(160);
            orbYList.Add(380);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(120);
            orbYList.Add(360);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(100);
            orbYList.Add(360);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(200);
            orbYList.Add(440);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(20);
            orbYList.Add(220);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(20);
            orbYList.Add(240);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(20);
            orbYList.Add(260);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(20);
            orbYList.Add(280);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(40);
            orbYList.Add(280);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(60);
            orbYList.Add(280);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(80);
            orbYList.Add(280);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(100);
            orbYList.Add(280);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(120);
            orbYList.Add(280);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(140);
            orbYList.Add(280);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(160);
            orbYList.Add(280);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(180);
            orbYList.Add(280);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(200);
            orbYList.Add(280);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(220);
            orbYList.Add(280);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(240);
            orbYList.Add(280);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(260);
            orbYList.Add(280);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(280);
            orbYList.Add(280);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(300);
            orbYList.Add(280);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(320);
            orbYList.Add(280);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(340);
            orbYList.Add(280);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(340);
            orbYList.Add(260);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(340);
            orbYList.Add(240);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(340);
            orbYList.Add(220);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(320);
            orbYList.Add(220);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(300);
            orbYList.Add(220);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(280);
            orbYList.Add(220);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(260);
            orbYList.Add(220);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(240);
            orbYList.Add(220);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(220);
            orbYList.Add(220);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(200);
            orbYList.Add(220);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(180);
            orbYList.Add(220);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(160);
            orbYList.Add(220);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(140);
            orbYList.Add(220);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(120);
            orbYList.Add(220);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(100);
            orbYList.Add(220);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(80);
            orbYList.Add(220);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(60);
            orbYList.Add(220);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(40);
            orbYList.Add(220);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(70);
            orbYList.Add(240);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(70);
            orbYList.Add(260);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(120);
            orbYList.Add(240);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(120);
            orbYList.Add(260);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(240);
            orbYList.Add(240);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(240);
            orbYList.Add(260);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(290);
            orbYList.Add(240);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(290);
            orbYList.Add(260);
            orbWidthList.Add(5);
            orbHeightList.Add(5);

            orbXList.Add(180);
            orbYList.Add(200);
            orbWidthList.Add(5);
            orbHeightList.Add(5);
            #endregion

            #region Ghost Locations
            ghostXList.Add(10);
            ghostYList.Add(10);
            ghostWidthList.Add(20);
            ghostHeightList.Add(20);
            ghostColorList.Add("pink");
            ghostYSpeedList.Add(-4);
            ghostXSpeedList.Add(0);

            ghostXList.Add(330);
            ghostYList.Add(10);
            ghostWidthList.Add(20);
            ghostHeightList.Add(20);
            ghostColorList.Add("red");
            ghostYSpeedList.Add(-4);
            ghostXSpeedList.Add(0);

            ghostXList.Add(10);
            ghostYList.Add(450);
            ghostWidthList.Add(20);
            ghostHeightList.Add(20);
            ghostColorList.Add("cyan");
            ghostYSpeedList.Add(-4);
            ghostXSpeedList.Add(0);

            ghostXList.Add(330);
            ghostYList.Add(450);
            ghostWidthList.Add(20);
            ghostHeightList.Add(20);
            ghostColorList.Add("orange");
            ghostYSpeedList.Add(-4);
            ghostXSpeedList.Add(0);
            #endregion
        }
        private void PlayButton_Click(object sender, EventArgs e)
        {
            GameInitialize();
        }
        private void PacMan_KeyDown(object sender, KeyEventArgs e)
        {
            #region Key Dow Binds
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
            #endregion
        }

        private void PacMan_KeyUp(object sender, KeyEventArgs e)
        {
            #region Key Up Binds
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upDown = false;
                    animationCounter = 1;
                    pacManBaseImage = pacManMouthClosedImage;
                    break;
                case Keys.Down:
                    downDown = false;
                    animationCounter = 1;
                    pacManBaseImage = pacManMouthClosedImage;
                    break;
                case Keys.Right:
                    rightDown = false;
                    animationCounter = 1;
                    pacManBaseImage = pacManMouthClosedImage;
                    break;
                case Keys.Left:
                    leftDown = false;
                    animationCounter = 1;
                    pacManBaseImage = pacManMouthClosedImage;
                    break;
            }
            #endregion
        }

        private void PacMan_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == "running")
            {
                //e.Graphics.DrawRectangle(bluePen, borderX, borderY, borderWidth, borderHeight);
                e.Graphics.DrawImage(pacManBaseImage, pacManX, pacManY, pacManWidth, pacManHeight);

                for (int i = 0; i < wallXList.Count; i++)
                {
                    e.Graphics.FillRectangle(blueBrush, wallXList[i], wallYList[i], wallWidthList[i], wallHeightList[i]);
                }
                for (int i = 0; i < orbXList.Count; i++)
                {
                    e.Graphics.FillRectangle(whiteBrush, orbXList[i], orbYList[i], orbWidthList[i], orbHeightList[i]);
                }
                for (int i = 0; i < ghostXList.Count; i++)
                {
                    if (ghostColorList[i] == "pink")
                    {
                        e.Graphics.FillRectangle(pinkBrush, ghostXList[i], ghostYList[i], ghostWidthList[i], ghostHeightList[i]);
                    }
                    if (ghostColorList[i] == "red")
                    {
                        e.Graphics.FillRectangle(redBrush, ghostXList[i], ghostYList[i], ghostWidthList[i], ghostHeightList[i]);
                    }
                    if (ghostColorList[i] == "cyan")
                    {
                        e.Graphics.FillRectangle(cyanBrush, ghostXList[i], ghostYList[i], ghostWidthList[i], ghostHeightList[i]);
                    }
                    if (ghostColorList[i] == "orange")
                    {
                        e.Graphics.FillRectangle(orangeBrush, ghostXList[i], ghostYList[i], ghostWidthList[i], ghostHeightList[i]);
                    }
                }
            }
        }



        private void GameTimer_Tick(object sender, EventArgs e)
        {
            #region Move Player
            //Move Player

            int origX = pacManX;
            int origY = pacManY;

            if (upDown == true && pacManY > borderY + 6)
            {
                pacManY -= pacManSpeed;

                if (animationCounter < 4)
                {
                    pacManBaseImage = pacManUpImage;
                }
                else if (animationCounter < 7)
                {
                    pacManBaseImage = pacManMouthClosedImage;
                }

                animationCounter++;

                if (animationCounter >= 7)
                {
                    animationCounter = 1;
                }
            }

            if (downDown == true && pacManY < borderHeight - pacManHeight)
            {
                pacManY += pacManSpeed;

                if (animationCounter < 4)
                {
                    pacManBaseImage = pacManDownImage;
                }
                else if (animationCounter < 7)
                {
                    pacManBaseImage = pacManMouthClosedImage;
                }

                animationCounter++;

                if (animationCounter >= 7)
                {
                    animationCounter = 1;
                }
            }
            if (leftDown == true && pacManX > borderX + borderLineWidth)
            {
                pacManX -= pacManSpeed;

                if (animationCounter < 4)
                {
                    pacManBaseImage = pacManLeftImage;
                }
                else if (animationCounter < 7)
                {
                    pacManBaseImage = pacManMouthClosedImage;
                }

                animationCounter++;

                if (animationCounter >= 7)
                {
                    animationCounter = 1;
                }
            }
            if (rightDown == true && pacManX < borderWidth - pacManWidth)
            {
                pacManX += pacManSpeed;

                if (animationCounter < 4)
                {
                    pacManBaseImage = pacManRightImage;
                }
                else if (animationCounter < 7)
                {
                    pacManBaseImage = pacManMouthClosedImage;
                }

                animationCounter++;

                if (animationCounter >= 7)
                {
                    animationCounter = 1;
                }
            }
            #endregion

            Rectangle pacRec = new Rectangle(pacManX, pacManY, pacManWidth, pacManHeight);


            for (int i = 0; i < wallXList.Count; i++)
            {
                Rectangle wallsRec = new Rectangle(wallXList[i], wallYList[i], wallWidthList[i], wallHeightList[i]);

                if (pacRec.IntersectsWith(wallsRec))
                {
                    pacManX = origX;
                    pacManY = origY;
                }
            }
            for (int j = 0; j < ghostXList.Count; j++)
            {
                int ghostX = ghostXList[j];
                int ghostY = ghostYList[j];

                if (gameState == "running")
                {
                    ghostYList[j] += ghostYSpeedList[j];
                    ghostXList[j] += ghostXSpeedList[j];
                }

                Rectangle ghostsRec = new Rectangle(ghostXList[j], ghostYList[j], ghostWidthList[j], ghostHeightList[j]);

                for (int i = 0; i < wallXList.Count; i++)
                {
                    Rectangle wallsRec = new Rectangle(wallXList[i], wallYList[i], wallWidthList[i], wallHeightList[i]);

                    int direction;
                    direction = randGen.Next(1, 3);

                    if (ghostsRec.IntersectsWith(wallsRec) && ghostXSpeedList[j] == 0)
                    {
                        ghostXList[j] = ghostX;
                        ghostYList[j] = ghostY;
                        if (direction == 1)
                        {
                            ghostXSpeedList[j] = -4;
                        }
                        else
                        {
                            ghostXSpeedList[j] = 4;
                        }
                        ghostYSpeedList[j] = 0;
                        break;
                    }
                    if (ghostsRec.IntersectsWith(wallsRec) && ghostYSpeedList[j] == 0)
                    {
                        ghostXList[j] = ghostX;
                        ghostYList[j] = ghostY;

                        if (direction == 1)
                        {
                            ghostYSpeedList[j] = -4;
                        }
                        else
                        {
                            ghostYSpeedList[j] = 4;
                        }
                        ghostXSpeedList[j] = 0;
                        break;
                    }
                }
            }
            for (int i = 0; i < orbXList.Count; i++)
            {
                Rectangle orbsRec = new Rectangle(orbXList[i], orbYList[i], orbWidthList[i], orbHeightList[i]);

                if (pacRec.IntersectsWith(orbsRec))
                {
                    score += 10;
                    orbXList.RemoveAt(i);
                    orbYList.RemoveAt(i);
                    orbWidthList.RemoveAt(i);
                    orbHeightList.RemoveAt(i);

                    scoreLabel.Text = $"Score\n{score.ToString("0000")}";
                }
            }
            for (int i = 0; i < ghostXList.Count; i++)
            {
                Rectangle ghostsRec = new Rectangle(ghostXList[i], ghostYList[i], ghostWidthList[i], ghostHeightList[i]);

                if (pacRec.IntersectsWith(ghostsRec))
                {
                    lives--;

                    pacManX = 175;
                    pacManY = 295;

                    ghostXList[0] = 10;
                    ghostYList[0] = 10;

                    ghostXList[1] = 330;
                    ghostYList[1] = 10;

                    ghostXList[2] = 10;
                    ghostYList[2] = 450;

                    ghostXList[3] = 330;
                    ghostYList[3] = 450;
                }
                   
            }
            if (orbXList.Count == 0)
            {
                gameState = "over";
                gameTimer.Enabled = false;
                titleLabel.Text = "!!!Victory!!!";
                scoreLabel.Text = "";
            }
            if (lives == 0)
            {
                gameState = "over";
                gameTimer.Enabled = false;
                titleLabel.Text = "You Lose";
                scoreLabel.Text = "";
            }

            Refresh();
        }
    }
}

