using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Custom_Rating_Star_Control
{
    public partial class MyStarRatingBar : Control
    {
        public List<Star> stars = new List<Star>();
        public MyStarRatingBar()
        {

            for (int i = 0; i < 5; i++)
            {
                Star tempStar = new();

                tempStar.Active = false;
                tempStar.Location = new System.Drawing.Point(StartPoint, 0);
                tempStar.Size = new System.Drawing.Size(starSize, starSize);
                tempStar.StarBackColor = System.Drawing.Color.DarkBlue;
                tempStar.TabIndex = 0;

                stars.Add(tempStar);

                this.Controls.Add(tempStar);

                StartPoint += starSize;
                StartPoint += starSpacing;
            }
            StartPoint = 0;

            InitializeComponent();
        }

        [Category("Layout"),
        Description("Size of single star."),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public int StarSize
        {
            get => starSize;
            set
            {
                if (value > 0)
                {
                    starSize = value;
                    stars.ForEach(star => star.StarSize = value);
                    Height = StarSize;

                    Invalidate();
                }
            }
        }

        [Category("Layout"),
        Description("The space beetween two stars."),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public int StarSpacing
        {
            get => starSpacing;
            set
            {
                if (value >= 0)
                {
                    starSpacing = value;

                    Width = StarSize * 5 + StarSpacing * 4;

                    Invalidate();
                }
            }
        }
        public int StartPoint
        {
            get => startPoint;
            set
            {
                if(value >= 0)
                {
                    startPoint = value;
                }
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            StarSize = Size.Height;
            foreach (var star in stars)
            {
                star.Width = StarSize;
                star.Invalidate();
            }

            Width = StarSize * 5 + StarSpacing * 4;

            base.OnSizeChanged(e);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            foreach (var star in stars)
            {
                star.Location = new System.Drawing.Point(StartPoint, 0);
                star.Size = new System.Drawing.Size(StarSize, StarSize);

                star.Invalidate();

                StartPoint += StarSize;
                StartPoint += StarSpacing;
            }
            StartPoint = 0;

            base.OnPaint(pe);
        }

        protected void DrawStar(Graphics g, int startPoint)
        {
            Pen pen = new(Color.Black, 2.5f);
            PointF[] points = new PointF[10];

            points[0].X = startPoint + StarSize * (50) / 100;
            points[0].Y = StarSize * (2.4472f) / 100;
            points[1].X = startPoint + StarSize * (61.8044f) / 100;
            points[1].Y = StarSize * (38.7743f) / 100;
            points[2].X = startPoint + StarSize * (100) / 100;
            points[2].Y = StarSize * (38.7743f) / 100;
            points[3].X = startPoint + StarSize * (69.0983f) / 100;
            points[3].Y = StarSize * (61.2257f) / 100;
            points[4].X = startPoint + StarSize * (80.9843f) / 100;
            points[4].Y = StarSize * (97.5528f) / 100;
            points[5].X = startPoint + StarSize * (50) / 100;
            points[5].Y = StarSize * (75.1014f) / 100;
            points[6].X = startPoint + StarSize * (19.0983f) / 100;
            points[6].Y = StarSize * (97.5528f) / 100;
            points[7].X = startPoint + StarSize * (30.9017f) / 100;
            points[7].Y = StarSize * (61.2257f) / 100;
            points[8].X = startPoint + StarSize * (0) / 100;
            points[8].Y = StarSize * (38.7743f) / 100;
            points[9].X = startPoint + StarSize * (38.1966f) / 100;
            points[9].Y = StarSize * (38.7743f) / 100;


            g.DrawPolygon(pen, points);

        }



        #region Protected Data

        protected int starSize = 50;
        protected int starSpacing = 15;
        protected int startPoint = 0;

        #endregion
    }
}
