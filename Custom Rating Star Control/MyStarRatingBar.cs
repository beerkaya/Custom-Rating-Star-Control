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
                Star tempStar = new(this);

                tempStar.Active = false;
                tempStar.Location = new System.Drawing.Point(StartPoint, 0);
                tempStar.Size = new System.Drawing.Size(StarSize, StarSize);
                tempStar.StarActiveBackColor = System.Drawing.Color.DarkBlue;
                tempStar.StarHoverBackColor = System.Drawing.Color.Yellow;
                tempStar.TabIndex = 0;

                stars.Add(tempStar);

                this.Controls.Add(tempStar);

                StartPoint += StarSize;
                StartPoint += StarSpacing;
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

        [Category("Design"),
        Description("The active color of the stars."),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Color StarActiveBackColor
        {
            get => starActiveBackColor;
            set
            {
                starActiveBackColor = value;
                stars.ForEach(star => star.StarActiveBackColor = value);
                Invalidate();
            }
        }

        [Category("Design"),
        Description("The hovering color of the stars."),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Color StarHoverBackColor
        {
            get => starHoverBackColor;
            set
            {
                starHoverBackColor = value;
                stars.ForEach(star => star.StarHoverBackColor = value);

                Invalidate();
            }
        }

        [Category("Data"),
        Description("The point value."),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int Value
        {
            get => this.value;
            set
            {
                if (value >= 0 && value <= 5)
                    this.value = value;
            }
        }
        protected int StartPoint
        {
            get => startPoint;
            set
            {
                if (value >= 0)
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

        public void star_StarActive(object sender, EventArgs e)
        {
            int index = stars.IndexOf(sender as Star);

            Value = index + 1;

            foreach (var star in stars)
            {
                star.Active = false;
                star.Invalidate();
            }
            for (int i = 0; i < index + 1; i++)
            {
                stars[i].Active = true;
                stars[i].Invalidate();
            }

        }
        public void star_MouseEnter(object sender, EventArgs e)
        {
            int index = stars.IndexOf(sender as Star);

            foreach (var star in stars)
            {
                star.Active = false;
                star.Hovering = false;
                star.Invalidate();
            }

            for (int i = 0; i < index + 1; i++)
            {
                stars[i].Hovering = true;
                stars[i].Invalidate();
            }
        }
        public void star_MouseLeave(object sender, EventArgs e)
        {
            foreach (var star in stars)
            {
                star.Hovering = false;
                star.Invalidate();
            }

            for (int i = 0; i < Value; i++)
            {
                stars[i].Active = true;
                stars[i].Invalidate();
            }
        }



        #region Protected Data

        protected int value = 0;
        protected int starSize = 50;
        private int starSpacing = 15;
        protected int startPoint = 0;
        protected Color starActiveBackColor = Color.DarkBlue;
        protected Color starHoverBackColor = Color.Yellow;

        #endregion
    }
}
