﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Custom_Rating_Star_Control
{
    public partial class MyStarRatingBar : Control
    {
        public MyStarRatingBar()
        {

            InitializeComponent();
        }
        [Category("Star Size")]
        private int StarSize
        {
            get => starSize;
            set
            {
                if (value > 0)
                    starSize = value;
            }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {

            Pen pen = new Pen(Color.Black);
            //Point[] points = new Point[8];
            //points[0] = new Point(0, 25);
            //points[1] = new Point(20, 20);
            //points[2] = new Point(25, 0);
            //points[3] = new Point(30, 20);
            //points[4] = new Point(50, 25);
            //points[5] = new Point(30, 30);
            //points[6] = new Point(25, 50);
            //points[7] = new Point(20, 30);
            
            PointF[] points = new PointF[10];
            points[0].X = StarSize * (50) / 100;
            points[0].Y = StarSize * (2.4472f) / 100;
            points[1].X = StarSize * (61.8044f) / 100;
            points[1].Y = StarSize * (38.7743f) / 100;
            points[2].X = StarSize * (100) / 100;
            points[2].Y = StarSize * (38.7743f) / 100;
            points[3].X = StarSize * (69.0983f) / 100;
            points[3].Y = StarSize * (61.2257f) / 100;
            points[4].X = StarSize * (80.9843f) / 100;
            points[4].Y = StarSize * (97.5528f) / 100;
            points[5].X = StarSize * (50) / 100;
            points[5].Y = StarSize * (75.1014f) / 100;
            points[6].X = StarSize * (19.0983f) / 100;
            points[6].Y = StarSize * (97.5528f) / 100;
            points[7].X = StarSize * (30.9017f) / 100;
            points[7].Y = StarSize * (61.2257f) / 100;
            points[8].X = StarSize * (0) / 100;
            points[8].Y = StarSize * (38.7743f) / 100;
            points[9].X = StarSize * (38.1966f) / 100;
            points[9].Y = StarSize * (38.7743f) / 100;

            pe.Graphics.DrawPolygon(pen, points);

            base.OnPaint(pe);
        }

        #region Protected Data

        protected int starSize = 50;

        #endregion
    }
}